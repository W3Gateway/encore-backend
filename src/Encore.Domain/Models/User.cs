using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class User : Entity<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }

}
