using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneTakipSistemi.Helpers
{
    public class StringHelper
    {
        public static string FazlaBoslukSil(string metin)
        {
            metin = metin.Trim();

            string yeniMetin = string.Empty;

            for (int i = 0; i < metin.Length; i++)
            {
                if(metin[i] ==' ' && metin[i+1]==' ')
                {
                    continue;
                }

                yeniMetin +=metin[i];
            }

            return yeniMetin;   
        }
    }
}
