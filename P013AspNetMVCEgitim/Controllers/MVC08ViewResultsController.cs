using Microsoft.AspNetCore.Mvc;

namespace P013AspNetMVCEgitim.Controllers
{
    public class MVC08ViewResultsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Yonlendir(string arananDeger)
        {
            //return Redirect("/Home");//bu action tetiklendiğinde uygulama anasayfaya gitsin
            //return Redirect($"/Home?kelime={arananDeger}");  //burada ? işaretinden sonraki kısım querystring yöntemi ile adres çubuğu üzerinden veri yollamak için

            return Redirect("https://siliconmadeacademy.com/akademi/2-asama/P013.html");
        }
        public IActionResult ActionaYonlendir()
        {
            //return RedirectToAction("Index"); //metot çalıştığında aynı controllerdaki bir actiona yönlendirmemizi sağlar
            return RedirectToAction("Index","Home"); //metot çalıştığında farklı bir controllerdaki actiona bu şekilde yönlendirebiliriz
        }

        public RedirectToRouteResult RouteYonlendir()  //IActionResult da kullanılabilir
        {
            return RedirectToRoute("Default", new { controller="Home", action="Index", id="18" }); //metot çalıştığında route sistemiyle yönlendirme yapmamızı sağlar
        }

        public PartialViewResult KategorileriGetirPartial() // IActionResult da kullanılabilir
        {
            return PartialView("_KategorilerPartial");
        }

    }
}
