using Encore.Application.Homes.Responses;
using Encore.Domain.Core.Data;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.Interfaces.CrossCutting;
using Encore.Domain.Interfaces.Data;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Users
{
    public class AuthUserCommandHandler : CommandHandler, IRequestHandler<AuthUserCommand, Response<AuthUserResponse>?>
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashService _passwordHashService;
        private readonly ITokenService _tokenService;

        public AuthUserCommandHandler(IAgentRepository agentRepository,
                                    IUserRepository userRepository,
                                    IPasswordHashService passwordHashService,
                                    ITokenService tokenService,
                                    IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _agentRepository = agentRepository;
            _userRepository = userRepository;
            _passwordHashService = passwordHashService;
            _tokenService = tokenService;
        }

        public async Task<Response<AuthUserResponse>?> Handle(AuthUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.Include().Where(c => c.Email == request.Email).FirstOrDefaultAsync();
                if (user is null || !_passwordHashService.VerifyPassword(request.Password, user.PasswordHash))
                    return null;

                var token = _tokenService.GenerateJwtToken(user);

                return Success(new AuthUserResponse(token, user.Id), new ValidationResult()) ;
            }
            catch (Exception ex)
            {
                AddError("Erro ao realizar autenticação: " + ex.Message);
                return Fail<AuthUserResponse>(ValidationResult);
            }
        }
    }
}
