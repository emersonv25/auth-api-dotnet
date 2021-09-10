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


        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Ativo { get; set; }

        public string Cargo { get; set; }

        public string Email { get; set; }


    }
}