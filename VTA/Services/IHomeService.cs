using VTA.Models;

namespace VTA.Services
{
    public interface IHomeService
    {
        Task<List<UserVehicalDto>> GetVehicals(int? id);
        Task< bool> AddVehical(UserVehicalDto vehical);
        Task<UserDto> GetUserDetail(int id);
        Task DeleteVehicals(int? id);
    }
}