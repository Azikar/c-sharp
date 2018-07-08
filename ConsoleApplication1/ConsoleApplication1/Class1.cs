using System;
using System.IO;
namespace BubbleSort
{
    class MyDataArray : DataArray

    {
        double[] data;
        public MyDataArray(int n, int seed)

        {
            data = new double[n];
            length = n;
            Random rand = new Random(seed);
            for
           (int i = 0; i < length; i++)

            {
                data[i] = rand.NextDouble();

            }

        }
        public override double this
       [int index]

        {
            get { return data[index]; }

        }
        public override void Swap(int j,int min, double a, double b)

        {
            //data[j- 1] = a;
            //data[j] = b;
            double temp=a;
            data[min] = b;
            data[j] = a;


        }

    }
}