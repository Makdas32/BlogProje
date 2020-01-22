using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogProje.Models;

namespace BlogProje.Controllers
{
    public class YaziController : Controller
    {
        private BlogContext db = new BlogContext();


        public ActionResult Liste(int? id,string AnahtarKelime)
        {
            var yazilar = db.Yazilar
                .Where(i => i.Onay == true)
                .Select(i => new YaziModel()
                {
                    Id = i.Id,
                    Baslik = i.Baslik.Length > 100 ? i.Baslik.Substring(0, 100) + "..." : i.Baslik,
                    Aciklama = i.Aciklama,
                    EklenmeTarihi = i.EklenmeTarihi,
                    Anasayfa = i.Anasayfa,
                    Onay = i.Onay,
                    Resim = i.Resim,
                    KategoriId = i.KategoriId
                }).AsQueryable();

            //if (string.IsNullOrEmpty("AnahtarKelime") == false)
            //{
            //   yazilar = yazilar.Where(i => i.Baslik.Contains(AnahtarKelime) || i.Aciklama.Contains(AnahtarKelime));
            //}

            if (id!=null)
            {
                yazilar = yazilar.Where(i => i.KategoriId == id);
            }
            return View(yazilar.ToList());
        }


        // GET: Yazi
        public ActionResult Index()
        {
            var yazilar = db.Yazilar.Include(y => y.Kategori).OrderByDescending(i=>i.EklenmeTarihi); //Inlude demesinin sebebi yazıların kategoriye göre alınması
            return View(yazilar.ToList());
        }

        // GET: Yazi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yazi yazi = db.Yazilar.Find(id);
            if (yazi == null)
            {
                return HttpNotFound();
            }
            return View(yazi);
        }

        public ActionResult Ekle()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi");
            return View();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle([Bind(Include = "Baslik,Aciklama,Resim,İcerik,KategoriId")] Yazi yazi)
        {
            if (ModelState.IsValid)
            {
                yazi.EklenmeTarihi = DateTime.Now;
                yazi.Onay = false;
                yazi.Anasayfa = false;
                db.Yazilar.Add(yazi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", yazi.KategoriId);
            return View(yazi);
        }

        // GET: Yazi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yazi yazi = db.Yazilar.Find(id);
            if (yazi == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", yazi.KategoriId);
            return View(yazi);
        }

        // POST: Yazi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Baslik,Aciklama,Resim,İcerik,Onay,Anasayfa,KategoriId")] Yazi yazi)
        {
            if (ModelState.IsValid)
            {
                var yeniyazi = db.Yazilar.Find(yazi.Id);
                if (yeniyazi !=null)
                {
                    yeniyazi.Baslik = yazi.Baslik;
                    yeniyazi.Aciklama = yazi.Aciklama;
                    yeniyazi.İcerik = yazi.İcerik;
                    yeniyazi.Resim = yazi.Resim;
                    yeniyazi.Onay = yazi.Onay;
                    yeniyazi.Anasayfa = yazi.Anasayfa;
                    yeniyazi.KategoriId = yazi.KategoriId;

                    db.SaveChanges();
                    TempData["YaziGuncel"] = yeniyazi; //Ekrana güncellendi mesajı vermek için ekledik
                    return RedirectToAction("Index");
                }               
            }
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", yazi.KategoriId);
            return View(yazi);
        }

        // GET: Yazi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yazi yazi = db.Yazilar.Find(id);
            if (yazi == null)
            {
                return HttpNotFound();
            }
            return View(yazi);
        }

        // POST: Yazi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yazi yazi = db.Yazilar.Find(id);
            db.Yazilar.Remove(yazi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
