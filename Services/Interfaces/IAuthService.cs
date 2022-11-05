using System.Collections.Generic;
using System.Threading.Tasks;
using ApiAuth.Models;
using Microsoft.AspNetCore.Mvc;
using ApiAuth.Models.Object;


namespace ApiAuth.Services.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// get the user's token
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<User?> Login(string username, string password);
        /// <summary>
        /// register the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> Register(ParamRegister user);
        /// <summary>
        /// Get user by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<User?> GetByUsername(string username);
        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User?> GetUserByEmail(string email);
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User?> GetUserById(int id);
        /// <summary>
        /// Allows the user to edit their data
        /// </summary>
        /// <param name="userEdited"></param>
        /// <returns></returns>
        Task<User?> PutUser(string username, ParamUpdateUser userEdited);
        /// <summary>
        /// Delete a specific user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<bool> DeleteUser(string username);
        /// <summary>
        /// Edit a specific user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userEdited"></param>
        /// <returns></returns>
        Task<User?> PutUserAdm(string username, ParamUpdateUserAdm userEdited);
    }
}