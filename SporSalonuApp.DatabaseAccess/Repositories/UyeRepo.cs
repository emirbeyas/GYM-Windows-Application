using SporSalonuApp.DatabaseAccess.Abstracations.Repositories;
using SporSalonuApp.DatabaseAccess.DatabaseContext;
using SporSalonuApp.Models.UyeModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Net.Configuration;

namespace SporSalonuApp.DatabaseAccess.Repositories
{
    public enum UyeSıralamaTypes
    {
        AdaGoreArtan = 1, //desc
        AdaGoreAzalan,
        SoyadaGoreArtan,
        SoyadaGoreAzalan,
        KayıtTarihineGoreArtan,
        KayıtTarihineGoreAzalan,
        UyelikSonTarihineGoreArtan,
        UyelikSonTarihineGoreAzalan
    }

    public class UyeRepo : ARepository<Uye>
    {
        public UyeRepo(DBContext context) : base(context) { }

        public override List<Uye> ToList()
        {
            using (SqlCommand cmd = context.CreateCommand("sp_uye_listele"))
            {
                return context.ToList<Uye>(cmd);
            }
        }
        public List<Uye> ToList(UyeSıralamaTypes sırala, string ad = null, string soyad = null, string telno = null)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_uye_listele"))
            {
                if (!String.IsNullOrEmpty(ad))
                    cmd.Parameters.AddWithValue("@ad", ad);
                if (!String.IsNullOrEmpty(soyad))
                    cmd.Parameters.AddWithValue("@soyad", soyad);
                if (!String.IsNullOrEmpty(telno))
                    cmd.Parameters.AddWithValue("@tel_no", telno);

                cmd.Parameters.AddWithValue("@sırala",
                    (sırala == UyeSıralamaTypes.AdaGoreArtan) ? "ad ASC" :
                    (sırala == UyeSıralamaTypes.AdaGoreAzalan) ? "ad DESC" :
                    (sırala == UyeSıralamaTypes.KayıtTarihineGoreArtan)? "kayıt_tarih ASC" :
                    (sırala == UyeSıralamaTypes.KayıtTarihineGoreAzalan)? "kayıt_tarih DESC" :
                    (sırala == UyeSıralamaTypes.SoyadaGoreArtan)?"soyad ASC" :
                    (sırala == UyeSıralamaTypes.SoyadaGoreAzalan)? "soyad DESC" :
                    (sırala == UyeSıralamaTypes.UyelikSonTarihineGoreArtan)? "uyelik_son_tarih ASC" : "uyelik_son_tarih DESC");

                return context.ToList<Uye>(cmd);
            }
        }

        public override object Add(Uye item)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_uye_ekle", item.GetInsertParameters()))
            {
                return context.ExecuteScalar(cmd);
            }
        }

        public override Uye GetItem(object key)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_uye_get"))
            {
                cmd.Parameters.AddWithValue("@uye_id", key);
                return context.GetItem<Uye>(cmd);
            }
        }

        public override int Remove(object key)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_uye_sil"))
            {
                cmd.Parameters.AddWithValue("@uye_id", key);
                return context.ExecuteNonQuery(cmd);
            }
        }

        public override int Remove(Uye item)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_uye_sil"))
            {
                cmd.Parameters.AddWithValue("@uye_id", item.Id);
                return context.ExecuteNonQuery(cmd);
            }
        }

        public override int Update(Uye item)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_uye_guncelle", item.GetUpdateParameters()))
            {
                return context.ExecuteNonQuery(cmd);
            }
        }

        public List<Uye> GetBugunAntrenmaniOlanlar()
        {
            using(SqlCommand cmd = context.CreateCommand("sp_bugun_antrenmani_olanlar"))
            {
                return context.ToList<Uye>(cmd);
            }
        }
    }
}
