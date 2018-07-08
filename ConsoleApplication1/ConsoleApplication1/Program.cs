using System;
using System.IO;
using System.Diagnostics;
namespace BubbleSort
{
    class Bubble_Sort
    {
        static void Main(string[] args)
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

            // Pirmas etapas
            Test_Array_List(seed);

            RedBlackTree tree = new RedBlackTree();
            Random random = new Random();

            //for (int i = 0; i < 6; i++)
           // {
               // int meh = random.Next(1, 10);
                tree.Insert(11);
            tree.Insert(10);
            tree.Insert(12);
            tree.Insert(11);
            tree.Insert(100);
            tree.Insert(95);
            tree.Insert(25);
            //Console.WriteLine(i+1);
              //  random.Next();

          //  }
            tree.Display();
           
        }
        public static void Selectionsort(DataArray items)
        {
            int n = items.Length,min;
           

            for (int j = 0; j < n - 1; j++)
            {
                min = j;
                for (int i = j + 1; i < n; i++)
                {

                    if (items[min] < items[i])
                    {
                        min = i;

                    }
                   
                }
                items.Swap(j, min, items[min], items[j]);
            }
        }
        public static void Selectionsort(DataList items)
        {
            items.selectionSort();
        }
        public static void Test_Array_List(int seed)
        {
            int n = 5;
            MyDataArray myarray = new MyDataArray(n, seed);
            Console.WriteLine("\n ARRAY \n");
            myarray.Print(n);
            Selectionsort(myarray);
            myarray.Print(n);
            MyDataList mylist = new MyDataList(n, seed);
            Console.WriteLine("\n LIST \n");
            mylist.Print(n);
            Selectionsort(mylist);
            mylist.Print(n);
            
        }
    }
    abstract class DataArray
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract double this[int index] { get; }
        public abstract void Swap(int j,int min, double a, double b);
        
        public void Print(int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(" {0:F5} ", this[i]);
            Console.WriteLine();
        }
    }
    abstract class DataList
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract double Head();
        public abstract double Next();
      //  public abstract void Swap(double a, double b);
        public abstract void selectionSort();
        public void Print(int n)
        {
            Console.Write(" {0:F5} ", Head());
            for (int i = 1; i < n; i++)
                Console.Write(" {0:F5} ", Next());
            Console.WriteLine();
        }
    }
}