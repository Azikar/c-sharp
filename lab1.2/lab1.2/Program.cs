using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
namespace lab1._2
{
    class Program
    {
        public static ulong opMcout;
        public static ulong opDcout;
        static void Main(string[] args)
        {                                        //nuo 0 iki 65535
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;// basing the seed on the current time, and(ii) you're limiting that seed to values between 0 and 65535

            // Pirmas etapas
            Test_Array_List(seed);

            // RedBlackTree tree = new RedBlackTree();
            Random random = new Random();

            //for (int i = 0; i < 12; i++)
            //{
            //    int meh = random.Next(1, 10);
            //    tree.Insert(meh);
            //   // Console.WriteLine(i + 1);
            //    random.Next();
            //   // IComparable meh = tree.Search(100);
            //      }
            // Console.WriteLine("N:");
            // int n = int.Parse(Console.ReadLine());
            //  for (int i = 0; i < n; i++)
            // {
            // tree.Insert(int.Parse(Console.ReadLine()));
            //     tree.Insert(Console.ReadLine());
            // }
            // tree.Display();
            // IComparable k = null;
            //  Console.WriteLine("ieskoma reiksme");

            // k  = tree.Search(int.Parse(Console.ReadLine()),n);
            // k = tree.Search(Console.ReadLine(), n);
            //  if (k != null)
            // {
            //     Console.WriteLine("yra");
            // }
            // else
            //     Console.WriteLine("nera");

            //  tree.Print();
        }
        public static void Selectionsort(DataArray items)
        {
            int n = items.Length, min;


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
        //public static void Selectionsort(DataList items)
        //{
        //    double max, temp, index;
        //    double esamas = items.Head();
        //    double sekantis;
        //    double prevdata, currentdata;
        //    int max_place;
        //    int other_place;
        //    for (int i = 0; i < items.Length - 1; i++)
        //    {
        //        max = items.Head();
        //        max_place = i;
        //        temp = max;
        //        for (int j = i + 1; j < items.Length; j++)
        //        {
        //            sekantis = items.Next();
        //            if (sekantis > max)
        //            {
        //                max = sekantis;
        //                max_place = j;

        //            }
        //            other_place = i;
        //            items.Swap(other_place, max_place, max, temp);

        //        }
        //    }
        //    // items.Head();
        //    // items.selectionSort();
        //}
        public static void sort(DataArray arr)
        {
            int n = arr.Length;


            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);


            for (int i = n - 1; i >= 0; i--)
            {

                arr.Swap(0, i);


                heapify(arr, i, 0);
            }
        }
        static void heapify(DataArray arr, int n, int i)
        {
            int largest = i;  //saknis
            int l = 2 * i + 1;  //kaire
            int r = 2 * i + 2;  // desine


            if (l < n && arr[l] > arr[largest])
                largest = l;


            if (r < n && arr[r] > arr[largest])
                largest = r;


            if (largest != i)
            {

                arr.Swap(i, largest);

                heapify(arr, n, largest);
            }
        }
        //  public static void Selectionsort(DataList items)
        //  {
        //     items.selectionSort();
        //  }
        //public static void BubbleSort(DataList items)
        //{
        //    double prevdata, currentdata;
        //    for (int i = items.Length - 1; i >= 0; i--)
        //    {
        //        currentdata = items.Head();
        //        for (int j = 1; j <= i; j++)
        //        {
        //            prevdata = currentdata;
        //            currentdata = items.Next();
        //            if (prevdata > currentdata)
        //            {
        //                items.Swap(currentdata, prevdata);
        //                currentdata = prevdata;
        //            }
        //        }
        //    }
        //}
        public static void Test_Array_List(int seed)
        {
            //int n = 6;
            // Console.WriteLine("|ARRAY| noredami ivesti ranka '0' random '1'");
            MyDataArray myarray;
            int n = 6;
            string filename;
            filename = @"mydataarray.dat";
            //int kas = int.Parse(Console.ReadLine());
            //if (kas == 1)
            // {
            // HeapSort hs = new HeapSort();
            myarray = new MyDataArray(filename, n, seed);
            using (myarray.fs = new FileStream(filename, FileMode.Open,
FileAccess.ReadWrite))
            {
                Console.WriteLine("\n FILE ARRAY \n");
                myarray.Print(n);
                Selectionsort(myarray);
                myarray.Print(n);


            }
            using (myarray.fs = new FileStream(filename, FileMode.Open,
FileAccess.ReadWrite))
            {

                Console.WriteLine("\n FILE ARRAY \n");
                myarray.Print(n);
                sort(myarray);
                myarray.Print(n);
            }
            //}
            //else
            //{
            //    myarray = new MyDataArray(n);
            //}

            //  Console.WriteLine("\n ARRAY \n");
            //  myarray.Print(n);
            //  Selectionsort(myarray);
            //  myarray.Print(n);
            //  Console.WriteLine("\n ARRAY Heap\n");
            // HeapSort hs = new HeapSort();
            HeapSortList hs = new HeapSortList();
            //  // hs.PerformHeapSort(myarray);
            ////  hs.sort(myarray);
            //  myarray.Print(n);

            Console.WriteLine("|Linked list| noredami ivesti ranka '0' random '1'");
            // int kas = int.Parse(Console.ReadLine());
            filename = @"mydatalist1.dat";
            MyDataList mylist = new MyDataList(filename, n, seed);
            using (mylist.fs = new FileStream(filename, FileMode.Open,
           FileAccess.ReadWrite))
            {
                Console.WriteLine("\n FILE LIST \n");
                mylist.Print(n);                mylist.selectionSort();
                //BubbleSort(mylist);
                mylist.Print(n);
                hs.sort(mylist);
                mylist.Print(n);


            }



            //  Console.WriteLine("\n LIST \n");
            //  mylist.Print(n);
            //  Selectionsort(mylist);
            //  mylist.Print(n);
            // // HeapSortList hsL = new HeapSortList();
            //  Console.WriteLine("\n HeapSort LIST \n");
            ////  hsL.sort(mylist);
            //  mylist.Print(n);
            Console.WriteLine("\n ARRAY \n");
            Console.WriteLine("\n ARRAY selection\n N Run Time Op M Count Op D Count\n");
            n = 100;
            
            for (int i = 0; i < 7; i++)
            {
                MyDataArray myarrayy = new MyDataArray(filename, n, seed);
                Stopwatch myTimer = new Stopwatch();
                using (myarrayy.fs = new FileStream(filename, FileMode.Open,
        FileAccess.ReadWrite))
                {
                    myTimer.Start();
                    Selectionsort(myarrayy);
                    myTimer.Stop();
                }
                Console.WriteLine(" {0,6:N0} {1}  {2,15:N0} ", n, myTimer.Elapsed, opMcout);
                n = n * 2;
            }
            Console.WriteLine("\n ARRAY \n");
            Console.WriteLine("\n ARRAY heap \n N Run Time Op M Count Op D Count\n");
            n = 100;

            for (int i = 0; i < 7; i++)
            {
                MyDataArray myarrayy = new MyDataArray(filename, n, seed);
                Stopwatch myTimer = new Stopwatch();
                using (myarrayy.fs = new FileStream(filename, FileMode.Open,
        FileAccess.ReadWrite))
                {
                    myTimer.Start();
                    sort(myarrayy);
                    myTimer.Stop();
                }
                Console.WriteLine(" {0,6:N0} {1}  {2,15:N0} ", n, myTimer.Elapsed, opMcout);
                n = n * 2;
            }

            Console.WriteLine("\n list \n");
            Console.WriteLine("\n list selection \n N Run Time Op M Count Op D Count\n");
            n = 100;

            for (int i = 0; i < 7; i++)
            {
                MyDataList mylistt = new MyDataList(filename, n, seed);
                Stopwatch myTimer = new Stopwatch();
                using (mylistt.fs = new FileStream(filename, FileMode.Open,
        FileAccess.ReadWrite))
                {
                    myTimer.Start();
                    mylistt.selectionSort();
                    myTimer.Stop();
                }
                Console.WriteLine(" {0,6:N0} {1}  {2,15:N0} ", n, myTimer.Elapsed, opMcout);
                n = n * 2;
            }



            Console.WriteLine("\n list \n");
            Console.WriteLine("\n list heap \n N Run Time Op M Count Op D Count\n");
            n = 100;

            for (int i = 0; i < 7; i++)
            {
                MyDataList mylistt = new MyDataList(filename, n, seed);
                Stopwatch myTimer = new Stopwatch();
                using (mylistt.fs = new FileStream(filename, FileMode.Open,
        FileAccess.ReadWrite))
                {
                    myTimer.Start();
                    hs.sort(mylistt);
                    myTimer.Stop();
                }
                Console.WriteLine(" {0,6:N0} {1}  {2,15:N0} ", n, myTimer.Elapsed, opMcout);
                n = n * 2;
            }

        }
    }

    abstract class DataArray
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract double this[int index] { get; }
        public abstract void Swap(int j, int min, double a, double b);
        public abstract void Swap(int x, int y);
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
        // public abstract void Swap(int x, int y);
        public abstract void Swap(int other_place, int max_place, double max, double temp);
        // public abstract double find(int x);
        public abstract void Swap(int a, int b);
        public abstract double find(int x, out int position);
        public void Print(int n)
        {
            Console.Write(" {0:F5} ", Head());
            for (int i = 1; i < n; i++)
                Console.Write(" {0:F5} ", Next());
            Console.WriteLine();
        }
    }
    /// <summary>
    /// heap sort array, heapsort rikiuoja nuo medzio apacios keliaudamas i virsu. didejimo tvarka
    /// </summary>
    class HeapSort
    {
        //public void sort(DataArray arr)
        //{
        //    int n = arr.Length;


        //    for (int i = n / 2 - 1; i >= 0; i--)
        //        heapify(arr, n, i);


        //    for (int i = n - 1; i >= 0; i--)
        //    {

        //        arr.Swap(0, i);


        //        heapify(arr, i, 0);
        //    }
        //}
        //void heapify(DataArray arr, int n, int i)
        //{
        //    int largest = i;  //saknis
        //    int l = 2 * i + 1;  //kaire
        //    int r = 2 * i + 2;  // desine


        //    if (l < n && arr[l] > arr[largest])
        //        largest = l;


        //    if (r < n && arr[r] > arr[largest])
        //        largest = r;


        //    if (largest != i)
        //    {

        //        arr.Swap(i, largest);

        //        heapify(arr, n, largest);
        //    }
        //}


        // }

    }
        /// <summary>
        /// heap sort list
        /// </summary>
        /// 

        class HeapSortList
        {
            public void sort(MyDataList arr)
            {
                int n = arr.Length;


                for (int i = n / 2 - 1; i >= 0; i--)
                    heapify(arr, n, i);


                for (int i = n - 1; i >= 0; i--)
                {

                    arr.Swap(0, i);

                    // iskvieciamas medzio fragmento sudarymas
                    heapify(arr, i, 0);
                }
            }
            void heapify(MyDataList arr, int n, int i)
            {
                int largest = i;  // saknis
                int l = 2 * i + 1;  // kaire
                int r = 2 * i + 2;  // desine
                int position = 0;
                // jei kaire didesnenei saknis

                if (l < n && arr.find(l, out position) > arr.find(largest, out position))
                    largest = l;

                // jei desine didesne nei saknis
                if (r < n && arr.find(r, out position) > arr.find(largest, out position))
                    largest = r;

                // patikrinama ar saknies indeksas pakito, jei taip tai medzio pragmentas perdaromas
                if (largest != i)
                {

                    arr.Swap(i, largest);
                    // rekursinis metodas
                    heapify(arr, n, largest);
                }
            }


        }
    }

