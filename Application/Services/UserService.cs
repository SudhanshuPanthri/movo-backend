using Application.Interfaces;
using Domain.Models;
using Infrastructure.Interfaces;
using System.Text;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUser _userRepo;
        private readonly IJWTTokenService _jWTTokenService;

        public UserService(IUser userRepo,IJWTTokenService jWTTokenService)
        {
            _userRepo= userRepo;
            _jWTTokenService = jWTTokenService;
        }

        public async Task<string?> AuthenticateUserAsync(string email, string password)
        {
            var user = await _userRepo.GetUserByEmailAsync(email);
            if (user == null || !VerifyPassword(password, user.PasswordHash)) return null;

            return _jWTTokenService.GenerateToken(user);
        }

        public async Task<bool> RegisterUserAsync(string name, string email, string password)
        {
            var hashedPassword=HashPassword(password);
            var user = new User
            {
                Name = name,
                Email = email,
                PasswordHash = hashedPassword
            };
            return await _userRepo.AddUser(user);
        }

        public string HashPassword(string password)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return HashPassword(enteredPassword) == storedHash;
        }

    }
}
