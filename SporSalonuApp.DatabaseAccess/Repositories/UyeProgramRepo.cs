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
    public class UyeProgramRepo : ARepository<UyeProgram>
    {
        public UyeProgramRepo(DBContext context) : base(context){}
        public override List<UyeProgram> ToList()
        {
            using(SqlCommand cmd = context.CreateCommand("sp_uyeProg_listele_all"))
            {
                return context.ToList<UyeProgram>(cmd);
            }
        }

        public List<UyeProgram> ToList(int uye_id)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_uyeProg_listele"))
            {
                cmd.Parameters.AddWithValue("@uye_id", uye_id);
                return context.ToList<UyeProgram>(cmd);
            }
        }

        public override object Add(UyeProgram item)
        {
            using(SqlCommand cmd = context.CreateCommand("sp_uyeProg_ekle", item.GetInsertParameters()))
            {
                return context.ExecuteScalar(cmd);
            }
        }

        public override UyeProgram GetItem(object key)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_uyeProg_get"))
            {
                cmd.Parameters.AddWithValue("@prog_id", key);
                return context.GetItem<UyeProgram>(cmd);
            }
        }

        public override int Remove(object key)
        {
            using(SqlCommand cmd = context.CreateCommand("sp_uyeProg_sil"))
            {
                cmd.Parameters.AddWithValue("@prog_id", key);
                return context.ExecuteNonQuery(cmd);
            }
        }

        public override int Remove(UyeProgram item)
        {
            return Remove(item.Id);
        }

        public override int Update(UyeProgram item)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_uyeProg_guncelle", item.GetUpdateParameters()))
            {
                return context.ExecuteNonQuery(cmd);
            }
        }
    }
}
