using SporSalonuApp.Models.Base;
using SporSalonuApp.Models.UyeModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuApp.Models.OdemeModels
{
    public class Odeme : IModel
    {
        private Uye uye;
        public int Id { get; set; }
        public DateTime TarihSaat { get; set; }
        public int OdenenAyAdet { get; set; }
        public decimal Ucret { get; set; }
        public int UyeId { get; set; }
        public Uye Uye { get { return uye; } set { this.uye = value; this.UyeId = uye.Id; }}

        public string UyeAdSoyad { get { return Uye.AdSoyad; } }

        public Odeme()
        {
            uye = new Uye();
            TarihSaat = DateTime.Now;
        }

        public List<SqlParameter> GetInsertParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@tarihsaat", this.TarihSaat),
                new SqlParameter("@odenen_ay_adet", this.OdenenAyAdet),
                new SqlParameter("@ucret", this.Ucret),
                new SqlParameter("@uye_id", this.UyeId)
            };
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> items = new List<SqlParameter> { new SqlParameter("@odeme_id", this.Id) };
            items.AddRange(GetInsertParameters());
            return items;
        }

        public void ReadItem(IDataRecord record)
        {
            this.Id = Convert.ToInt32(record["odeme_id"]);
            this.TarihSaat = Convert.ToDateTime(record["tarihsaat"]);
            this.OdenenAyAdet = Convert.ToInt32(record["odenen_ay_adet"]);
            this.Ucret = Convert.ToDecimal(record["ucret"]);
            this.Uye.ReadItem(record);
        }
    }
}
