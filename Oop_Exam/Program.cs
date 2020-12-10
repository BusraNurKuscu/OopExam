using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

/*
 CREATE TABLE [dbo].[Urun] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [URUN]     VARCHAR (50) NOT NULL,
    [FİYAT]    INT          NULL,
    [STOK]     INT          NULL,
    [KATAGORİ] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

 */
namespace Oop_Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            urunleriTemizle();
            urunleriEkle();
            urunleriBas();

            Console.WriteLine("\nSilme");
            var urun = Urun.GetAll().FirstOrDefault();
            if (urun != null)
            {
                urun.Delete(60);
            }
            urunleriBas();

            Console.WriteLine("\nGüncelleme");
            urun = Urun.GetAll().FirstOrDefault();
            if (urun != null)
            {
                urun.katagori = "test kategori";
                urun.InsertOrUpdate();
            }
            urunleriBas();

            Console.ReadLine();
        }


        public static void urunleriEkle()
        {
            new Urun("Sampuan", 12, 33, "Temizlik").InsertOrUpdate();
            new Urun("Islak Havlu", 15, 37, "Temizlik").InsertOrUpdate();
            new Urun("Cikolata", 5, 25, "Yiyecek").InsertOrUpdate();
            new Urun("Sut", 3, 317, "Yiyecek").InsertOrUpdate();
            new Urun("Kitap", 35, 50, "Kırtasiye").InsertOrUpdate();
            new Urun("Zeytin", 40, 437, "Yiyecek").InsertOrUpdate();
            new Urun("Cay", 27, 55, "Yiyecek").InsertOrUpdate();
            new Urun("Krem", 15, 40, "Kozmetik").InsertOrUpdate();
            new Urun("Sabun", 5, 81, "Temizlik").InsertOrUpdate();
        }
        public static void urunleriTemizle()
        {
            var uruns = Urun.GetAll();
            foreach (var item in uruns)
            {
                item.DeleteAll();
            }
        }
        public static void urunleriBas()
        {
            var urunler = Urun.GetAll();
            foreach (var urun in urunler)
            {
                Console.WriteLine(urun);
            }
        }
    }
}
