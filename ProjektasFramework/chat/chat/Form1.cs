using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using Emgu;
using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Text.RegularExpressions;
using Emgu.CV.UI;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace chat
{
   
    public partial class Form1 : Form
    {
      
        TcpClient client = new TcpClient();
        NetworkStream stream;
        string readData = null;
        // private ICapture cap;

        private ICapture cap;
        public Form1()
        {
            InitializeComponent();
                   

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }
       
        private void start_Click(object sender, EventArgs e)
        {
            string ip = textBox1.Text;
            client.Connect(IPAddress.Parse(ip), 5007);
             stream = client.GetStream();
            string s = "hello server";
            byte[] message = Encoding.ASCII.GetBytes(s);
            stream.Write(message,0,message.Length);
            Thread ctThread = new Thread(getMessage);
            ctThread.Start();

              
        }

        private void getMessage()
        {
            while (true)
            {
                NetworkStream stream = client.GetStream();
                int buffSize = 0;
                byte[] inStream = new byte[200000];
                buffSize = client.ReceiveBufferSize;
                stream.Read(inStream, 0, buffSize);
                //var ms = new MemoryStream(inStream);
                //pictureBox1.Image = Image.FromStream(ms);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);

                readData = "" + returndata;
               msg(readData);
            }
        }
        private void getlist()
        {
           
        }

        private void msg(string readData)
        {
            
               textBox1.Text=readData;
        }
        private void send_Click(object sender, EventArgs e)
        {



            long sizes;
            var ms = new MemoryStream();
            //  OpenFileDialog result = new OpenFileDialog();
            //  result.ShowDialog();
            // result = openFileDialog1.ShowDialog();
            //  Image imageIn = new Bitmap(result.FileName);

            cap = new Emgu.CV.VideoCapture(0);
            Mat frame = new Mat();
            frame = cap.QueryFrame();
            Bitmap bitmap = new Bitmap(frame.Bitmap);
            Image<Bgr, Byte> img = new Image<Bgr, Byte>(bitmap);
            pictureBox1.Image = img.Bitmap;
            Image imageIn = new Bitmap(img.Bitmap);
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
           sizes= ms.Length;
            
            byte[] imgis = ms.ToArray();
            byte[] ilgis = Encoding.UTF8.GetBytes(Convert.ToString(imgis.Length));
            byte[] skyriklis = new byte[1];
            skyriklis[0] = 4;
           // string s = textBox5.Text; ;
            //  byte[] message = Encoding.ASCII.GetBytes(textBox5.Text);
            string comand="List";


            var mss = new MemoryStream();

            mss.Write(ilgis,0,ilgis.Length);

            mss.Write(skyriklis,0,skyriklis.Length);
            mss.Write(imgis,0,imgis.Length);

            // pictureBox1.Image = Image.FromStream(mss);
            // byte[] message=new byte[1024];
            byte[] paketas = mss.ToArray();
           // Encoding.ASCII.GetBytes(comand).CopyTo(message, 0);
           // Encoding.ASCII.GetBytes(s).CopyTo(message, 4);
           
           stream.Write(paketas, 0, paketas.Length);
           stream.Flush();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ICapture cap;
            //cap = new Emgu.CV.VideoCapture(0);
            //Mat frame = new Mat();
            //frame = cap.QueryFrame();
            //Image<Bgr, Byte> img = new Image<Bgr, Byte>(frame.Bitmap);
            //pictureBox1.Image = img.Bitmap;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //client.Connect(IPAddress.Parse("192.168.1.68"), 5001);
            //stream = client.GetStream();
            //string s = "hello server";
            //byte[] message = Encoding.ASCII.GetBytes(s);
            //stream.Write(message, 0, message.Length);
            //Thread ctThread = new Thread(getMessage);
            //ctThread.Start();

            //cap = new Emgu.CV.VideoCapture(0);
            //Mat frame = new Mat();
            //frame = cap.QueryFrame();
            //Bitmap bitmap = new Bitmap(frame.Bitmap);
            //Image<Bgr, Byte> img = new Image<Bgr, Byte>(bitmap);
            //pictureBox1.Image = img.Bitmap;




            long sizes;
            var ms = new MemoryStream();
             OpenFileDialog result = new OpenFileDialog();
              result.ShowDialog();

          //  result.ShowDialog();
            
              Image imageIn = new Bitmap(result.FileName);

          //  cap = new Emgu.CV.VideoCapture(0);
          //  Mat frame = new Mat();
          //  frame = cap.QueryFrame();
            Bitmap bitmap = new Bitmap(imageIn);
            Image<Bgr, Byte> img = new Image<Bgr, Byte>(bitmap);
            pictureBox1.Image = img.Bitmap;
           // Image imageIn = new Bitmap(img.Bitmap);
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            sizes = ms.Length;

            byte[] imgis = ms.ToArray();
            byte[] ilgis = Encoding.UTF8.GetBytes(Convert.ToString(imgis.Length));
            byte[] skyriklis = new byte[1];
            skyriklis[0] = 4;
            // string s = textBox5.Text; ;
            //  byte[] message = Encoding.ASCII.GetBytes(textBox5.Text);
            string comand = "List";


            var mss = new MemoryStream();

            mss.Write(ilgis, 0, ilgis.Length);

            mss.Write(skyriklis, 0, skyriklis.Length);
            mss.Write(imgis, 0, imgis.Length);

            // pictureBox1.Image = Image.FromStream(mss);
            // byte[] message=new byte[1024];
            byte[] paketas = mss.ToArray();
            // Encoding.ASCII.GetBytes(comand).CopyTo(message, 0);
            // Encoding.ASCII.GetBytes(s).CopyTo(message, 4);

            stream.Write(paketas, 0, paketas.Length);
            stream.Flush();


        }

    }
}
