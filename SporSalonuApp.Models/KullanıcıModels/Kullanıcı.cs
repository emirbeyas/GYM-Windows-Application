using SporSalonuApp.Models.Base;
using SporSalonuApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuApp.Models.KullanıcıModels
{
    public class Kullanıcı : IModel
    {
        /// <summary>
        /// Bu Model Bu Özellik KULLANILMIYOR
        /// </summary>
        public int Id { get; set; } = -1;
        public string KullanıcıAdı { get; set; }
        public string Parola { get; set; }
        public KullanıcıType Tip { get; set; } = KullanıcıType.User;
        public string Ad { get; set; }
        public string Soyad { get; set; }

        /// <summary>
        /// Kullanıcı Yetkileri bu listede
        /// </summary>
        public List<KullanıcıYetki> Yetkiler { get; set; } = new List<KullanıcıYetki>();

        public List<SqlParameter> GetInsertParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@kullanici_adi", this.KullanıcıAdı),
                new SqlParameter("@parola", this.Parola),
                new SqlParameter("@kullanici_type", this.Tip),
                new SqlParameter("@ad", this.Ad),
                new SqlParameter("@soyad", this.Soyad)
            };
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            return GetInsertParameters();
        }

        public void ReadItem(IDataRecord record)
        {
            this.KullanıcıAdı = record["kullanici_adi"].ToString();
            this.Parola = record["parola"].ToString();
            this.Tip = (KullanıcıType)Convert.ToInt32(record["kullanici_type"]);
            this.Ad = record["ad"].ToString();
            this.Soyad = record["soyad"].ToString();
        }

        public void SetKullanıcı(Kullanıcı kullanıcı)
        {
            this.Ad = kullanıcı.Ad;
            this.Soyad = kullanıcı.Soyad;
            this.Parola = kullanıcı.Parola;
            this.Tip = kullanıcı.Tip;
            this.KullanıcıAdı = kullanıcı.KullanıcıAdı;
            this.Yetkiler = kullanıcı.Yetkiler;
        }
        public Kullanıcı CopyObject()
        {
            return  (Kullanıcı)this.MemberwiseClone();
        }
    }
}
