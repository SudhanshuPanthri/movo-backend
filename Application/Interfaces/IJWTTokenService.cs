using Domain.Models;

namespace Application.Interfaces
{
    public interface IJWTTokenService
    {
        string GenerateToken(User user);
    }
}
