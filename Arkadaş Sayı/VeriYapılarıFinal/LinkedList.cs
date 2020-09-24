using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriYapılarıFinal
{
    public class LinkedList : LinkedListADT
    {
        public override void InsertFirst(int value)
        {
            Node tmpHead = new Node
            {
                Data = value
            };

            if (Head == null)
                Head = tmpHead;
            else
            {
                //En kritik nokta: tmpHead'in next'i eski Head'i göstermeli
                tmpHead.Next = Head;
                //Yeni Head artık tmpHead oldu
                Head = tmpHead;
            }
            //Bağlı listedeki eleman sayısı bir arttı
            Size++;
        }

        public override void InsertLast(int value)
        {
            //Eski sonuncu node, Head'den başlanarak set ediliyor
            Node oldLast = Head;

            if (Head == null)
                //Hiç kayıt eklenmediği için InsertFirst çağrılabilir
                InsertFirst(value);
            else
            {
                //Yeni sonuncu node yaratılıyor
                Node newLast = new Node
                {
                    Data = value
                };

                //Eski sonuncu node bulunuyor
                //Tail olsaydı sonuncuyu bulmaya gerek yoktu.
                while (oldLast.Next != null)
                {

                    oldLast = oldLast.Next;

                }

                //Eski sonuncu node referansı artık yeni sonuncu node'u gösteriyor
                oldLast.Next = newLast;

                //Bağlı listedeki eleman sayısı bir arttı
                Size++;
            }
        }

        public override void InsertPos(int position, int value)
        {
            throw new NotImplementedException();
        }

        public override void DeleteFirst()
        {
            if (Head != null)
            {
                //Head'in next'i HeadNext'e atanıyor
                Node tempHeadNext = this.Head.Next;
                //HeadNext null ise zaten tek kayıt olan Head silinir.
                if (tempHeadNext == null)
                    Head = null;
                else
                    //HeadNext null değilse yeni Head, HeadNext olur.
                    Head = tempHeadNext;
                //Listedeki eleman sayısı bir azaltılıyor
                Size--;
            }
        }

        public override void DeleteLast()
        {
            //Last node bulunup NULL yapılacak
            Node lastNode = Head;
            //Last node'dan bir önceki node'un Next'i null olacak
            Node lastPrevNode = null;
            while (lastNode.Next != null)
            {

                lastPrevNode = lastNode;
                lastNode = lastNode.Next;

            }
            //Listedeki eleman sayısı bir azaltılıyor
            Size--;
            //Last node null oldu
            lastNode = null;

            //Last node'dan önceki node varsa onun next'i null olacak yoksa zaten tek kayıt vardır, 
            //o da Head'dir, o da null olacak
            if (lastPrevNode != null)
                lastPrevNode.Next = null;
            else
                Head = null;
        }

        public override void DeletePos(int position)
        {
            throw new NotImplementedException();
        }

        public override Node GetElement(int position)
        {
            //Geri dönülecek eleman
            Node retNode = null;
            //Head'den başlanarak Next node'a gidilecek
            Node tempNode = Head;
            int count = 0;

            while (tempNode != null)
            {
                if (count == position)
                {
                    retNode = tempNode;
                    break;
                }
                //Next node'a git
                tempNode = tempNode.Next;
                count++;
            }
            return retNode;
        }

        public override string DisplayElements()
        {
            string temp = "";
            Node item = Head;
            while (item != null)
            {
                temp += "-->" + item.Data;
                item = item.Next;
            }

            return temp;
        }

        public void ArkadasSayi( int sayi1, int sayi2) // c1 + c2 + n*c3 + n*c4 + c5 + n. Karmaşıklık Big O'da O(N).
        {
            int sayi1Bölenler = 0;
            int sayi2Bölenler = 0;
            for (int i = 1; i < sayi1; i++)
            {
                if (sayi1 % i == 0)
                {
                    sayi1Bölenler = sayi1Bölenler + i;
                }
            }
            for (int i = 1; i < sayi2; i++)
            {
                if (sayi2 % i == 0)
                {
                    sayi2Bölenler = sayi2Bölenler + i;
                }
            }

            if (sayi1 == sayi2Bölenler && sayi2 == sayi1Bölenler)
            {
                MessageBox.Show(sayi1 + " ve " + sayi2 + " Arkadaş!");
                Node nsayi1 = new Node();
                nsayi1.Data = sayi1;
                Node nsayi2 = new Node();
                nsayi2.Data = sayi2;
                YerDeğiştir(nsayi1, nsayi2); // Bu fonksiyonun Big O'su O(N)'dir. Fonksiyonun karmaşıklığına eklenir.
            }
            
        }

        public void YerDeğiştir(Node node1, Node node2) // c1 + c2 + c3 + c4 + c5 + n*c6 + (n-1)*c7 + n*c8 + n*c9 . Karmaşıklık Big O'da O(N)'dir.
        {
            bool sayi1degisti = false, sayi2degisti = false;
            int data1 = node1.Data;
            int data2 = node2.Data;
            Node tempNode = Head;
            while (tempNode != null) // n kere döner
            {
                if (data1 == tempNode.Data)//o zaman node1 bulundu
                {
                    tempNode.Data = data2;
                    sayi1degisti = true;
                }
                else if (data2 == tempNode.Data)//node2
                {
                    tempNode.Data = data1;
                    sayi2degisti = true;
                }
                if (sayi1degisti == true && sayi2degisti == true)
                {
                    break;
                }
                tempNode = tempNode.Next;
            }
            

        }

        public void ArkadasSayilarBulDeğistir(LinkedList List) // c1 + c2 + n*c3 + ((n-1)*(n-2)/2)*n + n .Karmaşıklık Big O olarak O(n^3)
        {
            int[] list = new int[List.Size];
            Node tempNode = Head;
            for (int i = 0; i < List.Size; i++)
            {
                if (tempNode != null)
                {
                    list[i] = tempNode.Data;
                    tempNode = tempNode.Next;
                }
            }
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = i + 1; j < list.Length; j++)
                {
                    ArkadasSayi(list[i], list[j]);// Kod buraya (n-1) + (n-2) + (n-3) +... + 1 = (n-1)*(n-2)/2 kadar gelir. 
                    //ArkadasSayi fonksiyonunun Big O'su ile çarpılır.
                }
            }
            MessageBox.Show("Arkadaş sayıların yerleri değiştirilmiş liste: " + List.DisplayElements());//DisplayElements fonksiyonunun karışıklığı o(n)'dir.
        }
    }
}
