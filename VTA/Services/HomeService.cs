using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VTA.Models;

namespace VTA.Services
{
    public class HomeService : IHomeService
    {
        HttpResponseMessage response = new HttpResponseMessage();
        string baseUrl = "https://localhost:7036/api";

        public async Task<IEnumerable<UserVehicalDto>> GetVehicals(int? id)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseUrl);

                response = client.GetAsync($"api/Vehical/Get/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var abc = await response.Content.ReadFromJsonAsync<List<UserVehicalDto>>();
                    return abc;
                }
                else
                    return null;
            }
        }
        public bool AddVehical(UserVehicalDto vehical)
        {
            using (var client = new HttpClient())
            {

                vehical.UserID = StorageBag.currentLoginId;
                vehical.DeviceId = "1";

                client.BaseAddress = new Uri(baseUrl);
                var payload = JsonConvert.SerializeObject(vehical);
                response = client.PostAsJsonAsync("api/Vehical/Post",vehical).Result;
                
            }
            return response.IsSuccessStatusCode;

        }
        
    }
}
