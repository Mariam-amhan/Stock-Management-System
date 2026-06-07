using StokTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace StokTakipSistemi.Data
{
    public static class SanalVeritabani
    {
        public static List<Kategori> Kategoriler = new List<Kategori>();
        public static List<Urun> Urunler = new List<Urun>();

        public static int KategoriIdSayac = 1;
        public static int UrunIdSayac = 1;

      
        public static void KategorileriKaydet()
        {
            List<string> satirlar = new List<string>();

            foreach (var k in Kategoriler)
            {
                satirlar.Add($"{k.KategoriId};{k.KategoriAdi};{k.Aciklama}");
            }

            File.WriteAllLines("kategoriler.txt", satirlar);
        }

      
        public static void KategorileriYukle()
        {
            if (!File.Exists("kategoriler.txt"))
                return;

            var satirlar = File.ReadAllLines("kategoriler.txt");

            foreach (var satir in satirlar)
               
            {
                var parca = satir.Split(';');
               
                Kategori k = new Kategori();
                k.KategoriId = int.Parse(parca[0]);
                k.KategoriAdi = parca[1];
                k.Aciklama = parca[2];

                Kategoriler.Add(k);

                if (k.KategoriId >= KategoriIdSayac)
                    KategoriIdSayac = k.KategoriId + 1;
            }
        }


       
        public static void UrunleriKaydet()
        {
            List<string> satirlar = new List<string>();

            foreach (var u in Urunler)
            {
                satirlar.Add($"{u.UrunId};{u.UrunAdi};{u.KategoriId};{u.KategoriAdi};{u.StokMiktari};{u.Fiyat};{u.GirisTarihi};{u.Durum}");
            }

            File.WriteAllLines("urunler.txt", satirlar);
        }


        public static void UrunleriYukle()
        {
            if (!File.Exists("urunler.txt"))
                return;

            var satirlar = File.ReadAllLines("urunler.txt");

            foreach (var satir in satirlar)
            {
                var parca = satir.Split(';');

                Urun u = new Urun();
                u.UrunId = int.Parse(parca[0]);
                u.UrunAdi = parca[1];
                u.KategoriId = int.Parse(parca[2]);
                u.KategoriAdi = parca[3];
                u.StokMiktari = int.Parse(parca[4]);
                u.Fiyat = decimal.Parse(parca[5]);
                u.GirisTarihi = DateTime.Parse(parca[6]);
                u.Durum = parca[7];

                Urunler.Add(u);

                if (u.UrunId >= UrunIdSayac)
                    UrunIdSayac = u.UrunId + 1;
            }
        }
    }


}