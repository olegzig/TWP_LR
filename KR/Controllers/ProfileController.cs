using KR.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KR.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ApplicationUser model, IFormFile avatar, bool removeAvatar = false)
        {
            var user = await _userManager.GetUserAsync(User);

            if (removeAvatar)
            {
                user.AvatarData = null;
                user.AvatarContentType = null;
            }

            if (avatar != null && avatar.Length > 0)
            {
                // Валидация изображения
                if (avatar.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("Avatar", "File size exceeds 2MB");
                    return View(model);
                }

                if (!avatar.ContentType.StartsWith("image/"))
                {
                    ModelState.AddModelError("Avatar", "Only image files are allowed");
                    return View(model);
                }

                using var memoryStream = new MemoryStream();
                await avatar.CopyToAsync(memoryStream);
                user.AvatarData = memoryStream.ToArray();
                user.AvatarContentType = avatar.ContentType;
            }

            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Todo");
        }
    }
}
