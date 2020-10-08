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
        }


        class List<T>
        {
            int itemCount;
            private Node<T> head;

            Node<T> Head { get => head; set => head = value; }

            public List()
            {
                itemCount = 0;
            }

            public void Add(T val)
            {
                Node<T> current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
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
