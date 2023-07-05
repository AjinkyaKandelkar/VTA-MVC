using Newtonsoft.Json;
using System;
using System.Data;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using VTA.Models;

namespace VTA.Services
{
    public class AccountService : IAccountService
    {
        HttpResponseMessage response = new HttpResponseMessage();
        string baseUrl = "https://localhost:7036/api";
        public async Task<bool> Registration(UserDto user)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseUrl);
                var payload = JsonConvert.SerializeObject(user);
                 response = await client.PostAsJsonAsync("api/User/CreateUser", user);
               
            }

            return response.IsSuccessStatusCode;
        }



        public async Task<UserDto?> LogineAsync(string  Email,string password)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseUrl);
                response = await client.GetAsync($"api/User/Login?Email={Email}&password={password}");
                if (response.IsSuccessStatusCode)
                {
                    
                    var abc = await response.Content.ReadFromJsonAsync<LoginResponce>();
                    StorageBag.currentLoginId = abc.Result.Id;
                    
                    return abc.Result;
                }
                else
                    return null;
            }

            
        }

    }


    public static class StorageBag
    {
        public static int? currentLoginId { get; set; }
    }
}
