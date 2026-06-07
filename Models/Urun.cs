using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.Models
{
    public class Urun
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public int StokMiktari { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime GirisTarihi { get; set; }
        public string Durum { get; set; }
    }
}
