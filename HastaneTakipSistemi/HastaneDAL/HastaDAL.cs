using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneTakipSistemi.HastaneDAL
{
    public class HastaDAL
    {
        public static List<hastalar> GetHastaKimlikByIdDAL(int hastaId)
        {
            using (var ctx = new htoEntities())
            {
                try
                {
                    var hastaKimlik = ctx.hastalar.Where(x => x.hasta_id == hastaId).ToList();
                    return hastaKimlik;
                }
                catch (Exception)
                {

                    throw new Exception();
                }
            }
        }



        public static List<randevular> GetRandevuTopluDAL(string hastaId)
        {
            try
            {
                using (var ctx = new htoEntities())
                {
                    var randevuList = ctx.Database.SqlQuery<randevular>("Select r.randevu_id,r.randevu_tarihi,r.randevu_saati," +
                        "CONCAT(d.dr_ad,' ',dr_soyad) as dr_kimlik,CONCAT(h.hasta_ad,' ',h.hasta_soyad) as hasta_kimlik, " +
                        "k.klinik_ismi as klinik_ad from randevular r inner join hastalar h on r.hasta_id = h.hasta_id " +
                        "inner join doktorlar d on r.dr_id=d.dr_id inner join klinikler k on r.klinik_id = k.klinik_id where r.hasta _id = @Id " +
                        "ORDER BY r.randevu_tarihi DESC",
                        new SqlParameter("@Id", hastaId)).ToList();

                    return randevuList;
                }

            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public static void UpdateHastaBilgiDAL(hastalar hasta)
        {
            using (var ctx = new htoEntities())
            {
                try
                {
                    hastalar res = ctx.hastalar.Where(x => x.hasta_id == hasta.hasta_id).FirstOrDefault();
                    if (res != null)
                    {
                        res.hasta_id = res.hasta_id;
                        res.hasta_ad = hasta.hasta_ad;
                        res.hasta_tc = res.hasta_tc;
                        res.hasta_dogum = hasta.hasta_dogum;
                        res.hasta_cins = hasta.hasta_cins;
                        res.hasta_sifre = hasta.hasta_sifre;
                        res.hasta_il = hasta.hasta_il;
                        res.hasta_ilce = hasta.hasta_ilce;
                        res.hasta_tel = hasta.hasta_tel;
                        res.hasta_soyad = hasta.hasta_soyad;

                        ctx.hastalar.Attach(res);
                        ctx.Entry(res).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
        }

        public static List<hastalar> GetHastaBilgiDAL(int hastaIdent)
        {
            using (var ctx = new htoEntities())
            {
                try
                {
                    var res = ctx.hastalar.Where(x => x.hasta_id == hastaIdent).ToList();
                    return res;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
        }

        public static void HastaRandevuKaydetDAL(randevular kayit, string hasta_id)
        {

            using (var ctx = new htoEntities())
            {
                try
                {
                    var hastaId = ctx.hastalar.Where(x => string.Equals(x.hasta_id, hasta_id)).ToList().FirstOrDefault();

                    kayit.hasta_id = hasta_id.ToString();
                    ctx.randevular.Add(kayit);
                    ctx.SaveChanges();

                }
                catch (Exception)
                {
                    throw new Exception();
                }

            }
        }
    }

}
