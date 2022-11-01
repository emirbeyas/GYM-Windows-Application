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
    public class EgzersizKategoriRepo : ARepository<EgzersizKategori>
    {
        public EgzersizKategoriRepo(DBContext context):base(context){}

        public override List<EgzersizKategori> ToList()
        {
            using(SqlCommand cmd = context.CreateCommand("sp_egzersizKategori_listele"))
            {
                return context.ToList<EgzersizKategori>(cmd);
            }
        }

        //public List<EgzersizKategori> ToList()
        //{
        //    using (SqlCommand cmd = context.CreateCommand("sp_egzersizKategori_listele"))
        //    {
        //        return context.ToList<EgzersizKategori>(cmd);
        //    }
        //}

        public override object Add(EgzersizKategori item)
        {
            using(SqlCommand cmd = context.CreateCommand("sp_egzersizKategori_ekle", item.GetInsertParameters()))
            {
                return context.ExecuteScalar(cmd);
            }
        }

        public override EgzersizKategori GetItem(object key)
        {
            using(SqlCommand cmd = context.CreateCommand("sp_egzersizKategori_get"))
            {
                cmd.Parameters.AddWithValue("@kat_id", key);
                return context.GetItem<EgzersizKategori>(cmd);
            }
        }

        public override int Remove(object key)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_egzersizKategori_sil"))
            {
                cmd.Parameters.AddWithValue("@kat_id", key);
                return context.ExecuteNonQuery(cmd);
            }
        }

        public override int Remove(EgzersizKategori item)
        {
            return Remove(item.Id);
        }

        public override int Update(EgzersizKategori item)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_egzersizKategori_guncelle", item.GetUpdateParameters()))
            {
                return context.ExecuteNonQuery(cmd);
            }
        }
    }
}
