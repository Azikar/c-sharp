using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab1._2
{
    class MyDataList : DataList
    {
        int prevNode;
        int currentNode;
        int nextNode;
       
        public MyDataList(string filename ,int n, int seed)
        {
            length = n;

            Random rand = new Random(seed);
            if (File.Exists(filename)) File.Delete(filename);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename,
               FileMode.Create)))
                {
                    writer.Write(4);
                    for (int j = 0; j < length; j++)
                    {
                        writer.Write(rand.NextDouble());
                        writer.Write((j + 1) * 12 + 4);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //headNode = new MyLinkedListNode(double.Parse(Console.ReadLine()));
            //currentNode = headNode;
            //for (int i = 1; i < length; i++)
            //{
            //    double data = double.Parse(Console.ReadLine());
            //    prevNode = currentNode;
            //    currentNode.nextNode = new MyLinkedListNode(data);
            //    currentNode = currentNode.nextNode;
            //}
            //currentNode.nextNode = null;
        }
        public FileStream fs { get; set; }
        public double Head_()
        {
            Byte[] data = new Byte[12];
            fs.Seek(0, SeekOrigin.Begin);
            fs.Read(data, 0, 4);
            currentNode = BitConverter.ToInt32(data, 0);
            prevNode = -1;
            fs.Seek(currentNode, SeekOrigin.Begin);
            fs.Read(data, 0, 12);
            double result = BitConverter.ToDouble(data, 0);
            nextNode = BitConverter.ToInt32(data, 8);
            return result;
        }
        public double Next_()
        {
            Byte[] data = new Byte[12];
            fs.Seek(nextNode, SeekOrigin.Begin);
            fs.Read(data, 0, 12);
            prevNode = currentNode;
            currentNode = nextNode;
            double result = BitConverter.ToDouble(data, 0);
            nextNode = BitConverter.ToInt32(data, 8);
            return result;

        }        public double Find_(int sekantis)
        {
            Byte[] data = new Byte[12];
            fs.Seek(sekantis, SeekOrigin.Begin);
            fs.Read(data, 0, 12);
                prevNode = currentNode;
                currentNode = sekantis;
                double result = BitConverter.ToDouble(data, 0);
                nextNode = BitConverter.ToInt32(data, 8);
                return result;
            
           

        }
        public override void selectionSort()
        {
            double min,other;
            int min_, other_;
            double temp;
            min = Head();
            //int sekantis = nextNode;
            for (int i=0; i<Length-1; i ++)
            {
                
                min_ = currentNode;
                temp = min;
                other_ = min_;
               int sekantis = nextNode;
                for (int j =i+1; j<Length; j ++)
                {
                    other = Next();
                    //other_ = currentNode;
                    if (min < other)
                    {
                        min = other;
                        other_ = currentNode;
                    }
                }
                Swap_(min_,other_,temp, min);

                //min = Head();
                min = Find_(sekantis);
                //for (int k = 0; k <= i; k++)
                //{
                //    min = Next();
                //}

            }

        }
        void Swap_ (int min_,int other_,double temp,double min)
        {
            Byte[] data;
            fs.Seek(min_, SeekOrigin.Begin);
            data = BitConverter.GetBytes(min);
            fs.Write(data, 0, 8);

            fs.Seek(other_, SeekOrigin.Begin);
            data = BitConverter.GetBytes(temp);
            fs.Write(data, 0, 8);
        }
        //void Swap(MyLinkedListNode min, MyLinkedListNode j)
        //{
        //    double temp = j.data;
        //    j.data = min.data;
        //    min.data = temp;

            //}
           
        public override void Swap(int other_place, int max_place, double max, double temp)
        {

        }
        //public override void Swap(int a, int b)

        //{

        //    Byte[] data;
        //    fs.Seek(a*12, SeekOrigin.Begin);
        //    data = BitConverter.GetBytes(a);
        //    fs.Write(data, 0, 8);
        //    fs.Seek(currentNode, SeekOrigin.Begin);
        //    data = BitConverter.GetBytes(b);
        //    fs.Write(data, 0, 8);

        //}
        public override double Head()
        {
            Byte[] data = new Byte[12];
            fs.Seek(0, SeekOrigin.Begin);
            fs.Read(data, 0, 4);
            currentNode = BitConverter.ToInt32(data, 0);
            prevNode = -1;
            fs.Seek(currentNode, SeekOrigin.Begin);
            fs.Read(data, 0, 12);
            double result = BitConverter.ToDouble(data, 0);
            nextNode = BitConverter.ToInt32(data, 8);
            return result;
        }
        public override double Next()
        {
            Byte[] data = new Byte[12];
            fs.Seek(nextNode, SeekOrigin.Begin);
            fs.Read(data, 0, 12);
            prevNode = currentNode;
            currentNode = nextNode;
            double result = BitConverter.ToDouble(data, 0);
            nextNode = BitConverter.ToInt32(data, 8);
            return result;

        }
        /// <summary>
        /// sukeitimas heapsort
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void Swap(int x, int y)
        {
            double temp;
            double kuri=0, kita=0;
            int kuri_,kita_;
            kuri = Head();
            for (int i = 0; i < x; i++)
                kuri = Next();
           // temp = kuri;
            kuri_ = currentNode;
            for (int i = 0; i < y - x; i++)
                kita = Next();
            kita_ = currentNode;

            Byte[] data;
             fs.Seek(kuri_, SeekOrigin.Begin);
            data = BitConverter.GetBytes(kita);
            fs.Write(data, 0, 8);
            fs.Seek(kita_, SeekOrigin.Begin);
            data = BitConverter.GetBytes(kuri);
            fs.Write(data, 0, 8);
          //  kuri.data = kita.data;
           // kita.data = temp;
        }
        /// <summary>
        /// reikalingo nodo priejimui
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public override double find(int x, out int position)
        {
            double reiksm=Head();
            int j=currentNode;

            for (int i = 0; i < x; i++)
                reiksm = Next();
            j = currentNode;
            position = j;
            return reiksm;
        }
    }
}
