using SporSalonuApp.DatabaseAccess.Abstracations.Repositories;
using SporSalonuApp.DatabaseAccess.DatabaseContext;
using SporSalonuApp.Models.KullanıcıModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuApp.DatabaseAccess.Repositories
{
    public class KullanıcıRepo : ARepository<Kullanıcı>
    {
        public KullanıcıRepo(DBContext context) : base(context) { }

        public override List<Kullanıcı> ToList()
        {
            using (SqlCommand cmd = context.CreateCommand("sp_kullanici_listele"))
            {
                return context.ToList<Kullanıcı>(cmd);
            }
        }

        public override object Add(Kullanıcı item)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_kullanici_ekle", item.GetInsertParameters()))
            {
                return context.ExecuteNonQuery(cmd);
            }
        }

        public override Kullanıcı GetItem(object key)
        {
            try
            {
                Kullanıcı item = new Kullanıcı();

                using (SqlCommand cmd = context.CreateCommand("sp_kullanici_get"))
                {
                    cmd.Parameters.AddWithValue("@kullanici_adi", key);
                    context.OpenConnection();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                            item.ReadItem(reader);
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                KullanıcıYetki yetki = new KullanıcıYetki();
                                yetki.ReadItem(reader);
                                item.Yetkiler.Add(yetki);
                            }
                        }
                    }
                    reader.Close();
                    context.CloseConnection();

                    return item;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override int Remove(object key)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_kullanici_sil"))
            {
                cmd.Parameters.AddWithValue("@kullanici_adi", key);
                return context.ExecuteNonQuery(cmd);
            }
        }

        public override int Remove(Kullanıcı item)
        {
            return Remove(item.KullanıcıAdı);
        }

        public override int Update(Kullanıcı item)
        {
            throw new Exception("Kullanıcı adının değişme ihtimaline karşılık. Eski kullanıcı adı gerekli");
        }

        public int Update(Kullanıcı item, string eski_kullanıcıAdı)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_kullanici_guncelle", item.GetUpdateParameters()))
            {
                cmd.Parameters.AddWithValue("@old_kullanici_adi", eski_kullanıcıAdı);
                return context.ExecuteNonQuery(cmd);
            }
        }

        public int YetkiGuncelle(KullanıcıYetki item)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_kullanici_yetki_guncelle", item.GetUpdateParameters()))
            {
                return context.ExecuteNonQuery(cmd);
            }
        }

        public bool Login(string kullannıcıadı, string parola)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_kullanici_login"))
            {
                cmd.Parameters.AddWithValue("@kullanici_adi", kullannıcıadı);
                cmd.Parameters.AddWithValue("@parola", parola);

                return Convert.ToBoolean(context.ExecuteScalar(cmd));
            }
        }
    }
}
