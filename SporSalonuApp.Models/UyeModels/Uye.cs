using SporSalonuApp.Models.Base;
using SporSalonuApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuApp.Models.UyeModels
{
    public class Uye : IModel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string AdSoyad { get { return Ad + " " + Soyad; } }
        public DateTime DogumTarih { get; set; } = DateTime.Now;
        public DateTime KayıtTarih { get; set; } = DateTime.Now;
        public DateTime UyelikSonTarih { get; set; } = DateTime.Now;
        public string TelefonNo { get; set; }

        public List<SqlParameter> GetInsertParameters()
        {
            return new List<SqlParameter>{ new SqlParameter("@ad", this.Ad),
                                        new SqlParameter("@soyad", this.Soyad),
                                        new SqlParameter("@dtarih", this.DogumTarih),
                                        new SqlParameter("@kayit_tarih", this.KayıtTarih),
                                        new SqlParameter("@uyelik_son_tarih", this.UyelikSonTarih),
                                        new SqlParameter("@tel_no", this.TelefonNo) };
        }


        public List<SqlParameter> GetUpdateParameters()
        {
            var items = new List<SqlParameter>{ new SqlParameter("@uye_id", this.Id) };
            items.AddRange(GetInsertParameters());
            return items;
        }

        public void ReadItem(IDataRecord record)
        {
            this.Id = Convert.ToInt32(record["uye_id"]);
            this.Ad = record["ad"].ToString();
            this.Soyad = record["soyad"].ToString();
            this.DogumTarih = Convert.ToDateTime(record["dtarih"]);
            this.KayıtTarih = Convert.ToDateTime(record["kayıt_tarih"]);
            this.UyelikSonTarih = Convert.ToDateTime(record["uyelik_son_tarih"]);
            this.TelefonNo = record["tel_no"].ToString();
        }
    }
}
