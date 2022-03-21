using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class Usuario
    {
        public Usuario(){
            
        }
        public Usuario(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
        public Usuario(string Username, string Password, string Nome, string Email, string Cargo = "usuario", int Ativo = 1)
        {
            this.Username = Username;
            this.Password = Password;
            this.Nome = Nome;
            this.Email = Email;
            this.Cargo = Cargo;
            this.Ativo = Ativo;
        }



        public int Id { get; set; }

        public string Username { get; set; }

        public string Nome { get; set; }

        public string Password { get; set; }

        public int Ativo { get; set; }

        public string Cargo { get; set; }

        public string Email { get; set; }


    }
    public class ParamLogin
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
    public class ParamCadastro
    {
        public string Username { get; set; }

        public string Nome { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}