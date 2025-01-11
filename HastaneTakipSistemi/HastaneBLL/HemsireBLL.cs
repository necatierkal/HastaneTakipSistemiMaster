using HastaneTakipSistemi.HastaneDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneTakipSistemi.HastaneBLL
{
    public class HemsireBLL
    {
        public static List<hemsireler> GetHemsireKimlikByIdBLL(int hemsireId)
        {

            var hemsire = HemsireDAL.GetHemsireKimlikByIdDAL(hemsireId).ToList();

            return hemsire;

        }

        public static List<randevular> GetRandevuTopluBLL(string hemsireId)
        {
            if (!(string.IsNullOrEmpty(hemsireId)))
            {

                var res = HemsireDAL.GetRandevuTopluDAL(hemsireId);
                return res;

            }
            else
            {
                return null;
            }
        }

        public static List<randevular> GetRandevuGunlukBLL(string hemsireId)
        {
            if (!(string.IsNullOrEmpty(hemsireId)))
            {

                var res = HemsireDAL.GetRandevuGunlukDAL(hemsireId);
                return res;

            }
            else
            {
                return null;
            }
        }
        public static List<randevular> GetRandevuKisiBLL(string hemsireId, string TCKimlik)
        {
            if (!(string.IsNullOrEmpty(hemsireId)))
            {

                var res = HemsireDAL.GetRandevuKisiDAL(hemsireId, TCKimlik);
                return res;


            }
            else
            {
                return null;
            }
        }
        public static List<recete> GetReceteByTCBLL(string TCkimlikNo)
        {

            var receteler = DoktorDAL.GetReceteByTCDAL(TCkimlikNo).ToList();
            return receteler;



        }
        public static List<lab> GetLabSonucByTCBLL(string TCkimlikNo)
        {

            var lab = HemsireDAL.GetLabSonucByTCDAL(TCkimlikNo).ToList();
            return lab;


        }

        public static List<hemsireler> GetHemsireBilgiBLL(int hemsireId)
        {

            var res = HemsireDAL.GetHemsireBilgiDAL(hemsireId);
            return res;


        }
        public static void UpdateHemsireBilgiBLL(hemsireler hemsire)
        {

            HemsireDAL.UpdateHemsireBilgiDAL(hemsire);


        }
    }
}
