using System;
using System.ComponentModel.DataAnnotations;

namespace ApiAuth.Models
{
    public class User
    {
        public User(){
            
        }
        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
        public User(string Username, string Password, string FullName, string Email)
        {
            this.Username = Username;
            this.Password = Password;
            this.FullName = FullName;
            this.Email = Email;
            Admin = false;
            Enabled = true;
        }

        [Key]
        public int UserId { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool? Enabled { get; set; }
        public bool? Admin { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


    }

}