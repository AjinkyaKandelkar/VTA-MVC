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
        public bool Registration(UserDto user)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseUrl);
                var payload = JsonConvert.SerializeObject(user);
                 response = client.PostAsJsonAsync("api/User/Register", user).Result;
               
            }

            return response.IsSuccessStatusCode;
        }



        public async Task<UserDto?> LogineAsync(string  Email,string password)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseUrl);
                response = client.GetAsync($"api/User/Login?Email={Email}&password={password}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var abc = await response.Content.ReadFromJsonAsync<UserDto>();
                    StorageBag.currentLoginId = abc.Id;
                    
                    return abc;
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
