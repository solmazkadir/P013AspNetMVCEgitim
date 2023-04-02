using Microsoft.AspNetCore.Mvc;

namespace P013AspNetMVCEgitim.Controllers
{
    public class MVC13AppSettingController : Controller
    {
        private readonly IConfiguration _configuration;

        public MVC13AppSettingController(IConfiguration configuration) //DI  _configuration(sağ tık)> quick actions > generate constractor ile oluşturduk
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            TempData["Email"] = _configuration["Email"];
            TempData["MailSunucu"] = _configuration["MailSunucu"];
            TempData["Username"] = _configuration["Username"];
            TempData["KullaniciAdi"] = _configuration["MailKullanici:Username"]; //jsondaki MailKullanici altındaki Username değerine : ile ulaşıyoruz
            TempData["Sifre"] = _configuration.GetSection("MailKullanici:Password").Value; //GetSection metoduyla da veriyi çekebiliriz
            return View();
        }
    }
}
