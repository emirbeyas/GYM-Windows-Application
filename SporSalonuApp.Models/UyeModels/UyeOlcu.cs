using SporSalonuApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuApp.Models.UyeModels
{
    public class UyeOlcu : IModel
    {
        public int Id { get; set; }
        public decimal Kol { get; set; }
        public decimal Gogus { get; set; }
        public decimal Kalca { get; set; }
        public decimal Bel { get; set; }
        public decimal Boy { get; set; }
        public decimal Kg { get; set; }
        public DateTime Tarih { get; set; } = DateTime.Now;
        public int UyeId { get; set; }

        public List<SqlParameter> GetInsertParameters()
        {
            return new List<SqlParameter> { 
                new SqlParameter("@kol", this.Kol),
                new SqlParameter("@gogus", this.Gogus),
                new SqlParameter("@kalca", this.Kalca),
                new SqlParameter("@bel", this.Bel),
                new SqlParameter("@boy", this.Boy),
                new SqlParameter("@kg", this.Kg),
                new SqlParameter("@tarih", this.Tarih),
                new SqlParameter("@uye_id", this.UyeId)};
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            var items = new List<SqlParameter> { new SqlParameter("@olcu_id", this.Id) };
            items.AddRange(GetInsertParameters());
            return items;
        }

        public void ReadItem(IDataRecord record)
        {
            this.Id = Convert.ToInt32(record["olcu_id"]);
            this.Kol = Convert.ToDecimal(record["kol"]);
            this.Gogus = Convert.ToDecimal(record["gogus"]);
            this.Kalca = Convert.ToDecimal(record["kalca"]);
            this.Bel = Convert.ToDecimal(record["bel"]);
            this.Boy = Convert.ToDecimal(record["boy"]);
            this.Kg = Convert.ToDecimal(record["kg"]);
            this.Tarih = Convert.ToDateTime(record["tarih"]);
            this.UyeId = Convert.ToInt16(record["uye_id"]);
        }
    }
}
