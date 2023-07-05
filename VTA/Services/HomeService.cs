using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VTA.Models;

namespace VTA.Services
{
    public class HomeService : IHomeService
    {
        HttpResponseMessage response = new HttpResponseMessage();
        string baseUrl = "https://localhost:7036/api";

        public async Task<List<UserVehicalDto>> GetVehicals(int? id)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseUrl);

                response = await client.GetAsync($"api/Vehical/GetVehicalsByUserId?userId={id}");
                if (response.IsSuccessStatusCode)
                {
                    var abc = await response.Content.ReadFromJsonAsync<List<UserVehicalDto>>();
                    return abc;
                }
                else
                    return null;
            }
        }
        public async Task DeleteVehicals(int? id)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseUrl);
                response = await client.DeleteAsync($"api/Vehical/DeleteVehical/{id}");
                
            }
        }
        public async Task<UserDto> GetUserDetail(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                response = await client.GetAsync($"api/User/GetUserById/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var abc = await response.Content.ReadFromJsonAsync<UserDto>();
                    return abc;
                }
                else
                    return null;

            }
        }

            public async Task <bool> AddVehical(UserVehicalDto vehical)
        {
            using (var client = new HttpClient())
            {

                vehical.DeviceId = 2;

                client.BaseAddress = new Uri(baseUrl);
                var payload = JsonConvert.SerializeObject(vehical);
                response = await client.PostAsJsonAsync("api/Vehical/CreateVehical", vehical);
                
            }
            return response.IsSuccessStatusCode;

        }
        
    }
}
