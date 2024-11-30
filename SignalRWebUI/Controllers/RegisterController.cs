using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.IdentityDtos;
using System.Security.Principal;

namespace SignalRWebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]  
        public async Task<IActionResult> Index(RegisterDto registerDto)
        {
            AppUser appUser = new AppUser()
            {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Email = registerDto.EMail,
                UserName = registerDto.Username
            };

            //_userManager: ASP.NET Core Identity'den gelen bir servis.
            //Kullanıcı yönetimi (ekleme, silme, şifre doğrulama gibi işlemler) için kullanılır.
            //CreateAsync: Verilen AppUser nesnesini ve şifreyi kullanarak yeni bir kullanıcı oluşturur ve bunu veritabanına kaydeder.
            //registerDto.Password: Kullanıcının şifresi. Bu şifre genellikle şifrelenerek(hashlenerek) kaydedilir.

            var result = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (result.Succeeded)
            {
                //Kullanıcı "Login" controller'ının "Index" metoduna yönlendirilir. 
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
