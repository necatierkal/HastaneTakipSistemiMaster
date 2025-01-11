using HastaneTakipSistemi.HastaneDAL;
using HastaneTakipSistemi.HastaneUI.DoktorUI;
using HastaneTakipSistemi.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using CollectionAssert = Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert;
using StringAssert = Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert;

namespace UnitTestSuit1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FazlaBosluklarSilinmeli()
        {
            //Arrange
            string ifade = "    Ahmet   Mehmet     ÖZDEMİR     ";
            string beklenen = "Ahmet Mehmet ÖZDEMİR";

            //Act
            string gerceklesen = StringHelper.FazlaBoslukSil(ifade);

            //Assert
            Assert.AreEqual(beklenen, gerceklesen);
        }

        [TestMethod]
        public void KlinikVerileriDogruDolmalı()
        {
            //Arrange
            List<KeyValuePair<string,int>>beklenen = new List<KeyValuePair<string,int>>();
            beklenen.Add(new KeyValuePair<string, int>("Dahiliye", 3));
            beklenen.Add(new KeyValuePair<string, int>("KBB", 5));
            beklenen.Add(new KeyValuePair<string, int>("Radyoloji", 7));
            beklenen.Add(new KeyValuePair<string, int>("Üroloji", 1));
            beklenen.Add(new KeyValuePair<string, int>("Göz", 2));
            beklenen.Add(new KeyValuePair<string, int>("İntaniye", 6));
            beklenen.Add(new KeyValuePair<string, int>("Cildiye", 4));

            //List<doktorlar> dr = new List<doktorlar>();

            //Act
            
            List<KeyValuePair<string, int>> gerceklesen = CommonHelper.KlinikBilgisiDoldur();

            //Assert
            CollectionAssert.AreEquivalent(beklenen, gerceklesen);
        }

        [TestMethod]
        public void GirilenTCKimlikNoSartlariSaglamali()
        {
            //Arrange
            string TCKimlikNo = "69392664948";


            //Act
            bool sonuc = CommonHelper.TCKimlikNoKontrolu(TCKimlikNo);

            //Assert
            Assert.IsTrue(sonuc);
        }

        [TestMethod]
        public void GirilenTCKimlikNoSartlariSaglamamali()
        {
            //Arrange
            string TCKimlikNo = "111111 11111";


            //Act
            bool sonuc = CommonHelper.TCKimlikNoKontrolu(TCKimlikNo);

            //Assert
            Assert.IsFalse(sonuc);
        }
       
        [TestCase("Ü", "[Ü]")]
        [TestCase("Ğ", "[Ğ]")]
        [TestCase("İ", "[İ]")]
        [TestCase("Ş", "[Ş]")]
        [TestCase("Ç", "[Ç]")]
        [TestCase("Ö", "[Ö]")]
        [TestCase("ü", "[ü]")]
        [TestCase("ğ", "[ğ]")]
        [TestCase("ı", "[ı]")]
        [TestCase("ş", "[ş]")]
        [TestCase("ç", "[ç]")]
        [TestCase("ö", "[ö]")]
        public void TurkceKarakterlerDegismeli(string ifade,string regex) //parametrized test
        {
            //Arrange
          
            //Act
            string degisen = CommonHelper.TurkceKarakterleriDegistir(ifade);
            Regex rgx = new Regex(regex);
            
            //Assert
            StringAssert.DoesNotMatch(degisen, rgx);
            
        }

        [TestMethod]
        public void NobetlerDogruYazilmali()
        {
            //Arrange
            int ay = 1;
            int[] doktorlar = {0,1,2,3,4,5,6,7,8,9};

            //Act
            int[] sonuc = CommonHelper.NobetProgrami(ay);
            int[] nobSayi = new int[10];

            for (int i = 0; i < sonuc.Length; i++)
            {
                int count = 0;

                for (int j = 0; j < sonuc.Length; j++)
                {
                    if(i == j)
                    {
                        count++;
                    }
                }
                nobSayi[sonuc[i]] = count;
            }
            //Assert
            CollectionAssert.AllItemsAreNotNull(sonuc);
            Assert.AreEqual(nobSayi[0], 3, 4);
            Assert.AreEqual(nobSayi[1], 3, 4);
            Assert.AreEqual(nobSayi[4], 3, 4);
        }

    }

}
