using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HastaneTakipSistemi.HastaneDAL;

namespace HastaneTakipSistemi.HastaneBLL
{
    public class HastaBLL
    {
        public static List<hastalar> GetHastaKimlikByIdBLL(int hastaId)
        {
            try
            {
                var hasta = HastaDAL.GetHastaKimlikByIdDAL(hastaId).ToList();

                return hasta;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public static List<randevular> GetRandevuListBLL(string hastaId)
        {
            if (!(string.IsNullOrEmpty(hastaId)))
            {
                try
                {
                    var res = HastaDAL.GetRandevuTopluDAL(hastaId);
                    return res;
                }
                catch (Exception)
                {

                    throw new Exception();
                }
            }
            else
            {
                return null;
            }
        }

        public static void UpdateHastaBilgiBLL(hastalar hasta)
        {
            try
            {
                HastaDAL.UpdateHastaBilgiDAL(hasta);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public static List<hastalar> GetHastaBilgiBLL(int hastaIdent)
        {
            try
            {
                var res = HastaDAL.GetHastaBilgiDAL(hastaIdent);
                return res;
            }
            catch (Exception)
            {

                throw new Exception();
            }

        }

        public static void HastaRandevuKaydetBLL(string randevu_saati, string randevu_tarihi, string dr_id, string hasta_id, string klinik_id)
        {
            try
            {
                randevular kayit = new randevular()
                {
                    randevu_saati = randevu_saati,
                    randevu_tarihi = randevu_tarihi,
                    dr_id = dr_id,
                    klinik_id = klinik_id
               
                };
                HastaDAL.HastaRandevuKaydetDAL(kayit, hasta_id);
            
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }          
    

     }

    
}
