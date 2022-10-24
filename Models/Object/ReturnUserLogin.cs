namespace ApiAuth.Models.Object
{
    public class ReturnUserLogin
    {
        public ReturnUserLogin(string username, string fullName, string email, string token)
        {
            this.User = new UserData { Username = username, FullName = fullName, Email = email };
            this.Token = token;
        }

        public UserData User { get; set; }
        public string Token { get; set; }
    }
    public class UserData
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
