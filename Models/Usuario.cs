using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class Usuario
    {
        public Usuario(){
            
        }
        public Usuario(string Username, string Senha)
        {
            this.Username = Username;
            this.Senha = Senha;
        }


        
        public int Id { get; set; }

        public string Username { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public int Ativo { get; set; }

        public string Cargo { get; set; }

        public string Email { get; set; }


    }
}