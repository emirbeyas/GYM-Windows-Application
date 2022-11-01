using SporSalonuApp.Models.Base;
using SporSalonuApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuApp.Models.EgzersizModels
{
    public class Egzersiz : IModel
    {
        private EgzersizKategori kategori;

        public int Id { get; set; }

        public string Ad { get; set; }
        public int KatId { get; set; }
        public EgzersizKategori Kategori
        {
            get { return kategori; }
            set { kategori = value; KatId = kategori.Id; }
        }
        public EgzersizBirimType BirimType { get; set; }
        public string Acıklama { get; set; }

        public string KategoriAd { get { return kategori.Ad; } }

        public Egzersiz()
        {
            kategori = new EgzersizKategori();
        }

        public List<SqlParameter> GetInsertParameters()
        {
            return new List<SqlParameter> {
                new SqlParameter("@egzersiz_ad", this.Ad),
                new SqlParameter("@kat_id", this.KatId),
                new SqlParameter("@aciklama", this.Acıklama),
                new SqlParameter("@birim_type", BirimType)
            };
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> items = new List<SqlParameter> { new SqlParameter("@egzersiz_id", this.Id) };
            items.AddRange(GetInsertParameters());
            return items;
        }

        public void ReadItem(IDataRecord record)
        {
            this.Id = Convert.ToInt32(record["egzersiz_id"]);
            this.Ad = record["egzersiz_ad"] == DBNull.Value ? string.Empty : record["egzersiz_ad"].ToString();
            //kategori okunacak
            EgzersizKategori kat = new EgzersizKategori();
            kat.ReadItem(record);

            this.Kategori = kat;
            this.Acıklama = record["aciklama"].ToString();
            BirimType = (EgzersizBirimType)Convert.ToInt32(record["birim_type"]);
        }
    }
}
