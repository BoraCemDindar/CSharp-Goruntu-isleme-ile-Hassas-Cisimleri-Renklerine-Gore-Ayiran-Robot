using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

using AForge;
using AForge.Imaging.Filters;

using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Vision;
using AForge.Vision.Motion;

namespace goruntu_isleme
{
    public partial class Form1 : Form
    {
        int kirm, yess, mavv;
        SerialPort sPort;
        //Siniflarin nesneleri tanimlaniyor
        private VideoCaptureDevice FinalVideoSource;
        private FilterInfoCollection VideoCaptuerDevices;
        public Form1()
        {
            sPort = new SerialPort();
            sPort.BaudRate = 9600;
            InitializeComponent();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            VideoCaptuerDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo VideoCaptureDevice in VideoCaptuerDevices)
            {
                comboBox1.Items.Add(VideoCaptureDevice.Name);
                comboBox1.SelectedIndex = 0;
            }
        }


        public void ArduinoBaglan()
        {
            try
            {
                sPort.PortName = txtCom.Text; //sPort nesnesinin ismini textbox ile eşitliyoruz
                if (!sPort.IsOpen) //eğer bağlantı açıksa diyerek oluşan durumları yazıyoruz
                {
                    sPort.Open();
                    label1.Text = "Bağlantı Kuruldu";
                    label1.ForeColor = Color.Green; //yazı rengini yeşil yapıyoruz
                    label1.Visible = true; //başlangıçta kapalı olan durum labelı
                }
            }
            catch
            {
                label1.Text = "Bağlantı Kurulamadı";
                label1.ForeColor = Color.Red; //yazı rengini kırmızı yapıyoruz
                label1.Visible = true; //başlangıçta kapalı olan durum labelını açıyoruz
            }
            
        }

        public void KameraAc()
        {
            FinalVideoSource = new VideoCaptureDevice(VideoCaptuerDevices[comboBox1.SelectedIndex].MonikerString);//1.User ist gewählt
            FinalVideoSource.NewFrame += new NewFrameEventHandler(FinalVideoSource_NewFrame);
            FinalVideoSource.DesiredFrameRate = 30;                  // Görüntü kalitesi
            FinalVideoSource.DesiredFrameSize = new Size(320, 240);  // Görüntü büyüklügü

            FinalVideoSource.Start();
            //timer1.Enabled = true;
        }

        void FinalVideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            Bitmap image1 = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = image;
        }
        public void KameraKapat()
        {
            if (FinalVideoSource.IsRunning)
            {
                FinalVideoSource.Stop(); // kamerayı durduruyoruz. - yazilimciamca.net
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            ArduinoBaglan();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KameraAc();
            System.Threading.Thread.Sleep(2000);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KameraKapat();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Image img = pictureBox1.Image;
            Bitmap bmp = new Bitmap(img);
            int kirmizi;
            int yesil;
            int mavi;
            Int32 i = 53;
            Int32 j = 70;
            Color renk = bmp.GetPixel(i, j);
            kirmizi = renk.R;
            yesil = renk.G;
            mavi = renk.B;
            int kirmiz;
            int yesi;
            int mav;
            Int32 x = 214;
            Int32 y = 41;
            Color ren = bmp.GetPixel(x, y);
            kirmiz = ren.R;
            yesi = ren.G;
            mav = ren.B;    
            int kirmizn;
            int yesin;
            int mavn;
            Int32 xn =400;
            Int32 yn = 10;
            Color renn = bmp.GetPixel(xn, yn);
            kirmizn = renn.R;
            yesin = renn.G;
            mavn = renn.B;
            if (kirmizi > yesil)
            {
                if (kirmizi > mavi)
                {
                    label2.Text = "kırmızı";
                    kirm = 10;

                }
                else
                {
                    label2.Text = "mavi";
                    kirm = 20;
                }
            }
            else
            {
                if (yesil > mavi)
                {
                    label2.Text = "yeşil";
                    kirm = 30;
                }
                else
                {
                    label2.Text = "mavi";
                    kirm = 20;
                }
            }
            if (kirmiz > yesi)
                {
                    if (kirmiz > mav)
                    {
                        label3.Text = "kırmızı";
                    yess = 100;

                    }
                    else
                    {
                        label3.Text = "mavi";
                    yess = 200;
                    }
                }
                else
                {
                    if (yesi > mav)
                    {
                        label3.Text = "yeşil";
                    yess = 300;
                    }
                    else
                    {
                        label3.Text = "mavi";
                    yess = 200;
                    }
            }
            if (kirmizn > yesin)
                    {
                        if (kirmizn > mavn)
                        {
                            label4.Text = "kırmızı";
                    mavv = 1000;


                        }
                        else
                        {
                            label4.Text = "mavi";
                    mavv = 2000;

                        }
                    }
                    else
                    {
                        if (yesin > mavn)
                        {
                            label4.Text = "yeşil";
                    mavv = 3000;
                }
                        else
                        {
                            label4.Text = "mavi";
                    mavv = 2000;
                }
    
            }      
}

        private void button5_Click(object sender, EventArgs e)
        {

            int xx = 10;
            string motorx = textBox2.Text.ToString();
            
            string xxx = xx.ToString();


            try
            {


                sPort.Write("a");

                sPort.WriteLine("d");
                sPort.WriteLine(",");

                sPort.WriteLine(xxx);
                sPort.WriteLine("/");

                sPort.WriteLine(motorx);
                sPort.WriteLine(";");




            }
            catch (Exception ex) { }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int xx = 20;
            string motory = textBox3.Text.ToString();
            string xxx = xx.ToString();


            try
            {


                sPort.Write("a");

                sPort.WriteLine("d");
                sPort.WriteLine(",");

                sPort.WriteLine(xxx);
                sPort.WriteLine("/");

                sPort.WriteLine(motory);
                sPort.WriteLine(";");

                sPort.WriteLine(motory);
                sPort.WriteLine(":");


            }
            catch (Exception ex) { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int xx = 30;
            string motorz = textBox4.Text.ToString();
            string xxx = xx.ToString();


            try
            {


                sPort.Write("a");

                sPort.WriteLine("d");
                sPort.WriteLine(",");

                sPort.WriteLine(xxx);
                sPort.WriteLine("/");

                sPort.WriteLine(motorz);
                sPort.WriteLine(";");

                sPort.WriteLine(motorz);
                sPort.WriteLine(":");

                sPort.WriteLine(motorz);
                sPort.WriteLine("<");


            }
            catch (Exception ex) { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int xx = 40;
            string motorx = textBox2.Text.ToString();
            string motory = textBox3.Text.ToString();
            string motorz = textBox4.Text.ToString();
            string motort = textBox5.Text.ToString();
            string xxx = xx.ToString();


            try
            {


                sPort.Write("a");

                sPort.WriteLine("d");
                sPort.WriteLine(",");

                sPort.WriteLine(xxx);
                sPort.WriteLine("/");

                sPort.WriteLine(motorx);
                sPort.WriteLine(";");

                sPort.WriteLine(motory);
                sPort.WriteLine(":");

                sPort.WriteLine(motorz);
                sPort.WriteLine("<");

                sPort.WriteLine(motort);
                sPort.WriteLine(">");


            }
            catch (Exception ex) { }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int xx = 50;
            string motorx = textBox2.Text.ToString();
            string motory = textBox3.Text.ToString();
            string motorz = textBox4.Text.ToString();
            string motort = textBox5.Text.ToString();
            string xxx = xx.ToString();


            try
            {


                sPort.Write("a");

                sPort.WriteLine("d");
                sPort.WriteLine(",");

                sPort.WriteLine(xxx);
                sPort.WriteLine("/");

                sPort.WriteLine(motorx);
                sPort.WriteLine(";");

                sPort.WriteLine(motory);
                sPort.WriteLine(":");

                sPort.WriteLine(motorz);
                sPort.WriteLine("<");

                sPort.WriteLine(motort);
                sPort.WriteLine(">");


            }
            catch (Exception ex) { }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int xx = 11;
            string xxx = xx.ToString();


            try
            {


                sPort.Write("a");

                sPort.WriteLine("d");
                sPort.WriteLine(",");

                sPort.WriteLine(xxx);
                sPort.WriteLine("/");

                
            }
            catch (Exception ex) { }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int xx = 12;
            string xxx = xx.ToString();


            try
            {


                sPort.Write("a");

                sPort.WriteLine("d");
                sPort.WriteLine(",");

                sPort.WriteLine(xxx);
                sPort.WriteLine("/");







                //sPort.WriteLine(angle4);
                //sPort.WriteLine("&");

                //sPort.WriteLine(angle5);
                //sPort.WriteLine("%");

                //System.Threading.Thread.Sleep(100);
                //MessageBox.Show("Gönderildi");
            }
            catch (Exception ex) { }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int xx = 60;
            int konum2 =10;
            int konum3 = 10;

            string kirmiziii = kirm.ToString();
            string maviii = mavv.ToString();
            string yesilll = yess.ToString();
            string xxx = xx.ToString();
            string konumm2 = konum2.ToString();
            string konumm3 = konum3.ToString();
            string motorx = textBox2.Text.ToString();
            string motory = textBox3.Text.ToString();
            string motorz = textBox4.Text.ToString();
            string motort = textBox5.Text.ToString();


            try
            {


                sPort.Write("a");

                sPort.WriteLine("d");
                sPort.WriteLine(",");

                sPort.WriteLine(xxx);
                sPort.WriteLine("/");
                sPort.WriteLine(motorx);
                sPort.WriteLine(";");

                sPort.WriteLine(motory);
                sPort.WriteLine(":");

                sPort.WriteLine(motorz);
                sPort.WriteLine("<");

                sPort.WriteLine(motort);
                sPort.WriteLine(">");


                sPort.WriteLine(kirmiziii);
                sPort.WriteLine("*");

                sPort.WriteLine(maviii);
                sPort.WriteLine("-");

                sPort.WriteLine(yesilll);
                sPort.WriteLine("+");
                sPort.WriteLine(konumm2);
                sPort.WriteLine("?");
                sPort.WriteLine(konumm3);
                sPort.WriteLine("#");

            }
            catch (Exception ex) { }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int xx = 50;
            int mx = 0;
            int my = 0;
            int mz = 0;
            string motorx = mx.ToString();
            string motory = my.ToString();
            string motorz = mz.ToString();
            string xxx = xx.ToString();


            try
            {


                sPort.Write("a");

                sPort.WriteLine("d");
                sPort.WriteLine(",");

                sPort.WriteLine(xxx);
                sPort.WriteLine("/");

                sPort.WriteLine(motorx);
                sPort.WriteLine(";");

                sPort.WriteLine(motory);
                sPort.WriteLine(":");

                sPort.WriteLine(motorz);
                sPort.WriteLine("<");

            }
            catch (Exception ex) { }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int xx = 50;
            int mx = 10;
            int my = 60;
            int mz = 0;
            string motorx = mx.ToString();
            string motory = my.ToString();
            string motorz = mz.ToString();
            string xxx = xx.ToString();


            try
            {


                sPort.Write("a");

                sPort.WriteLine("d");
                sPort.WriteLine(",");

                sPort.WriteLine(xxx);
                sPort.WriteLine("/");

                sPort.WriteLine(motorx);
                sPort.WriteLine(";");

                sPort.WriteLine(motory);
                sPort.WriteLine(":");

                sPort.WriteLine(motorz);
                sPort.WriteLine("<");

            }
            catch (Exception ex) { }
        }
    }
}
