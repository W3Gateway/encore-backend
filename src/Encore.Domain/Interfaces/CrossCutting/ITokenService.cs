using Encore.Domain.Models;

namespace Encore.Domain.Interfaces.CrossCutting
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
    }
}
