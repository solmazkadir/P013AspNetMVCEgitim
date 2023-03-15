using Microsoft.AspNetCore.Mvc;
using P013AspNetMVCEgitim.Models;

namespace P013AspNetMVCEgitim.Controllers
{
    public class MVC04ModelBindingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult KullaniciDetay()
        {
            Kullanici kullanici =new();
            kullanici.KullaniciAdi = "Admin";
            kullanici.Ad = "Kadir";
            kullanici.Soyad = "Solmaz";
            kullanici.Sifre = "123";
            kullanici.Email = "aaa@gmail.com";
            return View(kullanici); //Vİew içerisinde model datası olarak kullanici nesnesini sayfaya gönderdik.
        }
        [HttpPost]
        public IActionResult KullaniciDetay(Kullanici kullanici) //post metodunda modelden gelen nesneyi bu şekilde parantez içinde yakalayabiliyoruz
        {
            return View(kullanici); //gelen kullanıcı nesnesini tekrardan ekrana yolla
        }

        public IActionResult AdresDetay()
        {
            Adres adres = new()
            {
                Sehir = "Konya",
                Ilce = "Beyşehir",
                AcikAdres ="Açık ayran"
            };
            return View(adres);
        }
        public IActionResult UyeSayfasi()
        {
            Kullanici kullanici = new();
            kullanici.KullaniciAdi = "Admin";
            kullanici.Ad = "Kadir";
            kullanici.Soyad = "Solmaz";
            kullanici.Sifre = "123";
            kullanici.Email = "aaa@gmail.com";
            Adres adres = new()
            {
                Sehir = "Konya",
                Ilce = "Beyşehir",
                AcikAdres = "Açık ayran"
            };

            var model = new UyeSayfasiViewModel()
            {
                Kullanici = kullanici,
                Adres = adres
            };
            return View(model);
        }
    }
}
