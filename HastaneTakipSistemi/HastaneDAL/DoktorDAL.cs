using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneTakipSistemi.HastaneDAL
{
    public class DoktorDAL
    {
        public static List<doktorlar> GetDoktorKimlikByIdDAL(int doktorId)
        {
            using (var ctx = new htoEntities())
            {

                var doktorKimlik = ctx.doktorlar.Where(x => x.dr_id == doktorId).ToList();
                return doktorKimlik;


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

        public static void DoktorReceteYazDAL(recete recetes, string hastaTC)
        {
            using (var ctx = new htoEntities())
            {
                var hastaId = ctx.hastalar.Where(x => string.Equals(x.hasta_tc, hastaTC)).ToList().FirstOrDefault();

                recetes.hasta_id = hastaId.hasta_id.ToString();
                //recetes.hasta_id = hastaId;  Select(x => x.hasta_id)
                ctx.recete.Add(recetes);
                ctx.SaveChanges();


            }
        }
        public static List<randevular> GetRandevuTopluDAL(string drId)
        {

            using (var ctx = new htoEntities())
            {
                var randevuList = ctx.Database.SqlQuery<randevular>("Select r.randevu_id,r.randevu_tarihi,r.randevu_saati," +
                    "CONCAT(d.dr_ad,' ',dr_soyad) as dr_id,CONCAT(h.hasta_ad,' ',h.hasta_soyad) as hasta_id, " +
                    "k.klinik_ismi as klinik_id from randevular r inner join hastalar h on r.hasta_id = h.hasta_id " +
                    "inner join doktorlar d on r.dr_id=d.dr_id inner join klinikler k on r.klinik_id = k.klinik_id where r.dr_id = @Id " +
                    "ORDER BY r.randevu_tarihi DESC",
                    new SqlParameter("@Id", drId)).ToList();

                return randevuList;
            }

        }
        public static List<randevular> GetRandevuGunlukDAL(string drId)
        {

            using (var ctx = new htoEntities())
            {
                var randevuList = ctx.Database.SqlQuery<randevular>("Select r.randevu_id,r.randevu_tarihi,r.randevu_saati," +
                    "CONCAT(d.dr_ad,' ',dr_soyad) as dr_id,CONCAT(h.hasta_ad,' ',h.hasta_soyad) as hasta_id, " +
                    "k.klinik_ismi as klinik_id from randevular r inner join hastalar h on r.hasta_id = h.hasta_id " +
                    "inner join doktorlar d on r.dr_id=d.dr_id inner join klinikler k on r.klinik_id = k.klinik_id where r.dr_id = @Id " +
                    "and r.randevu_tarihi = convert(varchar, getdate(), 23) ORDER BY r.randevu_tarihi DESC",
                    new SqlParameter("@Id", drId)).ToList();
                return randevuList;
            }

        }
        public static void DoktorLaboratuvarSonucGirDAL(lab sonuc, string hastaTC)
        {
            using (var ctx = new htoEntities())
            {

                var hastaId = ctx.hastalar.Where(x => string.Equals(x.hasta_tc, hastaTC)).ToList().FirstOrDefault();

                sonuc.hasta_id = hastaId.hasta_id.ToString();
                //recetes.hasta_id = hastaId;  Select(x => x.hasta_id)
                ctx.lab.Add(sonuc);
                ctx.SaveChanges();

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

        public static List<doktorlar> GetDoktorBilgiDAL(int drIdent)
        {
            using (var ctx = new htoEntities())
            {

                var res = ctx.doktorlar.Where(x => x.dr_id == drIdent).ToList();
                return res;

            }
        }

        public static void UpdateDoktorBilgiDAL(doktorlar dr)
        {
            using (var ctx = new htoEntities())
            {

                doktorlar res = ctx.doktorlar.Where(x => x.dr_id == dr.dr_id).FirstOrDefault();
                if (res != null)
                {
                    res.dr_id = res.dr_id;
                    res.dr_ad = dr.dr_ad;
                    res.dr_tc = res.dr_tc;
                    res.dr_alan = res.dr_alan;
                    res.dr_klinik = dr.dr_klinik;
                    res.dr_dogum = dr.dr_dogum;
                    res.dr_cins = dr.dr_cins;
                    res.dr_sifre = dr.dr_sifre;
                    res.dr_il = dr.dr_il;
                    res.dr_ilçe = dr.dr_ilçe;
                    res.dr_tel = dr.dr_tel;
                    res.dr_soyad = dr.dr_soyad;
                    res.email = res.email;

                    ctx.doktorlar.Attach(res);
                    ctx.Entry(res).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                }

            }
        }
        //    (int drIdent)
        //    {
        //        using (var ctx = new htoEntities())
        //        {
        //            try
        //            {
        //                var res = ctx.doktorlar.Where(x => x.dr_id == drIdent).ToList();
        //                return res;
        //            }
        //            catch (Exception)
        //            {
        //                throw new Exception();
        //            }
        //        }
        //    }
        //}
    }
}
