﻿using Microsoft.AspNetCore.Mvc;

namespace P013AspNetMVCEgitim.Controllers
{
    public class MVC03DataTransferController : Controller
    {
        public IActionResult Index(string Ara) //get metoduyla gönderilen verileri bu şekilde Ara yazarak yakalayabiliriz
        {
            //Mvc de temel olarak 3 farklı yöntemle ekrana veri gönderebiliriz

            //1- ViewBag : Tek kullanımlık ömrü var
            ViewBag.UrunKategorisi = "Bilgisayar";
            //2- ViewData : Tek kullanımlık ömrü var
            ViewData["UrunAdi"] = "Asus Dizüstü Bilgisayar";
            //3- TempData : İki kullanımlık ömrü var
            TempData["UrunFiyati"] = 9999;
            ViewBag.GetVerisi = Ara;
            return View();
        }
        [HttpPost] //aşağıdaki metot post işlemide çalışsın
        public IActionResult Index(string text1,string ddlListe, bool cbOnay, IFormCollection formCollection)
        {
            ViewBag.Yontem1 = "1.Yöntem(Parametrelerden gelen veriler)";
            ViewBag.Mesaj = "Textboxtan gelen veri : " +text1;
            ViewData["MesajListe"] = "ddlListeden gelen veri : " +ddlListe;
            TempData["Tdata"] = "cbOnaydan gelen değer : " + cbOnay;

            ViewBag.Yontem2 = "2.Yöntem(IFormCollection)";
            ViewBag.Mesaj2 = "Textboxtan gelen veri : " + formCollection["text1"] ;
            ViewData["MesajListe2"] = "ddlListeden gelen veri : " + formCollection["ddlListe"];
            TempData["Tdata2"] = "cbOnaydan gelen değer : " + formCollection["cbOnay"][0];

            ViewBag.Yontem3 = "3.Yöntem(RequestForm)";
            ViewBag.Mesaj3 = "Textboxtan gelen veri : " + Request.Form["text1"];
            ViewData["MesajListe3"] = "ddlListeden gelen veri : " + Request.Form["ddlListe"];
            TempData["Tdata3"] = "cbOnaydan gelen değer : " + Request.Form["cbOnay"][0];

            return View();
        }
    }
}
