using SporSalonuApp.Models.EgzersizModels;
using SporSalonuApp.Models.Enums;
using SporSalonuApp.Models.OdemeModels;
using SporSalonuApp.Models.UyeModels;
using SporSalonuApp.Models.UyeProgramModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuApp.WinForm.Yedekleme
{
    public static class IceDısaAktar
    {
        public static void DısaAktar(DataTable table, string tableName, string filePath)
        {

            var stream = new StreamWriter(filePath, false);
            //tablo adını yaz
            stream.WriteLine(tableName);
            //kolon adlarını yaz
            string colNames = table.Columns[0].ColumnName;
            for (int i = 1; i < table.Columns.Count; i++)
                colNames += "," + table.Columns[i].ColumnName;
            stream.WriteLine(colNames);
            //verileri yaz
            foreach (DataRow row in table.Rows)
            {
                string rowStr = row[0].ToString();
                for (int i = 1; i < table.Columns.Count; i++)
                    rowStr += "," + row[i].ToString().Replace('\n', ' ').Replace('\r', ' ').Replace(',', '.');
                stream.WriteLine(rowStr);
            }
            stream.Close();
        }

        public static DataTable IceAktar(string filePath)
        {
            DataTable table = new DataTable();

            string[] Lines = File.ReadAllLines(filePath);
            table.TableName = Lines[0];
            string[] columnNames = Lines[1].Split(new char[] { ',' });
            foreach (string col in columnNames) { table.Columns.Add(col); }

            for (int i = 2; i < Lines.Length; i++)
            {
                string[] rowData = Lines[i].Split(new char[] { ',' });
                table.Rows.Add(rowData);
            }

            return table;
        }

        public static List<Uye> GetUyeList(this DataTable table)
        {
            if (table.Columns.Count == 7 &&
                table.Columns[0].ColumnName == "uye_id" &&
                table.Columns[1].ColumnName == "ad" &&
                table.Columns[2].ColumnName == "soyad" &&
                table.Columns[3].ColumnName == "dtarih" &&
                table.Columns[4].ColumnName == "kayıt_tarih" &&
                table.Columns[5].ColumnName == "uyelik_son_tarih" &&
                table.Columns[6].ColumnName == "tel_no")
            {
                List<Uye> items = new List<Uye>();
                foreach (DataRow row in table.Rows)
                {
                    items.Add(new Uye
                    {
                        Id = Convert.ToInt32(row[0]),
                        Ad = row[1].ToString(),
                        Soyad = row[2].ToString(),
                        DogumTarih = Convert.ToDateTime(row[3]),
                        KayıtTarih = Convert.ToDateTime(row[4]),
                        UyelikSonTarih = Convert.ToDateTime(row[5]),
                        TelefonNo = row[6].ToString()
                    });
                }
                return items;
            }
            else
                throw new Exception("DataTable Üyelere ait değil!!!");
        }

        public static List<UyeOlcu> GetUyeOlcuList(this DataTable table)
        {
            if (table.Columns.Count == 9 &&
                table.Columns[0].ColumnName == "olcu_id" &&
                table.Columns[1].ColumnName == "kol" &&
                table.Columns[2].ColumnName == "gogus" &&
                table.Columns[3].ColumnName == "kalca" &&
                table.Columns[4].ColumnName == "bel" &&
                table.Columns[5].ColumnName == "boy" &&
                table.Columns[6].ColumnName == "kg" &&
                table.Columns[7].ColumnName == "tarih" &&
                table.Columns[8].ColumnName == "uye_id")
            {
                List<UyeOlcu> items = new List<UyeOlcu>();
                foreach (DataRow row in table.Rows)
                {
                    items.Add(new UyeOlcu
                    {
                        Id = Convert.ToInt32(row[0]),
                        Kol = Convert.ToDecimal(row[1].ToString().Replace('.', ',')),
                        Gogus = Convert.ToDecimal(row[2].ToString().Replace('.', ',')),
                        Kalca = Convert.ToDecimal(row[3].ToString().Replace('.', ',')),
                        Bel = Convert.ToDecimal(row[4].ToString().Replace('.', ',')),
                        Boy = Convert.ToDecimal(row[5].ToString().Replace('.', ',')),
                        Kg = Convert.ToDecimal(row[6].ToString().Replace('.', ',')),
                        Tarih = Convert.ToDateTime(row[7]),
                        UyeId = Convert.ToInt32(row[8])
                    });
                }
                return items;
            }
            else
                throw new Exception("DataTable Üye Ölçülerine ait değil!!!");
        }

        public static List<UyeProgram> GetUyeProgramList(this DataTable table)
        {
            if (table.Columns.Count == 6 &&
                table.Columns[0].ColumnName == "prog_id" &&
                table.Columns[1].ColumnName == "prog_bas_tarih" &&
                table.Columns[2].ColumnName == "is_aktif" &&
                table.Columns[3].ColumnName == "aciklama" &&
                table.Columns[4].ColumnName == "bitis_tarih" &&
                table.Columns[5].ColumnName == "uye_id")
            {
                List<UyeProgram> items = new List<UyeProgram>();
                foreach (DataRow row in table.Rows)
                {
                    items.Add(new UyeProgram
                    {
                        Id = Convert.ToInt32(row[0]),
                        BaslangıcTarih = Convert.ToDateTime(row[1]),
                        IsAktif = Convert.ToBoolean(row[2]),
                        Acıklama = row[3].ToString(),
                        BitisTarih = (String.IsNullOrEmpty(row[4].ToString()) ? null : (DateTime?)Convert.ToDateTime(row[4])),
                        UyeId = Convert.ToInt32(row[5])
                    });
                }
                return items;
            }
            else
                throw new Exception("DataTable Üye Programlarına ait değil!!!");

        }

        public static List<Egzersiz> GetEgzersizList(this DataTable table)
        {
            if (table.Columns.Count == 5 &&
                table.Columns[0].ColumnName == "egzersiz_id" &&
                table.Columns[1].ColumnName == "egzersiz_ad" &&
                table.Columns[2].ColumnName == "kat_id" &&
                table.Columns[3].ColumnName == "aciklama" &&
                table.Columns[4].ColumnName == "birim_type")
            {
                List<Egzersiz> items = new List<Egzersiz>();
                foreach (DataRow row in table.Rows)
                {
                    items.Add(new Egzersiz
                    {
                        Id = Convert.ToInt32(row[0]),
                        Ad = row[1].ToString(),
                        KatId = Convert.ToInt32(row[2]),
                        Acıklama = row[3].ToString(),
                        BirimType = (EgzersizBirimType)Convert.ToInt32(row[4])
                    });
                }
                return items;
            }
            else
                throw new Exception("DataTable Egzersizlere ait değil!!!");
        }

        public static List<EgzersizKategori> GetEgzersizKategoriList(this DataTable table)
        {
            if (table.Columns.Count == 2 &&
                table.Columns[0].ColumnName == "kat_id" &&
                table.Columns[1].ColumnName == "kat_ad")
            {
                List<EgzersizKategori> items = new List<EgzersizKategori>();
                foreach (DataRow row in table.Rows)
                {
                    items.Add(new EgzersizKategori
                    {
                        Id = Convert.ToInt32(row[0]),
                        Ad = row[1].ToString()
                    });
                }
                return items;
            }
            else
                throw new Exception("DataTable Egzersiz Kategorilerine ait değil!!!");
        }

        public static List<Odeme> GetOdemeList(this DataTable table)
        {
            if (table.Columns.Count == 5 &&
                table.Columns[0].ColumnName == "odeme_id" &&
                table.Columns[1].ColumnName == "tarihsaat" &&
                table.Columns[2].ColumnName == "odenen_ay_adet" &&
                table.Columns[3].ColumnName == "ucret" &&
                table.Columns[4].ColumnName == "uye_id")
            {
                List<Odeme> items = new List<Odeme>();
                foreach(DataRow row in table.Rows)
                {
                    items.Add(new Odeme
                    {
                        Id = Convert.ToInt32(row[0]),
                        TarihSaat = Convert.ToDateTime(row[1]),
                        OdenenAyAdet = Convert.ToInt32(row[2]),
                        Ucret = Convert.ToDecimal(row[3].ToString().Replace('.',',')),
                        UyeId = Convert.ToInt32(row[4])
                    });
                }
                return items;
            }
            else
                throw new Exception("DataTable Ödemelere ait değil!!!");
        }

        public static List<ProgramEgzersiz> GetProgramEgzersizleri(this DataTable table)
        {
            if(table.Columns.Count == 6 &&
                table.Columns[0].ColumnName == "prog_egzersiz_id" &&
                table.Columns[1].ColumnName == "gun" &&
                table.Columns[2].ColumnName == "prog_id" &&
                table.Columns[3].ColumnName == "egzersiz_id" &&
                table.Columns[4].ColumnName == "set_adet" &&
                table.Columns[5].ColumnName == "tekrar_sayisi")
            {
                List<ProgramEgzersiz> items = new List<ProgramEgzersiz>();
                foreach(DataRow row in table.Rows)
                {
                    items.Add(new ProgramEgzersiz
                    {
                        Id = Convert.ToInt32(row[0]),
                        Gun = (GunAdi)Convert.ToInt32(row[1]),
                        ProgramId = Convert.ToInt32(row[2]),
                       EgzersizId = Convert.ToInt32(row[3]),
                       SetAdet = Convert.ToInt32(row[4]),
                       TekrarSayısı = Convert.ToInt32(row[5])
                    });
                }
                return items;
            }
            else
                throw new Exception("DataTable Program Egzersizlerine ait değil!!!");
        }
    }
}
