using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Login.Data;
using Login.Models;
using Microsoft.AspNetCore.Authorization;
using Login.Services;

namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Autenticar([FromBody]Usuario user)
        {

            var usuario = _context.Usuarios.SingleOrDefault(u => u.Username == user.Username && u.Senha == user.Senha);

            if (usuario == null){
                return NotFound(new {message = "Usuário ou senha inválidos"});
            }

            var token = TokenService.GenerateToken(usuario);


            usuario.Senha = "";
            return new { usuario = usuario, token = token};

        }
        
        [HttpGet]
        [Route("autenticado")]
        [Authorize]
        public string Autenticado() => String.Format("Autenticado: {0}", User.Identity.Name);

        [HttpGet]
        [Route("anonimo")]
        [AllowAnonymous]
        public string Anonimo() => "Anônimo";

        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "admin,gerente")]
        public string Admin() => "Administrador";

    }


}
