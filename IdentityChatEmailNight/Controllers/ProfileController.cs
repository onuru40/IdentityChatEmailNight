using IdentityChatEmailNight.Context;
using IdentityChatEmailNight.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityChatEmailNight.Controllers
{
    public class ProfileController : Controller
    {
        private readonly EmailContext _context; // Başına alt tire ekleyince this anahtar sözcüğü gelmez.
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(EmailContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> ProfileDetail()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name); // Giriş yapan kullanıcının bütün bilgileri burada tutuluyor.

            ViewBag.name = values.Name;
            ViewBag.surname = values.Surname;
            ViewBag.email = values.Email;
            ViewBag.phone = values.PhoneNumber;

            return View();
        }
    }
}
