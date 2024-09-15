using Fluent.Infrastructure.FluentModel;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Real_Estate_Management_System_düzenleme.Controllers
{
    public class AccountController : Controller
    {
        // Giriş sayfası
        public IActionResult Login()
        {
            return View();
        }

        // Giriş işlemi (API'ye gönderim)
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // API'ye HTTP POST isteği yaparak kullanıcıyı doğrula
                // Örneğin: /api/Account/Login endpoint'i
                var response = await _httpClient.PostAsJsonAsync("api/Account/Login", model);

                if (response.IsSuccessStatusCode)
                {
                    // Başarılı giriş
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Geçersiz giriş bilgileri.");
            }
            return View(model);
        }

        // Kayıt sayfası
        public IActionResult Register()
        {
            return View();
        }

        // Kayıt işlemi (API'ye gönderim)
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // API'ye HTTP POST isteği yaparak yeni kullanıcı ekle
                var response = await _httpClient.PostAsJsonAsync("api/Account/Register", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login");
                }
                ModelState.AddModelError("", "Kayıt başarısız.");
            }
            return View(model);
        }
    }

}
