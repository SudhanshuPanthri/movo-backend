namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<string?> AuthenticateUserAsync(string email, string password);
        Task<bool> RegisterUserAsync(string name, string email, string password);
        String HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}
