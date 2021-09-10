using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using login.Services.Interfaces;
using Login.Data;
using Login.Models;
using System.Security.Cryptography;

namespace Login.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        public AuthService(AppDbContext context)
        {
            _context = context;

        }
        public async Task<Usuario> Login(string username, string password)
        {
            Usuario usuario = new Usuario();
            var senha = sha256_hash(password);
            try
            {
                usuario = _context.Usuarios.SingleOrDefault(u => u.Username == username && u.Password == senha);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                usuario = new Usuario();
            }
            return usuario;
        }
        public async Task<Usuario> Cadastrar(Usuario usuario)
        {
            try
            {
                var password = sha256_hash(usuario.Password);
                usuario.Password = password;

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return usuario;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                usuario = new Usuario();
            }
            return usuario;
        }
        public async Task<Usuario> GetUsuario(string username)
        {
            Usuario usuario = new Usuario();
            usuario = _context.Usuarios.SingleOrDefault(u => u.Username == username);

            return usuario;
        }
        public async Task<Usuario> GetUsuarioByEmail(string email)
        {
            Usuario usuario = new Usuario();
            usuario = _context.Usuarios.SingleOrDefault(u => u.Email == email);

            return usuario;
        }
        public static String sha256_hash(String value) {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create()) {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
            }
        }
}