using System;
using System.Collections.Generic;

namespace LinkedList.Perpustakaan;

public class Buku
{
    public string? Judul { get; set; }
    public string? Penulis { get; set; }
    public int Tahun { get; set; }

    public Buku(string? Judul, string? Penulis, int Tahun)
    {
        this.Judul = Judul;
        this.Penulis = Penulis;
        this.Tahun = Tahun;
    }
}
public class BukuNode
{
    public Buku Data { get; set; }
    public BukuNode? Next { get; set; }
    public BukuNode(Buku buku)
    {
        Data = buku;
        Next = null;
    }
}
public class KoleksiPerpustakaan
{
    private BukuNode? head;

    public void TambahBuku(Buku buku)
    {
        BukuNode newNode = new BukuNode(buku);
        newNode.Next = head;
        head = newNode;
    }

    public bool HapusBuku(string judul)
    {
        BukuNode? temp = head, prev = null;

        while (temp != null && temp.Data.Judul == judul)
        {
            head = temp.Next;
            return true;
        }

        while (temp != null && temp.Data.Judul != judul)
        {
            prev = temp;
            temp = temp.Next;
        }

        if (temp == null) return false;

        prev!.Next = temp.Next;
        return true;
    }

    public Buku[] CariBuku(string kataKunci)
    {
        List<Buku> hasil = new List<Buku>();
        BukuNode? temp = head;

        while (temp != null)
        {
            if (temp.Data.Judul.Contains(kataKunci, StringComparison.OrdinalIgnoreCase))
            {
                hasil.Add(temp.Data);
            }
            temp = temp.Next;
        }

        return hasil.ToArray();
    }

    public string TampilkanKoleksi()
    {
        string hasil = "";
        BukuNode? temp = head;

        while (temp != null)
        {
            hasil += $"\"{temp.Data.Judul}\"; {temp.Data.Penulis}; {temp.Data.Tahun}\n";
            temp = temp.Next;
        }

        return hasil.Trim();
    }
}