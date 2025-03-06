using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementation
{
    public class UserRepo:IUser
    {
        private readonly ContextDB _context;

        public UserRepo(ContextDB context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var data= await _context.Users.FirstOrDefaultAsync(x=>x.Email== email);
            if (data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> AddUser(User user)
        {
            var data = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (data == null)
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
