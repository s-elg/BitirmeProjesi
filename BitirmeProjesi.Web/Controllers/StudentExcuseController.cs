namespace BitirmeProjesi.Web.Controllers
{
    public class StudentExcuseController
    {
        public class ExcusesRequest : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult NewRequest()
    {
        return View();
    }

    // 3. Detayları Görüntüle ("Detayları Görüntüle" Linki)
    public IActionResult Detail(int id)
    {
        // id'ye göre mazeretin tüm detaylarını (reddedilme nedeni, eklenen belgeler vb.) getirir.
        return View();
    }
    }
}
