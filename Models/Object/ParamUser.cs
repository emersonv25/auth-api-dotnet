using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuth.Models.Object
{
    public class ParamLogin
    {
        [Required(ErrorMessage = "Nome de usuário obrigatorio", AllowEmptyStrings = false)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Senha Obrigatoria", AllowEmptyStrings = false)]
        [StringLength(64, MinimumLength = 4)]
        public string Password { get; set; }
    }
    public class ParamRegister
    {
        [Required(ErrorMessage = "O Nome de usuário é obrigatorio", AllowEmptyStrings = false)]
        [StringLength(64, MinimumLength = 4)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Seu nome é obrigatório", AllowEmptyStrings = false)]
        [StringLength(64, MinimumLength = 4)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Uma senha é obrigatória", AllowEmptyStrings = false)]
        [StringLength(64, MinimumLength = 4)]
        public string Password { get; set; }

        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }
    }
}
