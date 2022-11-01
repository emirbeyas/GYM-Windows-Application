using SporSalonuApp.DatabaseAccess.Abstracations.Repositories;
using SporSalonuApp.DatabaseAccess.DatabaseContext;
using SporSalonuApp.Models.UyeProgramModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuApp.DatabaseAccess.Repositories
{
    public class ProgramEgzersizRepo : ARepository<ProgramEgzersiz>
    {
        public ProgramEgzersizRepo(DBContext context) : base(context) { }
        public override List<ProgramEgzersiz> ToList()
        {
            using (SqlCommand cmd = context.CreateCommand("sp_progEgzersiz_listele_all"))
            {
                return context.ToList<ProgramEgzersiz>(cmd);
            }
        }

        public List<ProgramEgzersiz> ToList(int prog_id)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_progEgzersiz_listele"))
            {
                cmd.Parameters.AddWithValue("@prog_id", prog_id);
                return context.ToList<ProgramEgzersiz>(cmd);
            }
        }
        public override object Add(ProgramEgzersiz item)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_progEgzersiz_ekle", item.GetInsertParameters()))
            {
                return context.ExecuteScalar(cmd);
            }
        }

        public override ProgramEgzersiz GetItem(object key)
        {
            using(SqlCommand cmd = context.CreateCommand("sp_progEgzersiz_get"))
            {
                cmd.Parameters.AddWithValue("@prog_egzersiz_id", key);
                return context.GetItem<ProgramEgzersiz>(cmd);
            }
        }

        public override int Remove(object key)
        {
            using(SqlCommand cmd = context.CreateCommand("sp_progEgzersiz_sil"))
            {
                cmd.Parameters.AddWithValue("@prog_egzersiz_id", key);
                return context.ExecuteNonQuery(cmd);
            }
        }

        public override int Remove(ProgramEgzersiz item)
        {
            return Remove(item.Id);
        }

        public override int Update(ProgramEgzersiz item)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_progEgzersiz_guncelle", item.GetUpdateParameters()))
            {
                return context.ExecuteNonQuery(cmd);
            }
        }
    }
}
