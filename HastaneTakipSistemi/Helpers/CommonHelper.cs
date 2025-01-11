using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneTakipSistemi.Helpers
{
    public class CommonHelper
    {
        public static List<KeyValuePair<string, int>> KlinikBilgisiDoldur()
        {

            var klinikList = new List<KeyValuePair<string, int>>() {
                                                                new KeyValuePair<string, int>("Üroloji", 1),
                                                                new KeyValuePair<string, int>("Göz", 2),
                                                                new KeyValuePair<string, int>("Dahiliye", 3),
                                                                new KeyValuePair<string, int>("Cildiye", 4),
                                                                new KeyValuePair<string, int>("KBB", 5),
                                                                new KeyValuePair<string, int>("İntaniye", 6),
                                                                new KeyValuePair<string, int>("Radyoloji", 7),
                                                                };

            return klinikList;
        }

        public static bool TCKimlikNoKontrolu(string tcKimlikNo)
        {

            if (string.IsNullOrEmpty(tcKimlikNo)) return false; // girilen değer null ya da boş olamaz

            else if (tcKimlikNo.Length != 11) return false; // 11 hanelidir

            else if (tcKimlikNo.StartsWith("0")) return false; // İlk hane 0 olamaz.

            else
            {

                var isValidChars = "0123456789";

                if (tcKimlikNo.Any(a => !isValidChars.Contains(a))) return false; // Her hanesi rakamsal değer içerir.

                var tekHaneliler = 0;
                var ciftHaneliler = 0;
                for (int i = 0; i < 9; i++)
                {
                    var value = Convert.ToInt32(tcKimlikNo[i].ToString());
                    if (i % 2 == 0)
                        tekHaneliler += value;
                    else
                        ciftHaneliler += value;
                }

                if ((((tekHaneliler * 7) - ciftHaneliler) % 10).ToString()
                    != tcKimlikNo[9].ToString()) return false; // 1. 3. 5. 7. ve 9. hanelerin toplamının 7 katından, 2. 4. 6. ve 8. hanelerin toplamı çıkartıldığında, elde edilen sonucun 10’a bölümünden kalan, yani Mod10’u bize 10. haneyi verir.

                if (((tekHaneliler + ciftHaneliler + Convert.ToInt32(tcKimlikNo[9].ToString())) % 10).ToString()
                    != tcKimlikNo[10].ToString()) return false; // 1. 2. 3. 4. 5. 6. 7. 8. 9. ve 10. hanelerin toplamından elde edilen sonucun 10’a bölümünden kalan, yani Mod10’u bize 11. haneyi verir.

            }
            return true;

        }

        public static string TurkceKarakterleriDegistir(string text)
        {
            if (text == null) return text;

            text = text.Replace("Ü", "U");
            text = text.Replace("Ğ", "G");
            text = text.Replace("İ", "I");
            text = text.Replace("Ş", "S");
            text = text.Replace("Ç", "C");
            text = text.Replace("Ö", "O");
            text = text.Replace("ü", "u");
            text = text.Replace("ğ", "g");
            text = text.Replace("ı", "i");
            text = text.Replace("ş", "s");
            text = text.Replace("ç", "c");
            text = text.Replace("ö", "o");

            return text;
        }

        public static int[] NobetProgrami(int hangiAy)
        {
            int[] nobSayiDoktor = new int[10];
            int[] ay;

            if (hangiAy == 1 || hangiAy == 3 || hangiAy == 5
                || hangiAy == 7 || hangiAy == 8 || hangiAy == 10
                || hangiAy == 12)
            {
                ay = new int[31];
            }
            else if (hangiAy == 2)
            {
                ay = new int[28];
            }
            else
            {
                ay = new int[31];
            }

            Random rnd = new Random();

            int fazlaNobet = rnd.Next(0, 10);
            //10 doktora nöbet yazılacak, 31 gün olan aylarda hangisine fazla yazılacağı belirleniyor
            for (int i = 0; i < 10; i++)
            {
                if(i == fazlaNobet)
                {
                    nobSayiDoktor[i] = 4;
                }
                else
                {
                    nobSayiDoktor[i] = 3;
                }
            }

            for (int i = 0; i < ay.Length; i++)
            {
                int nobDoktor = rnd.Next(0, 10);
                int nobDoktorCounter = 0;

                for (int k = 0; k < ay.Length; k++)
                {
                    if(ay[k] == nobDoktor)
                    {
                        nobDoktorCounter++; 
                    }
                }

                if(nobDoktorCounter < nobSayiDoktor[nobDoktor])
                {
                    ay[i] = nobDoktor;
                }
            }

            return ay;    
        }
    }
}
