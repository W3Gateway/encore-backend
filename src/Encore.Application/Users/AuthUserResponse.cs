namespace Encore.Application.Users
{
    public class AuthUserResponse
    {
        public string Token { get; set; }
        public Guid UserId { get; set; }

        public AuthUserResponse(string token, Guid userId)
        {
            Token = token;
            UserId = userId;
        }
    }
}
