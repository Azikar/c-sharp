using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
namespace lab1._2
{
    class MyDataArray : DataArray

    {
       // double[] data;
        public MyDataArray(string filename,int n, int seed)

        {
            double[] data = new double[n];
            length = n;
            Random rand = new Random(seed);
            for
            (int i = 0; i < length; i++)

            {
                data[i] = rand.NextDouble();

            }
            if (File.Exists(filename)) File.Delete(filename);            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename,
               FileMode.Create)))
                {
                    for (int j = 0; j < length; j++)
                        writer.Write(data[j]);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public FileStream fs { get; set; }


        //public MyDataArray(int n)
        //{
        //    data = new double[n];
        //    length = n;
        //    Console.WriteLine("veskite duom po viena");
        //    for (int i = 0; i < n; i++)
        //    {
        //        data[i] = double.Parse(Console.ReadLine());
        //    }
        //}
        public override double this
       [int index]

        {
            get {
                Byte[] data = new Byte[8];
                fs.Seek(8 * index, SeekOrigin.Begin);
                fs.Read(data, 0, 8);
                double result = BitConverter.ToDouble(data, 0);
                return result;
            }

        }
        /// <summary>
        /// sukeitimas selection sort
        /// </summary>
        /// <param name="j"></param>
        /// <param name="min"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public override void Swap(int j, int min, double a, double b)

        {

            // double temp = a;
              // data[min] = b;
             //data[j] = a;
            //  Byte[] data = new Byte[16];
            //double temp = a;
            Byte[] data = new Byte[8];
            BitConverter.GetBytes(a).CopyTo(data, 0);
           // BitConverter.GetBytes(b).CopyTo(data, );
            fs.Seek(j*8, SeekOrigin.Begin);
            fs.Write(data, 0, 8);
            data = new Byte[8];
            BitConverter.GetBytes(b).CopyTo(data, 0);
            fs.Seek(min*8, SeekOrigin.Begin);
            fs.Write(data, 0, 8);
            




        }
        /// <summary>
        /// sukeitimas naudojamas heapsorte
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void Swap(int x, int y)

        {

            //double temp = data[x];
            ////data[x] = data[y];
            //// data[y] = temp;
            //double a = 
            //double b = data[y];
            Byte[] data = new Byte[8];
            fs.Seek(8 * y, SeekOrigin.Begin);
            fs.Read(data, 0, 8);
            double b = BitConverter.ToDouble(data, 0);

            fs.Seek(8 * x, SeekOrigin.Begin);
            fs.Read(data, 0, 8);
            double a = BitConverter.ToDouble(data, 0);


            Byte[] dat = new Byte[8];
            BitConverter.GetBytes(b).CopyTo(dat, 0);
            fs.Seek(x * 8, SeekOrigin.Begin);
            fs.Write(dat, 0, 8);

            dat = new Byte[8];
            BitConverter.GetBytes(a).CopyTo(dat, 0);
            fs.Seek(y * 8, SeekOrigin.Begin);
            fs.Write(dat, 0, 8);


        }

    }
}

