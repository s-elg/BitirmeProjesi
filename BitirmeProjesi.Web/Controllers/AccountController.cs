using BitirmeProjesi.Web.Models.Account;
using Microsoft.AspNetCore.Mvc;

namespace BitirmeProjesi.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            // TODO: Auth işlemleri (Identity vs)
            // model.Role'a göre yönlendirme yaparsın.
            return RedirectToAction("Index", "Home");
        }
    }
}
