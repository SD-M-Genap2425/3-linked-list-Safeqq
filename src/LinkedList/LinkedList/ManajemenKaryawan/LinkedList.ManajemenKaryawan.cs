using System;
using System.Collections.Generic;

namespace LinkedList.ManajemenKaryawan
{
    public class Karyawan
    {
        public string NomorKaryawan { get; }
        public string Nama { get; }
        public string Posisi { get; }

        public Karyawan(string nomorKaryawan, string nama, string posisi)
        {
            NomorKaryawan = nomorKaryawan;
            Nama = nama;
            Posisi = posisi;
        }
    }
    public class KaryawanNode
    {
        public Karyawan Karyawan { get; }  
        public KaryawanNode? Next { get; set; }
        public KaryawanNode? Prev { get; set; }

        public KaryawanNode(Karyawan karyawan)
        {
            Karyawan = karyawan;
            Next = null;
            Prev = null;
        }
    }
    public class DaftarKaryawan
    {
        private KaryawanNode? head;
        private KaryawanNode? tail;

        public void TambahKaryawan(Karyawan karyawan)
        {
            KaryawanNode newNode = new KaryawanNode(karyawan);

            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail!.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
        }

        public bool HapusKaryawan(string nomorKaryawan)
        {
            KaryawanNode? temp = head;

            while (temp != null)
            {
                if (temp.Karyawan.NomorKaryawan == nomorKaryawan)
                {
                    if (temp.Prev != null)
                        temp.Prev.Next = temp.Next;
                    else
                        head = temp.Next;

                    if (temp.Next != null)
                        temp.Next.Prev = temp.Prev;
                    else
                        tail = temp.Prev;

                    return true;
                }
                temp = temp.Next;
            }
            return false;
        }

        public Karyawan[] CariKaryawan(string kataKunci)
        {
            List<Karyawan> hasil = new List<Karyawan>();
            KaryawanNode? temp = head;

            while (temp != null)
            {
                if (temp.Karyawan.Nama.Contains(kataKunci, StringComparison.OrdinalIgnoreCase) ||
                    temp.Karyawan.Posisi.Contains(kataKunci, StringComparison.OrdinalIgnoreCase))
                {
                    hasil.Add(temp.Karyawan);
                }
                temp = temp.Next;
            }
            return hasil.ToArray();
        }

        public string TampilkanDaftar()
        {
            List<string> daftar = new List<string>();
            KaryawanNode? temp = tail; 

            while (temp != null)
            {
                daftar.Add($"{temp.Karyawan.NomorKaryawan}; {temp.Karyawan.Nama}; {temp.Karyawan.Posisi}");
                temp = temp.Prev;
            }
            return string.Join("\n", daftar);
        }
    }
}
