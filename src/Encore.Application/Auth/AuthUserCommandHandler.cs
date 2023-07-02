using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.Interfaces.CrossCutting;
using Encore.Domain.Interfaces.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Auth
{
    public class AuthUserCommandHandler : CommandHandler, IRequestHandler<AuthUserCommand, Response<AuthUserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashService _passwordHashService;
        private readonly ITokenService _tokenService;
        
        public AuthUserCommandHandler(IUserRepository userRepository,
                                      IPasswordHashService passwordHashService,
                                      ITokenService tokenService) 
        {
            _userRepository = userRepository;
            _passwordHashService = passwordHashService;
            _tokenService = tokenService;
        }

        public async Task<Response<AuthUserResponse>> Handle(AuthUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _userRepository.Include().Where(c => c.Email == request.Email).FirstOrDefaultAsync().Result;
                if (user is null || !_passwordHashService.VerifyPassword(request.Password, user.PasswordHash))
                {
                    AddError("Email ou senha invalidos");
                    return Fail<AuthUserResponse>(ValidationResult);
                }

                var token = _tokenService.GenerateJwtToken(user);

                return new AuthUserResponse(token);
            }
            catch (Exception ex)
            {
                AddError("Erro ao realizar autenticação");
                return Fail<AuthUserResponse>(ValidationResult);
            }
        }
    }
}
