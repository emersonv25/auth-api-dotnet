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



        public int Id { get; set; }

        public string Username { get; set; }

        public string Nome { get; set; }

        public string Password { get; set; }

        public int Ativo { get; set; }

        public string Cargo { get; set; }

        public string Email { get; set; }


    }
}