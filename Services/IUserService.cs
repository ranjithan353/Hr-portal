// Services/IUserService.cs
using HRPortal.Models;
using System.Threading.Tasks;

namespace HRPortal.Services
{
    public interface IUserService
    {
        Task<User> GetUserByUsernameOrMobileAsync(string usernameOrMobile);
        Task CreateUserAsync(User user);
        string GenerateJwtToken(User user);
    }
}