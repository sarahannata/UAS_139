using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_139
{
    class Node
    {
        //Mendeklarasikan variable
        public int IdBarang;
        public string NamaBarang;
        public string JenisBarang;
        public int HargaBarang;
        public Node next;
        public Node prev;
    }
    //Membuat class list
    class list
    {
        Node START; //deklarasi Node START
        public list()
        {
            START = null;
        }
        //Membuat addNode
        public void addNode()
        {
            int IdBarang;
            string NamaBarang;
            int HargaBarang;
            string JenisBarang;

            //Memasukkan Id Barang
            Console.Write("Masukkan Id Barang : ");
            IdBarang = Convert.ToInt32(Console.ReadLine());

            //Memasukkan Nama Barang
            Console.Write("Masukkan Nama Barang : ");
            NamaBarang = Console.ReadLine();

            //Memasukkan Jenis Barang
            Console.Write("Masukkan Jenis Barang : ");
            JenisBarang = Console.ReadLine();

            //Memasukkan Harga Barang
            Console.Write("Masukan Harga Barang : ");
            HargaBarang = Convert.ToInt32(Console.ReadLine());

            Node newnode = new Node();
            newnode.IdBarang = IdBarang;
            newnode.NamaBarang = NamaBarang;
            newnode.HargaBarang = HargaBarang;
            newnode.JenisBarang = JenisBarang;

            if (START == null || IdBarang <= START.IdBarang)
            {
                newnode.next = START;
                START = newnode;
                return;
            }

            Node previous, current;
            for (current = previous = START; current != null && IdBarang >= current.IdBarang; previous = current, current = current.next);

            newnode.next = current;
            newnode.prev = previous;

            if (current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;
            }
            newnode.next = current;
            previous.next = newnode;
        }

        public bool search(string JenisBarang, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (JenisBarang != current.JenisBarang))
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
                Console.WriteLine("\nData tidak ditemukan.\n");
            else
            {
                Console.WriteLine("\nDATA BARANG");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                {
                    Console.Write("\nId Barang: " + currentNode.IdBarang + "\nNama Barang: " + currentNode.NamaBarang + "\nJenis Barang: " + currentNode.JenisBarang + "\nHarga Barang: " + currentNode.HargaBarang + "\n");
                }
            }
        }
        static void Main(string[] args)
        {
            list obj = new list();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n        MENU\n");
                    Console.WriteLine("1. Insert Data Barang ");
                    Console.WriteLine("2. Search Data Barang ");
                    Console.WriteLine("3. Display Data Barang ");
                    Console.WriteLine("4. Exit.");
                    Console.Write("Enter Your Choice (1-4): ");
                    char c = Convert.ToChar(Console.ReadLine());
                    switch (c)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList kosong.");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;

                                Console.WriteLine("\nMasukkan Jenis Barang yang ingin dicari: ");
                                string str = Console.ReadLine();
                                if (obj.search(str, ref prev, ref curr) == false)
                                    Console.WriteLine("\nData tidak ditemukan.");
                                else
                                {
                                    Node JENISBarang;
                                    for (JENISBarang = curr; JENISBarang != null; JENISBarang = JENISBarang.next)
                                    Console.WriteLine("Id Barang: " +curr.IdBarang);
                                    Console.WriteLine("Nama Barang: " + curr.NamaBarang);
                                    Console.WriteLine("Harga Barang: " + curr.HargaBarang + "\n");
                                }
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan Salah.");
                                break;
                            }
                    }
                }
                catch (Exception )
                {
                    Console.WriteLine("\nCheck for the value entered.");
                }
            }
        }
    }
}

//2. single linked list
//3. front, rear
//4. a. 5
//   b. Menggunakan metode inorder traversal, dimana cara membacanya left, root, right
//      15, 20, 25, 30, 31, 32, 35, 48, 50, 66, 67, 69, 65, 70, 90, 94, 98, 99
