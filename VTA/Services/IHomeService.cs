using VTA.Models;

namespace VTA.Services
{
    public interface IHomeService
    {
        Task<IEnumerable<UserVehicalDto>> GetVehicals(int? id);
        bool AddVehical(UserVehicalDto vehical);
    }
}