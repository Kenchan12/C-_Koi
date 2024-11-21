using KoiFishManager.Models;

namespace KoiFishManager.Web.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task Logout();
    }
}
