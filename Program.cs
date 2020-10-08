using System;
using System.Collections.Generic;
using System.Runtime.Versioning;

namespace List
{
    // Можно внести внутрь класса листа, но замчем
    public class Owner
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Organization { get; private set; }

        public Owner(string id, string name, string organization)
        {
            Id = id;
            Name = name;
            Organization = organization;
        }
    }
    
    public class Date
    { 
        public int Day { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }

        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
        public Date()
        {
           string[] s = System.DateTime.Now.ToString("dd MM yyyy").Split();
           Day = System.Convert.ToInt32(s[0]);
           Month = System.Convert.ToInt32(s[1]);
           Year = System.Convert.ToInt32(s[2]);
        }
    }

    public class Node<T>
    {
        public T Item { get; set; }

        public Node<T> Next { get; set; }


        public Node(T item)
        {
            Item = item;
        }

        public bool IsNull()
        {
            if (this == null)
                return true;
            else
                return false;
        }
    }
    public class List<T>
    {
        private int itemCount;
        private Node<T> head;

        public Owner owner { get; } 
        public Date date { get; } 
        Node<T> Head { get => head; }

        public List()  
        {
            itemCount = 0;
            owner = new Owner("65741796", "Artyom Orlov", "BSTU");
            date = new Date();
        }

        public bool IsEmpty()
        {
            if (itemCount == 0)
                return true;
            else
                return false;
        }
        public static List<T> operator +(List<T> a, List<T> b)
        {
            List<T> c = new List<T>();

            for (int i = 0; i < a.getItemCount(); i++)
            {
                c.Add(a[i]);
            }

            for (int i = 0; i < b.getItemCount(); i++)
            {
                c.Add(b[i]);
            }

            return c;
        }

        public static List<T> operator --(List<T> a)
        {
            a.itemCount--;
            a.head = a.Head.Next;
            return a;
        }

        public static bool operator ==(List<T> a, List<T> b)
        {
            if (a.getItemCount() == b.getItemCount())
            {
                for (int i = 0; i < a.getItemCount(); i++)
                {
                    if (!Object.Equals(a[i], b[i])) return false;
                }
                return true;
            }
            else
                return false;
        }

        public static bool operator !=(List<T> a, List<T> b)
        {
            if (a.getItemCount() == b.getItemCount())
            {
                for (int i = 0; i < a.getItemCount(); i++)
                {
                    if (Object.Equals(a, b)) return true;
                }
                return false;
            }
            else
                return true;
        }

        public override string ToString()
        {
            Node<T> current = head;
            string rez = System.Convert.ToString(head.Item);
            for (int i = 1; i < getItemCount(); i++)
            {
                current = current.Next;
                rez += " " + System.Convert.ToString(current.Item);
            }
            return rez;
        }
        public int getItemCount() => itemCount;
        public void Add(T val)
        {
            if (head == null)
            {
                head = new Node<T>(val);
            }
            else
            {
                Node<T> current = Head;
                for (int i = 1; i < getItemCount(); i++)
                {
                    current = current.Next;
                }
                current.Next = new Node<T>(val);

            }
            itemCount++;
        }
        public T this[int i]
        {
            get
            {
                Node<T> current = Head;
                for (int j = 0; j < i; j++)
                {
                    current = current.Next;
                }
                return current.Item;
            }
            set
            {
                Node<T> current = Head;
                for (int j = 0; j < i; j++)
                {
                    current = current.Next;
                }
                current.Item = value;
            }

        }

    }
}



namespace Lab4
{
    using List;
    public static class Extensions
    {
        public static string LastWord(this string str)
        {
            string[] rez;

            rez = str.Split();
            return rez[rez.Length-1];
        }

        public static bool AreThereRepeats<T>(this List<T> list)
        {
            List<T> arr = new List<T>();
            for (int i = 0; i < list.getItemCount(); i++)
            {
                for (int j = 0; j < arr.getItemCount(); j++)
                {
                    if (Object.Equals(list[i], arr[j])) // если в массиве уже есть
                    {
                        return true;
                    }

                }
                // если не выбило из функции, то новый элемент в arr
                arr.Add(list[i]);
            }
            // если ни разу не выбило - повторов нет
            return false;
        }
    }

    class Program
    {


        static void Main(string[] args)
        {

            List<int> A = new List<int>();
            List<int> B = new List<int>();
            List<int> C = new List<int>();


            A.Add(1);
            A.Add(2);
            A.Add(3);
            B.Add(4);
            B.Add(5);
            B.Add(6);
            C = A + B;
            Console.WriteLine(A);
            Console.WriteLine(B);
            Console.WriteLine(C);
            Console.WriteLine(--C);
            --C; --C; // 4 5 6
            Console.WriteLine(C);
            Console.WriteLine($"1 2 3 == 4 5 6? {A == B}");
            Console.WriteLine($"4 5 6 == 4 5 6? {B == C}");

            Console.WriteLine($"1 2 3, есть ли повторы? {A.AreThereRepeats()}");
            A.Add(1);
            Console.WriteLine($"1 2 3 1, есть ли повторы? {A.AreThereRepeats()}");

            A.Add(4);
            Console.WriteLine($"1 2 3 1 4, последний элемент: {System.Convert.ToString(A).LastWord()}");

            Console.WriteLine($"{A.date.Day}.{A.date.Month}.{A.date.Year}");
            Console.WriteLine($"{A.owner.Id}.{A.owner.Name}.{A.owner.Organization}");



            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
