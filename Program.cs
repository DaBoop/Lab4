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

            public int getItemCount() => itemCount;
            public void Add(T val)
            {
                Node<T> current = Head;
                while (!current.Next.IsNull())
                {
                    current = current.Next;
                }
                current.Next = new Node<T>(val);
                itemCount++;
            }
            public T this[int i]
            {
                get
                {
                    Node<T> current = Head;
                    for (int j = 0; i < j; j++)
                    {
                        current = current.Next;
                    }
                    return current.Item;
                }
                set
                {
                    Node<T> current = Head;
                    for (int j = 0; i < j; j++)
                    {
                        current = current.Next;
                    }
                    current.Item = value;
                }

            }


        }
        static void Main(string[] args)
        {
            





            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
