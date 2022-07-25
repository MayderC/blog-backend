namespace BlogApplication.DTOs.Auth
{
    public class LoginResponse
    {
        public LoginResponse(bool isAuthenticated, string token, string refresh)
        {
            this.IsAuthenticated = isAuthenticated;
            this.Token = token;
            this.RefreshToken = refresh;
        }

        public bool IsAuthenticated { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }

    }
}
