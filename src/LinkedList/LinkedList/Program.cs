using System;
using LinkedList.Perpustakaan;
using LinkedList.ManajemenKaryawan;
using LinkedList.Inventori;

namespace LinkedList
{
    class Program
    {
        static void Main()
        {
            var perpustakaan = new KoleksiPerpustakaan();
            perpustakaan.TambahBuku(new Buku("The Hobbit", "J.R.R. Tolkien", 1937));
            perpustakaan.TambahBuku(new Buku("1984", "George Orwell", 1949));
            perpustakaan.TambahBuku(new Buku("The Catcher in the Rye", "J.D. Salinger", 1951));

            Console.WriteLine(perpustakaan.TampilkanKoleksi());
            Console.WriteLine();

            var daftarKaryawan = new DaftarKaryawan();
            daftarKaryawan.TambahKaryawan(new Karyawan("001", "John Doe", "Manager"));
            daftarKaryawan.TambahKaryawan(new Karyawan("002", "Jane Doe", "HR"));
            daftarKaryawan.TambahKaryawan(new Karyawan("003", "Bob Smith", "IT"));

            Console.WriteLine(daftarKaryawan.TampilkanDaftar());
            Console.WriteLine();

            var inventori = new ManajemenInventori();
            inventori.TambahItem(new Item("Apple", 50));
            inventori.TambahItem(new Item("Orange", 30));
            inventori.TambahItem(new Item("Banana", 20));

            Console.WriteLine("Nama Item; Kuantitas");
            Console.WriteLine(inventori.TampilkanInventori());
        }
    }
}
