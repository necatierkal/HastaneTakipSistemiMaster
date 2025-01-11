using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneTakipSistemi.HastaneDAL
{
    public class HemsireDAL
    {
        public static List<hemsireler> GetHemsireKimlikByIdDAL(int hemsireId)
        {
            using (var ctx = new htoEntities())
            {

                var hemsireKimlik = ctx.hemsireler.Where(x => x.hemsire_id == hemsireId).ToList();
                return hemsireKimlik;

            }
        }
        public static List<randevular> GetRandevuTopluDAL(string hemsireId)
        {

            using (var ctx = new htoEntities())
            {
                var randevuList = ctx.Database.SqlQuery<randevular>("Select r.randevu_id,r.randevu_tarihi,r.randevu_saati," +
                    "CONCAT(d.dr_ad,' ',dr_soyad) as dr_id,CONCAT(h.hasta_ad,' ',h.hasta_soyad) as hasta_id, " +
                    "k.klinik_ismi as klinik_id from randevular r inner join hastalar h on r.hasta_id = h.hasta_id " +
                    "inner join doktorlar d on r.dr_id=d.dr_id inner join klinikler k on r.klinik_id = k.klinik_id " +
                    "ORDER BY r.randevu_tarihi DESC").ToList();
                return randevuList;
            }


        }
        public static List<randevular> GetRandevuGunlukDAL(string hemsireId)
        {

            using (var ctx = new htoEntities())
            {
                var randevuList = ctx.Database.SqlQuery<randevular>("Select r.randevu_id,r.randevu_tarihi,r.randevu_saati,CONCAT(d.dr_ad,' ',dr_soyad) as dr_id," +
                    "CONCAT(h.hasta_ad,' ',h.hasta_soyad) as hasta_id, k.klinik_ismi as klinik_id from randevular r " +
                    "inner join hastalar h on r.hasta_id = h.hasta_id inner join doktorlar d on r.dr_id=d.dr_id inner join klinikler k" +
                    " on r.klinik_id = k.klinik_id where r.randevu_tarihi = convert(varchar, getdate(), 23) ORDER BY r.randevu_tarihi DESC").ToList();
                return randevuList;
            }

        }
        public static List<randevular> GetRandevuKisiDAL(string hemsireId, string TCKimlik)
        {

            using (var ctx = new htoEntities())
            {
                var randevuList = ctx.Database.SqlQuery<randevular>("Select r.randevu_id,r.randevu_tarihi,r.randevu_saati,CONCAT(d.dr_ad,' ',dr_soyad) as dr_id," +
                    "CONCAT(h.hasta_ad,' ',h.hasta_soyad) as hasta_id, k.klinik_ismi as klinik_id from randevular r inner join " +
                    "hastalar h on r.hasta_id = h.hasta_id inner join doktorlar d on r.dr_id=d.dr_id inner join " +
                    "klinikler k on r.klinik_id = k.klinik_id where h.hasta_tc = @TC ORDER BY r.randevu_tarihi DESC",
                    new SqlParameter("@TC", TCKimlik)).ToList();
                return randevuList;
            }

        }
        public static List<recete> GetReceteByTCDAL(string TCkimlikNo)
        {
            using (var ctx = new htoEntities())
            {

                var hastaId = ctx.hastalar.Where(x => string.Equals(x.hasta_tc, TCkimlikNo)).ToList().FirstOrDefault();
                var receteler = ctx.recete.Where(x => string.Equals(x.hasta_id, hastaId.hasta_id.ToString())).ToList();
                return receteler;

            }
        }
        public static List<lab> GetLabSonucByTCDAL(string TCkimlikNo)
        {
            using (var ctx = new htoEntities())
            {

                var hastaId = ctx.hastalar.Where(x => string.Equals(x.hasta_tc, TCkimlikNo)).ToList().FirstOrDefault();
                var lab = ctx.lab.Where(x => string.Equals(x.hasta_id, hastaId.hasta_id.ToString())).ToList();
                return lab;

            }
        }

        public static List<hemsireler> GetHemsireBilgiDAL(int hemsireId)
        {
            using (var ctx = new htoEntities())
            {

                var res = ctx.hemsireler.Where(x => x.hemsire_id == hemsireId).ToList();
                return res;

            }
        }

        public static void UpdateHemsireBilgiDAL(hemsireler hemsire)
        {
            using (var ctx = new htoEntities())
            {

                hemsireler res = ctx.hemsireler.Where(x => x.hemsire_id == hemsire.hemsire_id).FirstOrDefault();
                if (res != null)
                {
                    res.hemsire_id = res.hemsire_id;
                    res.hemsire_ad = hemsire.hemsire_ad;
                    res.hemsire_tc = res.hemsire_tc;
                    res.hemsire_alan = hemsire.hemsire_alan;
                    //res.dr_klinik = dr.dr_klinik;
                    res.hemsire_dogum = hemsire.hemsire_dogum;
                    res.hemsire_cins = hemsire.hemsire_cins;
                    res.hemsire_sifre = hemsire.hemsire_sifre;
                    res.hemsire_il = hemsire.hemsire_il;
                    res.hemsire_ilçe = hemsire.hemsire_ilçe;
                    res.hemsire_tel = hemsire.hemsire_tel;
                    res.hemsire_soyad = hemsire.hemsire_soyad;
                    res.email = res.email;

                    ctx.hemsireler.Attach(res);
                    ctx.Entry(res).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                }

            }
        }
    }
}
