namespace Encore.Domain.Interfaces.CrossCutting
{
    public interface IPasswordHashService
    {
        string HashPassword(string password);
        bool VerifyPassword(string enteredPassword, string storedPasswordHash);
    }
}
