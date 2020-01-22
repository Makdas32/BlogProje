using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogProje.Models
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext> //Tablolarda değişiklik olursa veritabanını silip tekrar oluştur demek istedik
    {
        protected override void Seed(BlogContext context)
        {
            List<Kategori> kategoriler = new List<Kategori>()
            {
                new Kategori {KategoriAdi="C#"},
                new Kategori {KategoriAdi="Asp.Net MVC"},
                new Kategori {KategoriAdi="Asp.Net Web Form"},
                new Kategori {KategoriAdi="Windows Form"}
            };
            foreach (var kategori in kategoriler)
            {
                context.Kategoriler.Add(kategori);
            }
            context.SaveChanges();

            List<Yazi> yazilar = new List<Yazi>()
            {
                new Yazi{Baslik="C# Kalıtım",Aciklama="C# Kalıtım Hakkında C# Kalıtım Hakkında",EklenmeTarihi=DateTime.Now.AddDays(-10),Anasayfa=true,Onay=true,İcerik="C# Kalıtım Hakkında Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",Resim="1.jpg",KategoriId=1},
                new Yazi{Baslik="C# Kalıtım",Aciklama="C# Kalıtım Hakkında C# Kalıtım Hakkında",EklenmeTarihi=DateTime.Now.AddDays(-12),Anasayfa=false,Onay=true,İcerik="C# Kalıtım Hakkında Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",Resim="1.jpg",KategoriId=1},
                new Yazi{Baslik="C# Kalıtım",Aciklama="C# Kalıtım Hakkında C# Kalıtım Hakkında",EklenmeTarihi=DateTime.Now.AddDays(-13),Anasayfa=true,Onay=false,İcerik="C# Kalıtım Hakkında Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",Resim="1.jpg",KategoriId=1},
                new Yazi{Baslik="Asp.Net MVC Layout",Aciklama="Asp.Net MVC Layout Hakkında Asp.Net MVC Layout Hakkında",EklenmeTarihi=DateTime.Now.AddDays(-15),Anasayfa=true,Onay=false,İcerik="Asp.Net MVC Layout Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",Resim="2.jpg",KategoriId=2},
                new Yazi{Baslik="Asp.Net MVC Layout",Aciklama="Asp.Net MVC Layout Hakkında Asp.Net MVC Layout Hakkında",EklenmeTarihi=DateTime.Now.AddDays(-10),Anasayfa=true,Onay=true,İcerik="Asp.Net MVC Layout Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",Resim="2.jpg",KategoriId=2},
                new Yazi{Baslik="Asp.Net MVC Layout",Aciklama="Asp.Net MVC Layout Hakkında Asp.Net MVC Layout Hakkında",EklenmeTarihi=DateTime.Now.AddDays(-12),Anasayfa=false,Onay=true,İcerik="Asp.Net MVC Layout Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",Resim="2.jpg",KategoriId=2},
                new Yazi{Baslik="Asp.Net Web Form Dersleri",Aciklama="Asp.Net Web Form Dersleri Hakkında Asp.Net Web Form Dersleri Hakkında",EklenmeTarihi=DateTime.Now.AddDays(-20),Anasayfa=true,Onay=true,İcerik="Asp.Net Web Form Dersleri Hakkında Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",Resim="3.jpg",KategoriId=3},
                new Yazi{Baslik="Asp.Net Web Form Dersleri",Aciklama="Asp.Net Web Form Dersleri Hakkında Asp.Net Web Form Dersleri Hakkında",EklenmeTarihi=DateTime.Now.AddDays(-22),Anasayfa=false,Onay=true,İcerik="Asp.Net Web Form Dersleri Hakkında Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",Resim="3.jpg",KategoriId=3},
                new Yazi{Baslik="Asp.Net Web Form Dersleri",Aciklama="Asp.Net Web Form Dersleri Hakkında Asp.Net Web Form Dersleri Hakkında",EklenmeTarihi=DateTime.Now.AddDays(-70),Anasayfa=true,Onay=false,İcerik="Asp.Net Web Form Dersleri Hakkında Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",Resim="3.jpg",KategoriId=3},
                new Yazi{Baslik="Windows Form Dersleri",Aciklama="Windows Form Dersleri Hakkında Windows Form Dersleri Hakkında",EklenmeTarihi=DateTime.Now.AddDays(-16),Anasayfa=false,Onay=true,İcerik="Windows Form Dersleri Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",Resim="4.jpg",KategoriId=4},
                new Yazi{Baslik="Windows Form Dersleri",Aciklama="Windows Form Dersleri Hakkında Windows Form Dersleri Hakkında",EklenmeTarihi=DateTime.Now.AddDays(-10),Anasayfa=true,Onay=true,İcerik="Windows Form Dersleri Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",Resim="4.jpg",KategoriId=4},
                new Yazi{Baslik="Windows Form Dersleri",Aciklama="Windows Form Dersleri Hakkında Windows Form Dersleri Hakkında",EklenmeTarihi=DateTime.Now.AddDays(-14),Anasayfa=true,Onay=false,İcerik="Windows Form Dersleri Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",Resim="4.jpg",KategoriId=4},
            };
            foreach (var yazi in yazilar)
            {
                context.Yazilar.Add(yazi);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}