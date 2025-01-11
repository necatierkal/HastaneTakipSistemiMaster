using HastaneTakipSistemi.HastaneDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneTakipSistemi.HastaneBLL
{
    public class LoginBLL
    {
        public static bool KullaniciKontrolBLL(int kullaniciAdi, string sifre, int kullaniciTip)
        {
            if (kullaniciTip == 0)
            {
                var res = LoginDAL.KullaniciDoktorKontrolDAL(kullaniciAdi, sifre);

                if (res == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (kullaniciTip == 1)
            {
                var res = LoginDAL.KullaniciHemsireKontrolDAL(kullaniciAdi, sifre);

                if (res == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (kullaniciTip == 2)
            {
                var res = LoginDAL.KullaniciHastaKontrolDAL(kullaniciAdi, sifre);

                if (res == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
