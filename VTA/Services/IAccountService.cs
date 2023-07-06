using VTA.Models;

namespace VTA.Services
{
    public interface IAccountService
    {
         Task<int?> Registration(UserDto user);
        Task<UserDto> LogineAsync(string EmailAddress, string password);

	}
}