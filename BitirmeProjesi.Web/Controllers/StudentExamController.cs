namespace BitirmeProjesi.Web.Controllers
{
    public class StudentExamController
    {
        public IActionResult ConfirmScreen(int id)
{
   
    ViewBag.SinavAdi = "MAT101 - Matematik I Final Sınavı"; //örnek model yok
    ViewBag.Tarih = "25 Aralık 2023, Pazartesi";
    ViewBag.Saat = "10:00";

    return View();
}

       
[HttpPost]
public IActionResult ConfirmAttendance(int examId)
{
    /* TODO: Veritabanı İşlemi
    var record = _context.Attendances.FirstOrDefault(x => x.ExamId == examId);
    if(record != null) {
        record.IsConfirmed = true;
        _context.SaveChanges();
    }
    */

    // Kağıt tasarrufu mesajı (Sunumun için çok önemli)
    TempData["Message"] = "Katılımınız onaylandı!";

    return RedirectToAction("Index", "Home");
}


[HttpPost]
public IActionResult RejectAttendance(int examId, string reason)
{
    /* TODO: Veritabanı İşlemi
    var record = _context.Attendances.FirstOrDefault(x => x.ExamId == examId);
    if(record != null) {
        record.IsConfirmed = false;
        record.RejectionReason = reason; // İsteğe bağlı reddetme nedeni
        _context.SaveChanges();
    }
    */

    TempData["Message"] = "Katılmama durumunuz sisteme işlendi.";
    return RedirectToAction("Index", "Home");
}
    }
}
