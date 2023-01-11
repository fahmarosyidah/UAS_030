using System;

namespace UAS_030
{
    class Node
    {
        public int noBuku, thTerbit;
        public string judul, pengarang;
        public Node next;
    }

    class List
    {
        Node START;
        public List()
        {
            START = null;
        }

        public void addNode()
        {
            int nomorbuku, tahunterbit;
            string judulbuku, namapengarang;

            Console.Write("Masukkan Nomor Buku: ");
            nomorbuku = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Judul Buku: ");
            judulbuku = Console.ReadLine();
            Console.Write("Masukkan Nama Pengarang: ");
            namapengarang = Console.ReadLine();
            Console.Write("Masukkan Tahun Terbit: ");
            tahunterbit = Convert.ToInt32(Console.ReadLine());

            Node newnode = new Node();

            newnode.noBuku = nomorbuku;
            newnode.judul = judulbuku;
            newnode.pengarang = namapengarang;
            newnode.thTerbit = tahunterbit;

            if (START == null || nomorbuku <= START.noBuku)
            {
                if ((START != null) && (nomorbuku == START.noBuku))
                {
                    Console.WriteLine("\nDuplikasi nomor buku tidak diperbolehkan\n");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }

            Node current, previous;
            previous = START;
            current = START;

            while ((current != null) && (nomorbuku >= current.noBuku))
            {
                if (nomorbuku == current.noBuku)
                {
                    Console.WriteLine("\nDuplikasi nomor buku tidak diperbolehkan\n");
                    return;
                }
                previous = current;
                current = current.next;
            }
            newnode.next = current;
            previous.next = newnode;
        }
        

        public bool search(int thTerbit, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (thTerbit != current.thTerbit))
            {
                previous = current;
                current = current.next;
            }

            if (current == null)
                return (false);
            else
                return (true);
        }

        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList Kosong\n");
            else
            {
                Console.WriteLine("\nList Data Buku: \n");
                Node currentnode;
                for (currentnode = START; currentnode != null; currentnode = currentnode.next)
                    Console.WriteLine(currentnode.noBuku + " " + currentnode.judul + " " + currentnode.pengarang + " " + currentnode.thTerbit);
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            List obj = new List();

            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Menambahkan Data");
                    Console.WriteLine("2. Menampilkan Data");
                    Console.WriteLine("3. Mengurutkan Data");
                    Console.WriteLine("4. Mencari Data");
                    Console.WriteLine("5. Keluar");
                    Console.Write("\nMasukkan pilihan (1-5): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                obj.traverse();
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList Kosong\n");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukkan tahun terbit buku yang akan dicari: ");
                                int no = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(no, ref previous, ref current) == false)
                                    Console.WriteLine("\nData tidak ditemukan");
                                else
                                {
                                    Console.WriteLine("\nData ditemukan");
                                    Console.WriteLine("\nNo Buku: " + current.noBuku);
                                    Console.WriteLine("\nJudul Buku: " + current.judul);
                                    Console.WriteLine("\nNama Pengarang: " + current.pengarang);
                                    Console.WriteLine("\nTahun Terbit: " + current.thTerbit);
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan salah");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nPeriksa Nomor Buku yang dimasukkan.");
                }
            }
        }
    }
}

/*
 
 2. Algoritma yang digunakan pada program di atas adalah single linked list. 
    Karena data yang disimpan tidak sejenis dengan jumlah data yang cukup banyak sehingga membutuhkan pengurutan data dengan waktu yang efisien.
    Dengan Linked List, memori akan dialokasikan saat digunakan sehingga ketika ada data baru yang masuk, tidak perlu menggeser data lain yang mana akan memakan banyak waktu
    Dengan menggunakan Linked List, kita bisa menyimpan sekaligus mengurutkan data. 
 3. Operasi yang digunakan dalam algoritma Stack:
    - Push (untuk menambah data)
    - Pop (untuk mengurangi/menghapus data)
 4. Algoritma Queue merupakan struktur data dimana satu data dapat ditambakan diakhir disebut rear dan data dihapus dari yang paling terkahir disebut front
 5. a) Kedalaman: 5
    b} 25, 20, 10, 5, 1, 8, 12, 15, 22, 36, 30, 28, 40, 38, 48, 45, 50 (preorder)

 */
