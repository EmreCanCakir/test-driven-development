using AuthManagement.Models;

namespace AuthManagement.Services
{
    public interface ITokenService
    {
        string GenerateJwtToken(String userName, String password);
    }
}
