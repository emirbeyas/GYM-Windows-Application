using SporSalonuApp.DatabaseAccess.Abstracations.Repositories;
using SporSalonuApp.DatabaseAccess.DatabaseContext;
using SporSalonuApp.Models.OdemeModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SporSalonuApp.DatabaseAccess.Repositories
{
    public enum OdemeSıralamaTypes
    {
        AdaGoreArtan = 1,
        AdaGoreAzalan = 2,
        TariheGoreArtan = 3,
        TariheGoreAzalan = 4
    }

    public class OdemeRepo : ARepository<Odeme>
    {
        public OdemeRepo(DBContext context) : base(context) { }

        public override List<Odeme> ToList()
        {
            using(SqlCommand cmd = context.CreateCommand("sp_odeme_listele"))
            {
                cmd.Parameters.AddWithValue("@sırala", OdemeSıralamaTypes.AdaGoreArtan);
                return context.ToList<Odeme>(cmd);
            }
        }

        public List<Odeme> ToList(OdemeSıralamaTypes sıralama, int uyeId, DateTime? alt = null, DateTime? ust = null)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_odeme_listele"))
            {
                cmd.Parameters.AddWithValue("@sırala", sıralama);
                if (uyeId != 0)
                    cmd.Parameters.AddWithValue("@uye_id", uyeId);
                if (alt != null && ust != null)
                {
                    cmd.Parameters.AddWithValue("@alt", alt);
                    cmd.Parameters.AddWithValue("@ust", ust);
                }

                return context.ToList<Odeme>(cmd);
            }
        }

        public override object Add(Odeme item)
        {
            using(SqlCommand cmd = context.CreateCommand("sp_odeme_ekle", item.GetInsertParameters()))
            {
                return context.ExecuteScalar(cmd);
            }
        }

        public override Odeme GetItem(object key)
        {
            using(SqlCommand cmd = context.CreateCommand("sp_odeme_get"))
            {
                cmd.Parameters.AddWithValue("@odeme_id", key);
                return context.GetItem<Odeme>(cmd);
            }
        }

        public override int Remove(object key)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_odeme_sil"))
            {
                cmd.Parameters.AddWithValue("@odeme_id", key);
                return context.ExecuteNonQuery(cmd);
            }
        }

        public override int Remove(Odeme item)
        {
            return Remove(item.Id);
        }

        public override int Update(Odeme item)
        {
            using(SqlCommand cmd = context.CreateCommand("sp_odeme_guncelle", item.GetUpdateParameters()))
            {
                return context.ExecuteNonQuery(cmd);
            }
        }
    }
}
