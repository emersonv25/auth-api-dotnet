using System;
using System.Linq;
using System.Threading.Tasks;
using ApiAuth.Data;
using ApiAuth.Models;
using ApiAuth.Services.Interfaces;
using ApiAuth.Models.Object;
using Microsoft.EntityFrameworkCore;

namespace ApiAuth.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        public AuthService(AppDbContext context)
        {
            _context = context;

        }
        public async Task<User?> Login(string username, string password)
        {
            var passwordCrypted = Utils.sha256_hash(password);
            var user = await _context.User.SingleOrDefaultAsync(u => u.Username == username && u.Password == passwordCrypted);
            return user;
        }
        public async Task<User> Register(ParamRegister user)
        {
            var password = Utils.sha256_hash(user.Password);
            var newUser = new User(user.Username, password, user.FullName, user.Email);
            _context.User.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }
        public async Task<User?> GetByUsername(string username)
        {
            var user = new User();
            user = await _context.User.SingleOrDefaultAsync(u => u.Username == username);

            return user;
        }
        public async Task<User?> GetUserByEmail(string email)
        {
            var user = new User();
            user = await _context.User.SingleOrDefaultAsync(u => u.Email == email);

            return user;
        }
        public async Task<User?> GetUserById(int id)
        {
            var user = await _context.User.FindAsync(id);

            return user;
        }

        public async Task<User?> PutUserAdm(string username, ParamUpdateUserAdm userEdited)
        {
            var user = await _context.User.SingleOrDefaultAsync(u => u.Username == username);
            if (user != null)
            {
                if (!string.IsNullOrWhiteSpace(userEdited.Password))
                {
                    var password = Utils.sha256_hash(userEdited.Password);
                    user.Password = password;
                }
                if (!string.IsNullOrWhiteSpace(userEdited.FullName))
                {
                    user.FullName = userEdited.FullName;
                }
                if (!string.IsNullOrWhiteSpace(userEdited.Username))
                {
                    user.Username = userEdited.Username;
                }
                if (!string.IsNullOrWhiteSpace(userEdited.Email))
                {
                    user.Email = userEdited.Email;
                }
                if (!string.IsNullOrWhiteSpace(userEdited.Email))
                {
                    user.Email = userEdited.Email;
                }
                if (userEdited.Enabled.HasValue)
                {
                    user.Enabled = userEdited.Enabled;
                }
                if (userEdited.Admin.HasValue)
                {
                    user.Admin = userEdited.Admin;
                }
                await _context.SaveChangesAsync();
            }

            return user;
        }
        public async Task<User?> PutUser(string username, ParamUpdateUser userEdited)
        {

            var user = await _context.User.SingleOrDefaultAsync(u => u.Username == username);
            if(user != null )
            {
                if (userEdited.Password != "" && userEdited.Password != null)
                {
                    var password = Utils.sha256_hash(userEdited.Password);
                    user.Password = password;
                }
                if(!string.IsNullOrWhiteSpace(userEdited.FullName))
                {
                    user.FullName = userEdited.FullName;
                }
                if (!string.IsNullOrWhiteSpace(userEdited.Username))
                {
                    user.Username = userEdited.Username;
                }
                if (!string.IsNullOrWhiteSpace(userEdited.Email))
                {
                    user.Email = userEdited.Email;
                }
                await _context.SaveChangesAsync();
            }

            return user;
        }
        public async Task<bool> DeleteUser(string username)
        {
            var user = await _context.User.SingleOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                return false;
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}