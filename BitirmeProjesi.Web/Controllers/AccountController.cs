using Microsoft.AspNetCore.Mvc; // CS0103 hatalarını çözer
using Microsoft.AspNetCore.Http; // CS0120 Session hatasını çözer

namespace BitirmeProjesi.Web.Controllers
{
  
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string studentNumber, string password)
        {
            // Basit bir örnek kontrol
            if (studentNumber == "123" && password == "123")
            {
                // Session kullanımı: 'HttpContext.Session' şeklinde yazmalısın
                HttpContext.Session.SetString("UserNumber", studentNumber);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Giriş bilgileri hatalı."; // ViewBag hatasını da çözer
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
