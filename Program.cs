using System;

namespace Lab4
{
    class Program
    {
        class List<T>
        {
            int itemCount;
            public T[] item 
            {
                get => item;
                set => item = value;
            }

            public T this[int i]
            {
                get => item[i];
                set => item[i] = value;
            }

            public List()
            {
                itemCount = 0;
            }

        }
        static void Main(string[] args)
        {
            





            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
