using SporSalonuApp.DatabaseAccess.Abstracations.Repositories;
using SporSalonuApp.DatabaseAccess.DatabaseContext;
using SporSalonuApp.Models.EgzersizModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuApp.DatabaseAccess.Repositories
{
    public class EgzersizRepo : ARepository<Egzersiz>
    {
        public EgzersizRepo(DBContext context) : base(context){}

        public override List<Egzersiz> ToList()
        {
            using(SqlCommand cmd = context.CreateCommand("sp_egzersiz_listele"))
            {
                return context.ToList<Egzersiz>(cmd);
            }
        }

        public List<Egzersiz> ToList(int kat_id = 0, string egzersiz_ad = null)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_egzersiz_listele"))
            {
                if (kat_id != 0)
                    cmd.Parameters.AddWithValue("@kat_id", kat_id);
                if (!String.IsNullOrEmpty(egzersiz_ad))
                    cmd.Parameters.AddWithValue("@egzersiz_ad", egzersiz_ad);
                return context.ToList<Egzersiz>(cmd);
            }
        }

        public List<Egzersiz> ToList(int kat_id)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_egzersiz_listele_kategori"))
            {
                cmd.Parameters.AddWithValue("@kat_id", kat_id);
                return context.ToList<Egzersiz>(cmd);
            }
        }

        public override object Add(Egzersiz item)
        {
            using(SqlCommand cmd = context.CreateCommand("sp_egzersiz_ekle", item.GetInsertParameters()))
            {
                return context.ExecuteScalar(cmd);
            }
        }

        public override Egzersiz GetItem(object key)
        {
            using(SqlCommand cmd = context.CreateCommand("sp_egzersiz_get"))
            {
                cmd.Parameters.AddWithValue("@egzersiz_id", key);
                return context.GetItem<Egzersiz>(cmd);
            }
        }

        public override int Remove(object key)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_egzersiz_sil"))
            {
                cmd.Parameters.AddWithValue("@egzersiz_id", key);
                return context.ExecuteNonQuery(cmd);
            }
        }

        public override int Remove(Egzersiz item)
        {
            return Remove(item.Id);
        }

        public override int Update(Egzersiz item)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_egzersiz_guncelle", item.GetUpdateParameters()))
            {
                return context.ExecuteNonQuery(cmd);
            }
        }
    }
}
