using Microsoft.AspNetCore.Mvc;
using ApiAuth.Models;
using Microsoft.AspNetCore.Authorization;
using ApiAuth.Services;
using ApiAuth.Services.Interfaces;
using ApiAuth.Models.Object;

namespace ApiAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Login, obtem o token do usuário através de seu username e senha
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<ViewUser> Login([FromBody]ParamLogin login)
        {
            try
            {
                User user = _authService.Login(login.Username, login.Password);
                if (user == null)
                {
                    return BadRequest("Usuário ou senha inválidos !");
                }

                if (user.Enabled == false)
                {
                    return BadRequest("Usuário Inativo !");
                }

                var token = TokenService.GenerateToken(user);

                return new ViewUser(user.Username, user.FullName, user.Email, token); ;
            }
            catch(Exception ex)
            {
                return BadRequest("Não foi possível realizar o login: " + ex.Message);
            }

        }
        /// <summary>
        /// Registra o usuário
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody]ParamRegister user)
        {
            try
            {
                if (user.Username != null && user.Password != null && user.FullName != null)
                {
                    if (user.Password.Length < 4)
                    {
                        return BadRequest("A Senha precisa conter mais de 4 caracteres");
                    }
                    if (user.Username.Length < 4)
                    {
                        return BadRequest("O nome de usuário precisa conter mais de 4 caracteres");
                    }
                    if (user.FullName == "")
                    {
                        return BadRequest("O Nome não pode ser nulo");
                    }
                    if (_authService.GetUser(user.Username) != null)
                    {
                        return BadRequest("Nome de usuário já cadastrado");
                    }
                    if (_authService.GetUserByEmail(user.Email) != null)
                    {
                        return BadRequest("E-mail já cadastrado");
                    }
                }
                else
                {
                    return BadRequest("Dados para o cadastro inválidos !");
                }

                User newUser = await _authService.Register(user);
                if (newUser == null)
                {
                    return BadRequest("Não foi possivel cadastrar o usuário");
                }

                return Ok("Usuário cadastrado com sucesso !");
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível realizar o cadastro: " + ex.Message);
            }

        }
        /// <summary>
        /// Edita um usuário especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("admin/update/{id:int}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> UpdateAdmin(int id, User usuarioEditado)
        {
            try
            {
                User usuario = await _authService.PutUserAdm(id, usuarioEditado);
                if (usuario == null)
                {
                    return BadRequest("Falha ao editar usuário");
                }

                return Ok("Usuário editado com sucesso !");
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possivel realizar a atualização: " + ex.Message);
            }

        }
        /// <summary>
        /// Permite o proprio usuário editar seus dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update/{id:int}")]
        [Authorize]
        public async Task<ActionResult> Update(int id, User userEdited)
        {
            try
            {
                var userId = HttpContext.User;
                var username = userId.Identity.Name;
                User user = await _authService.PutUser(id, userEdited);
                if (user == null)
                {
                    return BadRequest("Falha ao editar usuário");
                }

                return Ok("Usuário editado com sucesso !");

            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possivel realizar a atualização: " + ex.Message);
            }

        }
        /// <summary>
        /// Deleta um usuário especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("admin/delete/{id:int}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeleteUserAdm(int id)
        {

            try
            {
                bool user = await _authService.DeleteUser(id);
                if (user == false)
                {
                    return BadRequest("Falha ao deletar usuário");
                }

                return Ok("Usuário deletado com sucesso !");
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível excluir o usuário: " + ex.Message);
            }

        }

        /// <summary>
        /// Verifica se está autenticado
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Autenticado() {
            return String.Format("Autenticado: {0}", User.Identity.Name);
         }
        /// <summary>
        /// Verifica se tem permissão de administrador
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "admin")]
        public string Admin() => "Administrador";

    }


}
