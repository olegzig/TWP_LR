using Microsoft.AspNetCore.Identity;

namespace KR.Models
{
    public class ApplicationUser : IdentityUser
    {
        public byte[]? AvatarData { get; set; }
        public string? AvatarContentType { get; set; }
    }
}
