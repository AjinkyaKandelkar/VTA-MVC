using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.Diagnostics;
using VTA.Models;
using VTA.Services;

namespace VTA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IHomeService _homeservice;
        public HomeController(ILogger<HomeController> logger, IHomeService homeservice)
        {
            _logger = logger;
            _homeservice = homeservice;
        }
        
        public async Task<IActionResult> Index(int userid)
        {
            var userinfo = await _homeservice.GetUserDetail(userid);
            var vehicals = await _homeservice.GetVehicals(userid);
            var result = new UserAndVehicals()
            {
                User = userinfo,
                Vehical = vehicals
            };

            return View(result);
        }
        public async Task<IActionResult> AddVehical(UserVehicalDto vehical)
        {
            vehical.UserID = StorageBag.currentLoginId;
            var code =await _homeservice.AddVehical(vehical);
            if(code)
            {
                return RedirectToAction("Index", "Home",new { @userid = vehical.UserID });
            }
            else
            return View();
        }

        public async Task DeleteVehical(int id)
        {
            await _homeservice.DeleteVehicals(id);
        }
        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}