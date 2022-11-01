using SporSalonuApp.DatabaseAccess.Abstracations.Repositories;
using SporSalonuApp.DatabaseAccess.DatabaseContext;
using SporSalonuApp.Models.UyeModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuApp.DatabaseAccess.Repositories
{
    public class UyeOlcuRepo : ARepository<UyeOlcu>
    {
        public UyeOlcuRepo(DBContext context) : base(context){}

        public override List<UyeOlcu> ToList()
        {
            //procedure yok yazılabilir belki...
            throw new NotImplementedException();
        }

        public List<UyeOlcu> ToList(int uye_id)
        {
            using(SqlCommand cmd = context.CreateCommand("sp_uyeolcu_list_uye"))
            {
                cmd.Parameters.AddWithValue("@uye_id", uye_id);
                return context.ToList<UyeOlcu>(cmd);
            }
        }

        public override object Add(UyeOlcu item)
        {
            using(SqlCommand cmd = context.CreateCommand("sp_uyeolcu_ekle", item.GetInsertParameters()))
            {
                return context.ExecuteScalar(cmd);
            }
        }

        public override UyeOlcu GetItem(object key)
        {
            using(SqlCommand cmd = context.CreateCommand("sp_uyeolcu_get"))
            {
                cmd.Parameters.AddWithValue("@olcu_id", key);
                return context.GetItem<UyeOlcu>(cmd);
            }
        }

        public override int Remove(object key)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_uyeolcu_sil"))
            {
                cmd.Parameters.AddWithValue("@olcu_id", key);
                return context.ExecuteNonQuery(cmd);
            }
        }

        public override int Remove(UyeOlcu item)
        {
            return Remove(item.Id);
        }

        public override int Update(UyeOlcu item)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_uyeolcu_guncelle", item.GetUpdateParameters()))
            {
                return context.ExecuteNonQuery(cmd);
            }
        }
    }
}
