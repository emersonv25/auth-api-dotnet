using System;
using System.Linq;
using System.Threading.Tasks;
using ApiAuth.Data;
using ApiAuth.Models;
using ApiAuth.Services.Interfaces;
using ApiAuth.Models.Object;

namespace ApiAuth.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        public AuthService(AppDbContext context)
        {
            _context = context;

        }
        public User Login(string username, string password)
        {
            var passwordCrypted = Utils.sha256_hash(password);
            User user = _context.User.SingleOrDefault(u => u.Username == username && u.Password == passwordCrypted);
            return user;
        }
        public async Task<User> Register(ParamRegister user)
        {
            var password = Utils.sha256_hash(user.Password);
            User newUser = new User(user.Username, password, user.FullName, user.Email);
            _context.User.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }
        public User GetUser(string username)
        {
            User user = new User();
            user = _context.User.SingleOrDefault(u => u.Username == username);

            return user;
        }
        public User GetUserByEmail(string email)
        {
            User user = new User();
            user = _context.User.SingleOrDefault(u => u.Email == email);

            return user;
        }
        public async Task<User> GetUserById(int id)
        {
            User user = await _context.User.FindAsync(id);

            return user;
        }

        public async Task<User> PutUserAdm(int id, User userEdited)
        {
            User user = await _context.User.FindAsync(id);
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

            return user;
        }
        public async Task<User> PutUser(int id, User userEdited)
        {

            User user = await _context.User.FindAsync(id);
            if (userEdited.Password != "" && userEdited.Password != null)
            {
                var password = Utils.sha256_hash(userEdited.Password);
                user.Password = password;
            }
            user.FullName = userEdited.FullName;
            user.Username = userEdited.Username;
            user.Email = userEdited.Email;
            await _context.SaveChangesAsync();

            return user;
        }
        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
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