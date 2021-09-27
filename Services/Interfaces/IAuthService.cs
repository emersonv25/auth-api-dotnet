using System.Collections.Generic;
using System.Threading.Tasks;
using Login.Models;
using Microsoft.AspNetCore.Mvc;

namespace login.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Usuario> Login(string username, string password); 
        Task<Usuario> Cadastrar(Usuario usuario); 
        Task<Usuario> GetUsuario(string username); 
        Task<Usuario> GetUsuarioByEmail(string email); 
        Task<Usuario> GetUsuarioById(int id); 
        Task<Usuario> PutUsuario(int id, Usuario usuarioEditado);
        Task <bool> DeleteUsuario(int id);
        Task<Usuario> PutUsuarioAdm(int id, Usuario usuarioEditado);
    }
}