using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;

namespace Encore.Application.Auth
{
    public class AuthUserCommand : Command<Response<AuthUserResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
