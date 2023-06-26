using Encore.Domain.Core.Responses;

namespace Encore.Application.Auth
{
    public class AuthUserResponse : Response<AuthUserResponse>
    {
        public string Token { get; set; }

        public AuthUserResponse(string token) => Token = token;
    }
}
