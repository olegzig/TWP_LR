using LibIdentityMicrosoft.Entities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LR5.Controllers
{
    public class ImageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public ImageController(UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }

        public async Task<IActionResult> GetAvatar()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user?.AvatarImage != null)
            {
                return File(user.AvatarImage, user.AvatarMimeType ?? "image/jpeg");
            }
            else
            {
                var defaultAvatarPath = Path.Combine(_env.WebRootPath, "images/anonymous.png");
                return PhysicalFile(defaultAvatarPath, "image/png");
            }
        }
    }
}
