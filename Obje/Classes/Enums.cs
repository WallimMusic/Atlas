using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obje;
namespace Obje.Classes
{
    public class Enums
    {
        public enum enmErpProgram { Armix, Logo, Mikro, Eta, Sap, Model, Univera };
        public enum enmFormMod { Yeni, Guncelle, Goruntule, Diger };
        public enum enmBorcAlacak { Borc, Alacak };
        public enum enmModul { Stok, Depo, Satinalma, Satis, Finans, Yonetim, Uretim };
        public enum enmYazdirmaMod { Yazdir, YazdirmaSor, Tasarim, Goruntuleme, PDF, EXCEL, TEXT, CSV, DizaynSec }
        public enum enmRaporTip { Tablo, OzetTablo }
        public enum enmKdvHesapTip { KdvdenNete, KdvdenMatraha, MatrahtanKdvye, MatrahtanNete, NettenKdvye, NettenMatraha }
        public enum enmFiltreDataTip { Yok, Liste, OzelListe, Tarih, Sayi, Yazi, Dogru, AltSorgu }
        public enum enmFiltreCumlesi { Esit, EsitDegil, Buyuk, BuyukEsit, Kucuk, KucukEsit, Arasinda, ArasindaDegil, Bos, BosDegil, IleBaslayan, IleBaslamayan, IleBiten, IleBitmeyen, Icinde, IcindeOlmayan }
    }
}
