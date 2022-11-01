using SporSalonuApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuApp.Models.UyeProgramModels
{
    public class UyeProgram : IModel
    {
        public int Id { get; set; }
        public DateTime BaslangıcTarih { get; set; } = DateTime.Now;
        public bool IsAktif { get; set; } = true;
        public string Acıklama { get; set; }
        public DateTime? BitisTarih { get; set; }
        public int UyeId { get; set; }

        public List<SqlParameter> GetInsertParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@prog_bas_tarih", this.BaslangıcTarih),
                new SqlParameter("@is_aktif", this.IsAktif),
                new SqlParameter("@aciklama", this.Acıklama),
                new SqlParameter("@bitis_tarih", this.BitisTarih),
                new SqlParameter("@uye_id", this.UyeId)
            };
        }


        public List<SqlParameter> GetUpdateParameters()
        {
            var items = new List<SqlParameter> { new SqlParameter("@prog_id", this.Id) };
            items.AddRange(GetInsertParameters());
            return items;
        }

        public void ReadItem(IDataRecord record)
        {
            this.Id = Convert.ToInt32(record["prog_id"]);
            this.BaslangıcTarih = Convert.ToDateTime(record["prog_bas_tarih"]);
            this.IsAktif = Convert.ToBoolean(record["is_aktif"]);
            this.Acıklama = record["aciklama"].ToString();
            this.BitisTarih = record["bitis_tarih"] as DateTime?;
            this.UyeId = Convert.ToInt32(record["uye_id"]);
        }
    }
}
