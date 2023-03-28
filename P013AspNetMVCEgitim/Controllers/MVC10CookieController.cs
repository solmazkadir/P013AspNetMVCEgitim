using Microsoft.AspNetCore.Mvc;
using P013AspNetMVCEgitim.Models;

namespace P013AspNetMVCEgitim.Controllers
{
    public class MVC10CookieController : Controller
    {
        UyeContext context = new UyeContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CookieOlustur(string kullaniciAdi, string sifre)
        {
            var kullanici = context.Uyes.FirstOrDefault(k=>k.KullaniciAdi==kullaniciAdi && k.Sifre == sifre);
            if (kullanici!=null)
            {
                // girilen bilgilerle eşlenen kullanıcı varsa 
            }
            if (kullaniciAdi == "admin" && sifre == "123")
            {
                CookieOptions cookieAyarlari = new()
                {
                    Expires = DateTime.Now.AddMinutes(1) // bu ayarları kullanarak oluşturacağımız cookie ye 1 dklık yaşam süresi belirledik
                };
                Response.Cookies.Append("kullaniciAdi", kullaniciAdi, cookieAyarlari);
                Response.Cookies.Append("sifre", sifre, cookieAyarlari);
                Response.Cookies.Append("userguid", Guid.NewGuid().ToString()); //Guid.NewGuid() metoduyla kullanıcıya özel benzersiz bir numara oluşturduk
                return RedirectToAction("CookieOku");
            }
            else TempData["Mesaj"] = @"<div class ='alert alert-danger'>Giriş Başarısız!</div>";
            return View("Index");
        }
        public IActionResult CookieOku()
        {
            if (Request.Cookies["userguid"] is null) //controller da cookielere bu şekilde ulaşabiliriz
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult CookieSil()
        {
            Response.Cookies.Delete("kullaniciAdi");
            Response.Cookies.Delete("sifre");
            Response.Cookies.Delete("userguid");
            
            return RedirectToAction("CookieOku");
        }
    }
}
