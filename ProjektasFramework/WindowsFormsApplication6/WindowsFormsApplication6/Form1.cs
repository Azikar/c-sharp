using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
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
using Emgu.Util;
using Aspose.OCR;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        private ICapture cap;
        private Tesseract _ocr;
        public Form1()
        {
            InitializeComponent();
           
            Console.WriteLine("starting");

            Thread room1 = new Thread(() => connect(5007));
            // Thread room2 = new Thread(() => connect(5001));



            room1.Start();
            foreach (IPAddress adress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                textBox2.Text = adress.ToString();
            }

            // room2.Start();
           // Console.WriteLine("Ready");

        }
        public void connect(int port)
        {
            List<TcpClient> clients = new List<TcpClient>();
            TcpListener listen = new TcpListener(IPAddress.Any, port);
            listen.Start();
            int i = 0;
            TcpClient client;

            while (true)
            {
                client = listen.AcceptTcpClient();
                TcpClient mclient = (TcpClient)client;
                NetworkStream stream = mclient.GetStream();
                byte[] message = new byte[20000000 + 10];
                stream.Read(message, 0, message.Length);
                Console.WriteLine(Encoding.ASCII.GetString(message));
                clients.Add(mclient);
                Console.WriteLine(clients.Count);
                //   stream.Write(message, 0, message.Length);
                //  broadcast(Encoding.ASCII.GetString(message) + " Joined ", Encoding.ASCII.GetString(message), false,clients);
                startclient(client, clients);
            }
        }

        public void startclient(TcpClient client, List<TcpClient> clients)
        {
            Thread ctThread = new Thread(() => chat(client, clients));
            textBox1.Text = "Prisijungta";
            ctThread.Start();
        }


        public void chat(TcpClient client, List<TcpClient> clients)
        {




            // byte[] message = new byte[36341];
            while (true)
            {
                Image img;
                NetworkStream stream = client.GetStream();
                byte[] data = null;
                int b = 0;
                String buff_lenght = "";
                while ((b = stream.ReadByte()) != 4)
                {
                    buff_lenght += (char)b;

                }

                int data_length = Convert.ToInt32(buff_lenght);
                data = new byte[data_length];
                int byte_read = 0;
                int byte_offset = 0;
                while (byte_offset < data_length)
                {
                    byte_read = stream.Read(data, byte_offset, data_length - byte_offset);
                    byte_offset += byte_read;
                }
                //stream.Read(message, 0, message.Length);
                var ms = new MemoryStream(data);

                //Console.WriteLine(Encoding.ASCII.GetString(message,0,4));
                //Console.WriteLine(Encoding.ASCII.GetString(message, 4, 8));
                // Console.WriteLine(message[1]);
                //Console.WriteLine(message.Length);

               
                img = Image.FromStream(ms);

                pictureBox1.Image = img;
                if (img != null)
                {
                    oc(img, client);
                }
                //broadcastt(message, false, clients);
            }
        }



        //public object Of { get; private set; }

        public void oc(Image image, TcpClient client)
        {

            _ocr = new Tesseract("C:\\Emgu\\emgucv-windesktop 3.2.0.2682\\bin\\tessdata", "eng", OcrEngineMode.Default);
            _ocr.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZ-1234567890");
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=frame;";


          
            // Thread.Sleep(10000);
            // cap = new Emgu.CV.VideoCapture(0);
            //  Mat frame = new Mat();
            // frame = cap.QueryFrame();
            //  Mat frame = new Mat();
            //  Bitmap bitmap = new Bitmap(new Bitmap());
            Image < Bgr, Byte> img = new Image<Bgr, Byte>(new Bitmap(image));
            pictureBox1.Image = img.Bitmap;
            // Bitmap bitmap = new Bitmap(frame.Bitmap);
            // Image<Bgr, Byte> img = new Image<Bgr, Byte>(bitmap);
            // pictureBox1.Image = img.Bitmap;
            Image<Bgr, Byte> coppy= new Image<Bgr, Byte>(new Bitmap(image));
           UMat uimage = new UMat();
            CvInvoke.CvtColor(img, uimage, ColorConversion.Bgr2Gray);

            //use image pyr to remove noise
            UMat pyrDown = new UMat();
            CvInvoke.PyrDown(uimage, pyrDown);
            CvInvoke.PyrUp(pyrDown, uimage);

            Image<Gray, Byte> gray = img.Convert<Gray, Byte>().PyrDown().PyrUp();

            double cannyThreshold = 180.0;
            double cannyThresholdLinking = 120.0;


            Image<Gray, Byte> cannyEdges = gray.Canny(cannyThreshold, cannyThresholdLinking);
            LineSegment2D[] lines = cannyEdges.HoughLinesBinary(1, Math.PI / 45.0, 20, 30, 10)[0];
            pictureBox1.Image = cannyEdges.Bitmap;

            RotatedRect Patikrinimui = new RotatedRect(); //a box is a rotated rectangle
            RotatedRect boxList = new RotatedRect();
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                CvInvoke.FindContours(cannyEdges, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                int count = contours.Size;
                for (int i = 0; i < count; i++)
                {
                    using (VectorOfPoint contour = contours[i])
                    using (VectorOfPoint approxContour = new VectorOfPoint())
                    {
                        CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                        if (CvInvoke.ContourArea(approxContour, false) > 350) //only consider contours with area greater than 250
                        {

                            if (approxContour.Size == 4) //The contour has 4 vertices.
                            {
                                #region determine if all the angles in the contour are within [80, 100] degree
                                bool isRectangle = true;
                                Point[] pts = approxContour.ToArray();
                                LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                                for (int j = 0; j < edges.Length; j++)
                                {
                                    double angle = Math.Abs(
                                       edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));
                                    if (angle < 80 || angle > 100)
                                    {
                                        isRectangle = false;
                                        break;
                                    }



                                }
                                #endregion

                                if (isRectangle)
                                {

                                    Patikrinimui = CvInvoke.MinAreaRect(approxContour);
                                    double whRatio = (double)Patikrinimui.Size.Width / Patikrinimui.Size.Height;
                                    if ((1.0 < whRatio && whRatio < 8.0))
                                    {
                                        boxList = CvInvoke.MinAreaRect(approxContour);
                                    }
                                    // if (isRectangle)
                                    //  {
                                    //      boxList = CvInvoke.(approxContour);
                                    //  }
                                }
                            }
                        }
                    }



                    #region draw triangles and rectangles
                    Image<Bgr, Byte> triangleRectangleImage = img.Copy();


                    triangleRectangleImage.Draw(boxList, new Bgr(Color.White), 5);
                    pictureBox1.Image = triangleRectangleImage.Bitmap;
                    PointF[] points = boxList.GetVertices();
                    triangleRectangleImage.ROI = boxList.MinAreaRect();
                    triangleRectangleImage = triangleRectangleImage.Copy();
                    CvInvoke.cvResetImageROI(triangleRectangleImage);
                    pictureBox2.Image = triangleRectangleImage.Bitmap;
                    coppy = triangleRectangleImage;


                    #endregion
                }
            }
            Bitmap default_image = new Bitmap(coppy.Bitmap);
            OcrEngine ocr = new OcrEngine();

            Image imge = default_image;
            //Image<Bgr, Byte> imga = new Image<Bgr, Byte>(default_image);
            //CvInvoke.CvtColor(imga, uimage, ColorConversion.Bgr2Gray);

            ////use image pyr to remove noise
            //// UMat pyrDown = new UMat();
            //CvInvoke.PyrDown(uimage, pyrDown);
            //CvInvoke.PyrUp(pyrDown, uimage);

            //gray = imga.Convert<Gray, Byte>().PyrDown().PyrUp();
            //cannyEdges = gray.Canny(cannyThreshold, cannyThresholdLinking);
           // pictureBox2.Image = imge;

            var stream = new System.IO.MemoryStream();
            imge.Save(stream, ImageFormat.Png);
            stream.Position = 0;

            //  ocr.Image = Aspose.OCR.ImageStream.FromStream(stream, Aspose.OCR.ImageStreamFormat.Png);
            //  if (ocr.Process())
            // {
            //     textBox1.Text = " " + ocr.Text;
            //  }

            Bitmap bitmap = new Bitmap(imge);
            Image<Bgr, byte> imagi = new Image<Bgr, byte>(bitmap);
            _ocr.SetImage(imagi);
            _ocr.Recognize();
            string mep = _ocr.GetUTF8Text();
            char[] raides = mep.ToCharArray();
            string tekstas = "";
            for (int i = 0; i < raides.Length; i++)
            {
                if (Char.IsLetter(raides[i]) || Char.IsDigit(raides[i]))
                {

                    tekstas = tekstas + raides[i];
                }
            }
            char[] simboliai = tekstas.ToCharArray();

            for (int i = 3; i < simboliai.Length; i++)
            {
                if (simboliai[i].Equals('A'))
                {
                    simboliai.SetValue('4', i);
                }
            }
            tekstas = new string(simboliai);
            
            textBox1.Text = tekstas;
            byte[] mess = Encoding.ASCII.GetBytes(tekstas);

            string query = "SELECT * from tvarkarastis join valandos on tvarkarastis.ID=valandos.Masinos_id where tvarkarastis.Numeris='"+ tekstas+"' and CURRENT_TIME BETWEEN valandos.laiko_pradzia and valandos.laiko_pabaiga ";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                // Open the database
                databaseConnection.Open();

                // Execute the query
                reader = commandDatabase.ExecuteReader();

                // All succesfully executed, now do something

                // IMPORTANT : 
                // If your query returns result, use the following processor :

                if (reader.HasRows)
                {
                    tekstas = "leist";
                }
                else
                {
                   tekstas="Neleisti";
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }

             broadcastt(tekstas, true, client);
        }

        public void broadcastt(string msg, bool flag, TcpClient clients)
        {
          


            TcpClient broadcastSocket;
            broadcastSocket = clients;
            NetworkStream broadcastStream = broadcastSocket.GetStream();
            Byte[] broadcastBytes = null;
            broadcastBytes = Encoding.ASCII.GetBytes(msg);
            //if (flag == true)
            //{
            //    broadcastBytes = Encoding.ASCII.GetBytes(msg);
            //}
            //else
            //{
            //    broadcastBytes = Encoding.ASCII.GetBytes(msg);
            //}

            broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
            broadcastStream.Flush();

        }
        private void button1_Click(object sender, EventArgs e)
        {



        //    _ocr = new Tesseract("C:\\Emgu\\emgucv-windesktop 3.2.0.2682\\bin\\tessdata", "eng", OcrEngineMode.Default);
        //    _ocr.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZ-1234567890");
            
           

        //        // Thread.Sleep(10000);
        //        // cap = new Emgu.CV.VideoCapture(0);
        //        //  Mat frame = new Mat();
        //        // frame = cap.QueryFrame();
        //        Image<Bgr, Byte> img = new Image<Bgr, Byte>(od.FileName);
        //        pictureBox1.Image = img.Bitmap;
        //        // Bitmap bitmap = new Bitmap(frame.Bitmap);
        //        // Image<Bgr, Byte> img = new Image<Bgr, Byte>(bitmap);
        //       // pictureBox1.Image = img.Bitmap;

        //        UMat uimage = new UMat();
        //        CvInvoke.CvtColor(img, uimage, ColorConversion.Bgr2Gray);

        //        //use image pyr to remove noise
        //        UMat pyrDown = new UMat();
        //        CvInvoke.PyrDown(uimage, pyrDown);
        //        CvInvoke.PyrUp(pyrDown, uimage);

        //        Image<Gray, Byte> gray = img.Convert<Gray, Byte>().PyrDown().PyrUp();

        //        double cannyThreshold = 180.0;
        //        double cannyThresholdLinking = 120.0;


        //        Image<Gray, Byte> cannyEdges = gray.Canny(cannyThreshold, cannyThresholdLinking);
        //        LineSegment2D[] lines = cannyEdges.HoughLinesBinary(1, Math.PI / 45.0, 20, 30, 10)[0];
        //        pictureBox1.Image = cannyEdges.Bitmap;
            
        //        RotatedRect Patikrinimui= new RotatedRect(); //a box is a rotated rectangle
        //        RotatedRect boxList = new RotatedRect();
        //        using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
        //        {
        //            CvInvoke.FindContours(cannyEdges, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
        //            int count = contours.Size;
        //            for (int i = 0; i < count; i++)
        //            {
        //                using (VectorOfPoint contour = contours[i])
        //                using (VectorOfPoint approxContour = new VectorOfPoint())
        //                {
        //                    CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
        //                    if (CvInvoke.ContourArea(approxContour, false) > 350) //only consider contours with area greater than 250
        //                    {

        //                        if (approxContour.Size == 4) //The contour has 4 vertices.
        //                        {
        //                            #region determine if all the angles in the contour are within [80, 100] degree
        //                            bool isRectangle = true;
        //                            Point[] pts = approxContour.ToArray();
        //                            LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

        //                            for (int j = 0; j < edges.Length; j++)
        //                            {
        //                                double angle = Math.Abs(
        //                                   edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));
        //                                if (angle < 80 || angle > 100)
        //                                {
        //                                    isRectangle = false;
        //                                    break;
        //                                }


                                     
        //                            }
        //                            #endregion

        //                            if (isRectangle)
        //                            {

        //                                Patikrinimui = CvInvoke.MinAreaRect(approxContour);
        //                                double whRatio = (double)Patikrinimui.Size.Width / Patikrinimui.Size.Height;
        //                                if ((1.0 < whRatio && whRatio < 8.0))
        //                                {
        //                                    boxList= CvInvoke.MinAreaRect(approxContour);
        //                                }
        //                                // if (isRectangle)
        //                                //  {
        //                                //      boxList = CvInvoke.(approxContour);
        //                                //  }
        //                            }
        //                        }
        //                    }
        //                }



        //                #region draw triangles and rectangles
        //                Image<Bgr, Byte> triangleRectangleImage = img.Copy();


        //                triangleRectangleImage.Draw(boxList, new Bgr(Color.White), 5);
        //                pictureBox1.Image = triangleRectangleImage.Bitmap;
        //                PointF[] points = boxList.GetVertices();
        //                triangleRectangleImage.ROI = boxList.MinAreaRect();
        //                triangleRectangleImage = triangleRectangleImage.Copy();
        //                CvInvoke.cvResetImageROI(triangleRectangleImage);
        //                pictureBox2.Image = triangleRectangleImage.Bitmap;



        //                #endregion
        //            }
        //        }
        //        Bitmap default_image = new Bitmap(pictureBox2.Image);
        //        OcrEngine ocr = new OcrEngine();

        //        Image imge = default_image;
        //        //Image<Bgr, Byte> imga = new Image<Bgr, Byte>(default_image);
        //        //CvInvoke.CvtColor(imga, uimage, ColorConversion.Bgr2Gray);

        //        ////use image pyr to remove noise
        //        //// UMat pyrDown = new UMat();
        //        //CvInvoke.PyrDown(uimage, pyrDown);
        //        //CvInvoke.PyrUp(pyrDown, uimage);

        //        //gray = imga.Convert<Gray, Byte>().PyrDown().PyrUp();
        //        //cannyEdges = gray.Canny(cannyThreshold, cannyThresholdLinking);
        //        pictureBox2.Image = imge;

        //        var stream = new System.IO.MemoryStream();
        //        imge.Save(stream, ImageFormat.Png);
        //        stream.Position = 0;

        //        //  ocr.Image = Aspose.OCR.ImageStream.FromStream(stream, Aspose.OCR.ImageStreamFormat.Png);
        //        //  if (ocr.Process())
        //        // {
        //        //     textBox1.Text = " " + ocr.Text;
        //        //  }
                
        //        Bitmap bitmap = new Bitmap(imge);
        //        Image<Bgr, byte> imagi = new Image<Bgr, byte>(bitmap);
        //        _ocr.SetImage(imagi);
        //        _ocr.Recognize();
        //        string mep= _ocr.GetUTF8Text();
        //        char[] raides = mep.ToCharArray();
        //        string tekstas="";
        //        for(int i=0;i<raides.Length;i++)
        //        {
        //            if(Char.IsLetter(raides[i])||Char.IsDigit(raides[i]))
        //            {
                        
        //                tekstas = tekstas + raides[i];
        //            }
        //        }
        //        char[] simboliai = tekstas.ToCharArray();

        //        for (int i=3;i<simboliai.Length;i++)
        //        {
        //            if (simboliai[i].Equals('A'))
        //            {
        //                simboliai.SetValue('4', i);
        //            }
        //        }
        //        tekstas = new string(simboliai);
        //        textBox1.Text = tekstas;

            


        }

    }
}