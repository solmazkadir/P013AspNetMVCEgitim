using Microsoft.AspNetCore.Mvc;
using P013AspNetMVCEgitim.Filters;

namespace P013AspNetMVCEgitim.Controllers
{
    public class MVC14FiltersUsingController : Controller
    {
        [UserControl] //kendi yazdığımız UserControl attribute ü ile  bu actiona oturum açmayan kişilerin erişimini engelliyoruz
        public IActionResult Index()
        {
            ViewBag.Kullanici = HttpContext.Session.GetString("UserGuid"); //UserGuid isimli sessiondaki değeri yakala ve Vİewbag.Kullanici ile  ekrana gönder
            return View();
        }
    }
}
