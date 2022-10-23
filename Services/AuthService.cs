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
        public async Task<User?> GetUser(string username)
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

        public async Task<User?> PutUserAdm(string username, User userEdited)
        {
            var user = await _context.User.SingleOrDefaultAsync(u => u.Username == username);
            if (user != null)
            {
                if (userEdited.Password != "" && userEdited.Password != null)
                {
                    var password = Utils.sha256_hash(userEdited.Password);
                    user.Password = password;
                }
                user.FullName = userEdited.FullName;
                user.Username = userEdited.Username;
                user.Enabled = userEdited.Enabled;
                user.Admin = userEdited.Admin;
                user.Email = userEdited.Email;
                await _context.SaveChangesAsync();
            }

            return user;
        }
        public async Task<User?> PutUser(string username, User userEdited)
        {

            var user = await _context.User.SingleOrDefaultAsync(u => u.Username == username);
            if(user != null )
            {
                if (userEdited.Password != "" && userEdited.Password != null)
                {
                    var password = Utils.sha256_hash(userEdited.Password);
                    user.Password = password;
                }
                user.FullName = userEdited.FullName;
                user.Username = userEdited.Username;
                user.Email = userEdited.Email;
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