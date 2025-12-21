namespace BitirmeProjesi.Web.Controllers
{
    public class AccountController
    {
         public IActionResult Login()
 {
     return View();
 }

 [HttpPost]
 public IActionResult Register(string name, string studentNumber, string password)
 {
     // TODO: _context.Students.Add(new Student { ... });
     // _context.SaveChanges();
     return RedirectToAction("Login");
 }

 [HttpPost]
 public IActionResult Login(string studentNumber, string password)
 {
 TODO:
     ViewBag.Error = "Okul numarası veya şifre hatalı!";
     return View();
 }

 public IActionResult Logout()
 {
     HttpContext.Session.Clear(); // Oturumu temizle
     return RedirectToAction("Login");
 }
    }
}
