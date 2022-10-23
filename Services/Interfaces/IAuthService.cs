using System.Collections.Generic;
using System.Threading.Tasks;
using ApiAuth.Models;
using Microsoft.AspNetCore.Mvc;
using ApiAuth.Models.Object;


namespace ApiAuth.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User?> Login(string username, string password); 
        Task<User> Register(ParamRegister usuario); 
        Task<User?> GetUser(string username); 
        Task<User?> GetUserByEmail(string email); 
        Task<User?> GetUserById(int id); 
        Task<User?> PutUser(string username, User userUpdated);
        Task <bool> DeleteUser(string username);
        Task<User?> PutUserAdm(string username, User userUpdated);
    }
}