namespace api_auth.Models.Object
{
    public class ReturnToken
    {
        public ReturnToken(string access_Token, string token_Type, string expires_In)
        {
            Access_token = access_Token;
            Token_type = token_Type;
            Expires_in = expires_In;
        }

        public string Access_token { get; set; }
        public string Token_type { get; set; }
        public string Expires_in { get; set; }
    }
}
