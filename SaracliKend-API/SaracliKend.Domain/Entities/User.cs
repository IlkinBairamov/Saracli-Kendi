using Microsoft.AspNetCore.Identity;

namespace SaracliKend.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
