using VTA.Models;

namespace VTA.Services
{
    public interface IAccountService
    {
        bool Registration(UserDto user);
        Task<UserDto> LogineAsync(string EmailAddress, string password);

	}
}