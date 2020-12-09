using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Oop_Exam
{
    public class Urun
    {
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=URUNDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int id { get; set; }
        public string urun { get; set; }
        public int fiyat { get; set; }
        public int stok { get; set; }
        public string katagori { get; set; }
        public Urun()
        {

        }

        public Urun(int id, string urun, int fiyat, int stok, string katagori)
        {
            this.id = id;
            this.urun = urun;
            this.fiyat = fiyat;
            this.stok = stok;
            this.katagori = katagori;
        }
        public Urun( string urun, int fiyat, int stok, string katagori)
        {
            this.id = 0;
            this.urun = urun;
            this.fiyat = fiyat;
            this.stok = stok;
            this.katagori = katagori;
        }
        public static Urun GetWithId(int id)
        {
            Urun item = null;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            var komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandText = $"Select * from [dbo].[Urun] where ID = {id}";
            var reader = komut.ExecuteReader();
            while (reader.Read())
            {
                item = new Urun(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4));
            }
            con.Close();
            return item;
        }
        public void InsertOrUpdate()
        {
           
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            var komut = new SqlCommand();
            komut.Connection = con;
            if (id == 0)
            {
                komut.CommandText = $"INSERT INTO [dbo].[Urun] ([URUN], [FİYAT], [STOK], [KATAGORİ]) VALUES ('{urun}', {fiyat}, {stok}, '{katagori}');";
            }
            else                                                          
            {
                komut.CommandText = $@"UPDATE [dbo].[Urun] SET [URUN] = '{urun}', [FİYAT] = {fiyat}, [STOK] = {stok}, [KATAGORİ] = '{katagori}' WHERE ID={id};";
            }
            komut.ExecuteNonQuery();
            con.Close();
        }
        public void Delete(int id)
        {
            if (id <= 0) return;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            var komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandText = $@"DELETE FROM [dbo].[Urun] WHERE ID={id};";
            komut.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteAll()
        {
            if (id <= 0) return;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            var komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandText = $@"DELETE FROM [dbo].[Urun] WHERE ID={id};";
            komut.ExecuteNonQuery();
            con.Close();
        }
        public static List<Urun> GetAll()
        {
            List<Urun> uruns = new List<Urun>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            var komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandText = $"Select * from [dbo].[Urun];";
            var reader = komut.ExecuteReader();
            while (reader.Read())
            {
                var item = new Urun(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4));
                uruns.Add(item);
            }
            con.Close();
            return uruns;
        }
        public override string ToString()
        {
            return $"{id}, {urun}, {fiyat}, {stok}, {katagori}";
        }
    }
    
}
