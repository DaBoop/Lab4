using System;
using System.Runtime.Versioning;

namespace Lab4
{
    class Program
    {
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


        class List<T>
        {
            private int itemCount;
            private Node<T> head;

            Node<T> Head { get => head; set => head = value; }

            public List() => itemCount = 0;

            public bool IsEmpty()
            {
                if (itemCount == 0)
                    return true;
                else
                    return false;
            }
            public static List<T> operator+ (List<T> a, List<T> b)
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
            public override string ToString()
            {
                Node<T> current = head;
                string rez = System.Convert.ToString(head.Item);
                for(int i = 1; i < getItemCount(); i++)
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




            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
