using System.Collections.Generic;
using System.Threading.Tasks;
using Login.Models;

namespace login.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Usuario> Login(string username, string password); 
        Task<Usuario> Cadastrar(Usuario usuario); 
        Task<Usuario> GetUsuario(string username); 
        Task<Usuario> GetUsuarioByEmail(string email); 

    }
}