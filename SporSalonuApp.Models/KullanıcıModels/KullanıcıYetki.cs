using SporSalonuApp.Models.Base;
using SporSalonuApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuApp.Models.KullanıcıModels
{
    public class KullanıcıYetki : IModel
    {
        /// <summary>
        /// Bu Model Bu Özellik KULLANILMIYOR
        /// </summary>
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string KullanıcıAdı { get; set; }
        public DbTablo Tablo{ get; set; }
        public YetkiIslem Islem{ get; set; }
        public bool YetkiliMi { get; set; }

        public List<SqlParameter> GetInsertParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@kullanici_adi", this.KullanıcıAdı),
                new SqlParameter("@tablo_type", this.Tablo),
                new SqlParameter("@islem_type", this.Islem),
                new SqlParameter("@yetki_durum", this.YetkiliMi)
            };
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            return GetInsertParameters();
        }

        public void ReadItem(IDataRecord record)
        {
            this.KullanıcıAdı = record["kullanici_adi"].ToString();
            this.Tablo = (DbTablo)Convert.ToInt32(record["tablo_type"]);
            this.Islem = (YetkiIslem)Convert.ToInt32(record["islem_type"]);
            this.YetkiliMi = Convert.ToBoolean(record["yetki_durum"]);
        }
    }
}
