namespace Encore.Application.Users
{
    public class AuthUserResponse
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public Guid UserId { get; set; }

        public AuthUserResponse(string name, string token, Guid userId)
        {
            Name = name;
            Token = token;
            UserId = userId;
        }
    }
}
