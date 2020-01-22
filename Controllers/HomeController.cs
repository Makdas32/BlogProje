using BlogProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProje.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private BlogContext db = new BlogContext();
        public ActionResult Index()
        {
            var yazilar = db.Yazilar
                .Where(i => i.Anasayfa == true && i.Onay == true)
                .Select(i => new YaziModel()
                {
                    Id = i.Id,
                    Baslik = i.Baslik.Length > 100 ? i.Baslik.Substring(0, 100) + "..." : i.Baslik,
                    Aciklama = i.Aciklama,
                    EklenmeTarihi = i.EklenmeTarihi,
                    Anasayfa = i.Anasayfa,
                    Onay = i.Onay,
                    Resim = i.Resim
                });
                

            return View(yazilar.ToList());
        }
    }
}