using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogProje.Models
{
    public class BlogContext : DbContext
    {
        //Initializer çalışması için constructor metod yazdık
        public BlogContext() : base("blogDb") //Connectionstringde verdiğimiz ismi giriyoruz
        {
            Database.SetInitializer(new BlogInitializer());
        }
        public DbSet<Yazi> Yazilar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
    }
}