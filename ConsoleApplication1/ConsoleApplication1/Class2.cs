using System;
using System.IO;
namespace BubbleSort
{
    class MyDataList : DataList
    {
        class MyLinkedListNode
        {
            public MyLinkedListNode nextNode { get; set; }
            public double data { get; set; }
            public MyLinkedListNode(double data)
            {
                this.data = data;
            }
        }
        MyLinkedListNode headNode;
        MyLinkedListNode prevNode;
        MyLinkedListNode currentNode;
        public MyDataList(int n, int seed)
        {
            length = n;
            Random rand = new Random(seed);
            headNode = new MyLinkedListNode(rand.NextDouble());
            currentNode = headNode;
            for (int i = 1; i < length; i++)
            {
                prevNode = currentNode;
                currentNode.nextNode = new MyLinkedListNode(rand.NextDouble());
                currentNode = currentNode.nextNode;
            }
            currentNode.nextNode = null;
        }
        public override double Head()
        {
            currentNode = headNode;
            prevNode = null;
            return currentNode.data;
        }
        public override double Next()
        {
            prevNode = currentNode;
            currentNode = currentNode.nextNode;
            return currentNode.data;
        }
        public override void selectionSort()
        {
            MyLinkedListNode i, j,min;
          
            
            for(i=headNode;i.nextNode!=null;i=i.nextNode)
            {
                min = i;
                for(j=i.nextNode;j!=null;j=j.nextNode)
                {
                    if (min.data < j.data)
                        min = j;
                }
                Swap(min, i);
            }

        }
         void Swap(MyLinkedListNode min , MyLinkedListNode j)
        {
            double temp = j.data;
            j.data = min.data;
            min.data = temp;

        }
    }
}