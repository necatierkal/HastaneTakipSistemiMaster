using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneTakipSistemi.HastaneDAL
{
    public class LoginDAL
    {
        public static bool KullaniciDoktorKontrolDAL(int kullaniciAdi, string sifre)
        {
            using(var ctx = new htoEntities())
            {
                var resultSifre = ctx.doktorlar.Where(x=>x.dr_id == kullaniciAdi).Select(x => x.dr_sifre).FirstOrDefault();    

                if (Equals(resultSifre,sifre))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool KullaniciHastaKontrolDAL(int kullaniciAdi, string sifre)
        {
            using (var ctx = new htoEntities())
            {
                var resultSifre = ctx.hastalar.Where(x => x.hasta_id == kullaniciAdi).Select(x => x.hasta_sifre).FirstOrDefault();

                if (Equals(resultSifre, sifre))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool KullaniciHemsireKontrolDAL(int kullaniciAdi, string sifre)
        {
            using (var ctx = new htoEntities())
            {
                var resultSifre = ctx.hemsireler.Where(x => x.hemsire_id == kullaniciAdi).Select(x => x.hemsire_sifre).FirstOrDefault();

                if (Equals(resultSifre, sifre))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
