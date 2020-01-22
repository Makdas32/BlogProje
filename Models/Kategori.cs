using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProje.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }

        //İlişkiler
        public List<Yazi> Yazilar { get; set; }
    }
}