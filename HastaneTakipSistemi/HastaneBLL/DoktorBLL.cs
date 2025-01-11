using HastaneTakipSistemi.HastaneDAL;
using HastaneTakipSistemi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneTakipSistemi.HastaneBLL
{
    public class DoktorBLL
    {
        public static List<doktorlar> GetDoktorKimlikByIdBLL(int doktorId)
        {

            var doktor = DoktorDAL.GetDoktorKimlikByIdDAL(doktorId).ToList();

            return doktor;

        }

        public  static List<recete> GetReceteByTCBLL(string TCkimlikNo)
        {
            if(CommonHelper.TCKimlikNoKontrolu(TCkimlikNo))
            {
                var receteler = DoktorDAL.GetReceteByTCDAL(TCkimlikNo).ToList();

                return receteler;
            }
            else
            {
                return null;
            }


        }
        public static void DoktorReceteYazBLL(string receteTarih, string hastaTC, string recete, string drId)
        {

            if (string.IsNullOrEmpty(receteTarih))
            {
                throw new Exception("Reçete tarihi boş olamaz");
            }
            if (string.IsNullOrEmpty(recete))
            {
                throw new Exception("Reçete boş olamaz");
            }
            if (string.IsNullOrEmpty(hastaTC))
            {
                throw new Exception("Hasta T.C. Kimlik Numarası boş olamaz");
            }

            var receteEkle = new recete()
            {
                recete_tarihi = receteTarih,
                dr_aciklama = recete,
                dr_id = drId
            };

            DoktorDAL.DoktorReceteYazDAL(receteEkle, hastaTC);

        }


        public static List<randevular> GetRandevuTopluBLL(string drId)
        {
            if (!(string.IsNullOrEmpty(drId)))
            {

                var res = DoktorDAL.GetRandevuTopluDAL(drId);
                return res;


            }
            else
            {
                return null;
            }
        }
        public static List<randevular> GetRandevuGunlukBLL(string drId)
        {
            if (!(string.IsNullOrEmpty(drId)))
            {

                var res = DoktorDAL.GetRandevuGunlukDAL(drId);
                return res;

            }
            else
            {
                return null;
            }
        }
        public static void DoktorLaboratuvarSonucGirBLL(string sonucTarih, string hastaTC, string sonuc, string drId)
        {

            if (string.IsNullOrEmpty(sonucTarih))
            {
                throw new Exception("Sonuç tarihi boş olamaz");
            }
            if (string.IsNullOrEmpty(sonuc))
            {
                throw new Exception("Sonuç boş olamaz");
            }
            if (string.IsNullOrEmpty(hastaTC))
            {
                throw new Exception("Hasta T.C. Kimlik Numarası boş olamaz");
            }

            var sonucLab = new lab()
            {
                sonuc_tarihi = sonucTarih,
                lab_sonuc = sonuc,
                dr_id = drId
            };
            DoktorDAL.DoktorLaboratuvarSonucGirDAL(sonucLab, hastaTC);
        }



        public static List<lab> GetLabSonucByTCBLL(string TCkimlikNo)
        {


            var lab = DoktorDAL.GetLabSonucByTCDAL(TCkimlikNo).ToList();

            return lab;


        }

        public static List<doktorlar> GetDoktorBilgiBLL(int drIdent)
        {

            var res = DoktorDAL.GetDoktorBilgiDAL(drIdent);
            return res;

        }
        public static void UpdateDoktorBilgiBLL(doktorlar dr)
        {

            DoktorDAL.UpdateDoktorBilgiDAL(dr);

        }
    }
}
