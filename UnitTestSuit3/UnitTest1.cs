using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HastaneTakipSistemi.HastaneUI;
using HastaneTakipSistemi.HastaneBLL;

namespace UnitTestSuit3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_HastaYatisUcreti()
        {
            HastaneTakipSistemi.HastaneUI.HastaRandevuWindow hr = new HastaneTakipSistemi.HastaneUI.HastaRandevuWindow();

            double toplamUcret=hr.HastaYatisUcreti(10,120);
            Assert.AreEqual(1200,toplamUcret);
        }

        [TestMethod]
        public void HastaMuayeneUcreti()
        {
            HastaneTakipSistemi.HastaneUI.HastaRandevuWindow hr = new HastaneTakipSistemi.HastaneUI.HastaRandevuWindow();

            double toplamUcret = hr.HastaMuayeneUcreti(500, 100);
            Assert.AreNotEqual(1000, toplamUcret);
        }

        [TestMethod]
        public void UcretOdendiMi()
        {
            HastaneTakipSistemi.HastaneUI.HastaRandevuWindow hr = new HastaneTakipSistemi.HastaneUI.HastaRandevuWindow();

            bool odemeBilgisi = hr.UcretOdendiMi(1);
            Assert.IsTrue(odemeBilgisi);
        }

        [TestMethod]
        public void BasarisizGiris()
        {
            HastaneTakipSistemi.HastaneUI.HastaRandevuWindow hr = new HastaneTakipSistemi.HastaneUI.HastaRandevuWindow();

            bool gecerliGiris = hr.BasarisizGiris(0);
            Assert.IsFalse(gecerliGiris);
        }

        [TestMethod]
        public void BoslukDegistir()
        {
            HastaneTakipSistemi.HastaneUI.HastaRandevuWindow hr = new HastaneTakipSistemi.HastaneUI.HastaRandevuWindow();

            string deneme = hr.BoslukDegistir("Test Odevi");
            Assert.ReplaceNullChars(deneme);
        }


        //[TestMethod]
        //public string Doktor()
        //{
        //    HastaneTakipSistemi.HastaneUI.HastaRandevuWindow hr = new HastaneTakipSistemi.HastaneUI.HastaRandevuWindow();
        //    var karsilastir1 = hr.Doktor("Dr. Yılmaz Yıldırım");
        //    var karsilastir2 = "Dr. Güler Yılmaz";

        //    Assert.AreNotSame(karsilastir1,karsilastir2);
        //}
                       
        





    }
}
