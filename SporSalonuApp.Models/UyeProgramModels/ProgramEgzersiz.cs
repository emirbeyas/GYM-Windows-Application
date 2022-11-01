using SporSalonuApp.Models.Base;
using SporSalonuApp.Models.EgzersizModels;
using SporSalonuApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SporSalonuApp.Models.UyeProgramModels
{
    public class ProgramEgzersiz : IModel
    {
        private Egzersiz egzersiz;
        public int Id { get; set; }
        public GunAdi Gun{ get; set; }
        public int ProgramId { get; set; }
        public int EgzersizId { get; set; }
        public Egzersiz Egzersiz { get { return egzersiz; } set { egzersiz = value; EgzersizId = egzersiz.Id; } }
        public int SetAdet { get; set; }
        public int TekrarSayısı { get; set; }

        public string EgzersizAd{ get { return egzersiz.Ad; }}
        public string EgzersizKategori { get { return egzersiz.Kategori.Ad; } }
        public string EgzersizAciklama { get { return egzersiz.Acıklama; } }
        public EgzersizBirimType BirimType { get { return egzersiz.BirimType; } }

        public ProgramEgzersiz()
        {
            egzersiz = new Egzersiz();
        }

        public List<SqlParameter> GetInsertParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@gun", Gun),
                new SqlParameter("@prog_id", ProgramId),
                new SqlParameter("@egzersiz_id", EgzersizId),
                new SqlParameter("@set_adet", SetAdet),
                new SqlParameter("@tekrar_sayisi", TekrarSayısı)
            };
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@prog_egzersiz_id", Id)
            };
            parameters.AddRange(GetInsertParameters());
            return parameters;
        }

        public void ReadItem(IDataRecord record)
        {
            this.Id = Convert.ToInt32(record["prog_egzersiz_id"]);
            this.Gun = (GunAdi)Convert.ToInt32(record["gun"]);
            this.ProgramId = Convert.ToInt32(record["prog_id"]);
            Egzersiz = new Egzersiz();
            Egzersiz.ReadItem(record);
            this.SetAdet = Convert.ToInt32(record["set_adet"]);
            this.TekrarSayısı = Convert.ToInt32(record["tekrar_sayisi"]);
        }
    }
}
