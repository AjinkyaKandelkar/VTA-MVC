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
        
        public async Task<IActionResult> Index(UserDto user)
        {
            var vehicals = await _homeservice.GetVehicals(user.Id);
            return View(vehicals);
        }
        public IActionResult AddVehical(UserVehicalDto vehical)
        {
            var code =_homeservice.AddVehical(vehical);
            if(code !=false)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            return View();
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