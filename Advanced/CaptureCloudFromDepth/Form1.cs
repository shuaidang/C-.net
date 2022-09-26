using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;


namespace CaptureCloudFromDepth
{
    
    public partial class ShowMap : Form
    {
        public ShowMap()
        {
            InitializeComponent();
          
        }

        public void SetColor(ref mmind.apiSharp.ColorMap _color)
        {
            color = _color;
        }
        public void SetDepth(ref mmind.apiSharp.DepthMap _depth)
        {
            depth = _depth;
        }
        public void Device(ref mmind.apiSharp.MechEyeDevice _device)
        {
            device = _device;
        }
        //mmind.apiSharp.ColorMap color = new mmind.apiSharp.ColorMap();
        private mmind.apiSharp.ColorMap color;
        private mmind.apiSharp.DepthMap depth;
        private mmind.apiSharp.MechEyeDevice device;
        private Thread t1,t2;
        int i = 0;


        private void ShowMap_Load(object sender, EventArgs e)
        {
 
        }

        public void btn_depth_Click(object sender, EventArgs e)
        {
            device.captureDepthMap(ref depth);
            Bitmap dbitmap = new Bitmap((int)depth.width(), (int)depth.height());
            Console.WriteLine("image size : {0}  {1}", (int)depth.width(), (int)depth.height());
            int width = (int)depth.width(), height = (int)depth.height();
            BitmapData bitmapData = dbitmap.LockBits(
            new Rectangle(0, 0, width, height),
            ImageLockMode.ReadWrite,
            PixelFormat.Format32bppRgb);
            int size = width * height * 3;
            byte[] srcArray = new byte[size];
            IntPtr ptr = depth.data();
            System.Runtime.InteropServices.Marshal.Copy(ptr, srcArray, 0, size);
            System.Runtime.InteropServices.Marshal.Copy(srcArray, 0, bitmapData.Scan0, size);
            dbitmap.UnlockBits(bitmapData);
            cMap.Image = dbitmap;
            dbitmap.Save(@"dbitmap.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            Console.WriteLine("Save Depthmap successfully");
        }

        public void btn_color_Click(object sender, EventArgs e)
        {
            device.captureColorMap(ref color);
            Bitmap cbitmap = new Bitmap((int)color.width(), (int)color.height());
            int width = (int)color.width(), height = (int)color.height();
            BitmapData bitmapData = cbitmap.LockBits(
            new Rectangle(0, 0, width, height),
            ImageLockMode.ReadWrite,
            PixelFormat.Format24bppRgb);
            int size = width * height * 3;
            byte[] srcArray = new byte[size];
            IntPtr ptr = color.data();
            System.Runtime.InteropServices.Marshal.Copy(ptr, srcArray, 0, size);
            System.Runtime.InteropServices.Marshal.Copy(srcArray, 0, bitmapData.Scan0, size);
            cbitmap.UnlockBits(bitmapData);
            cMap.Image = cbitmap;
            cbitmap.Save(@"cbitmap.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            Console.WriteLine("Save Colormap successfully");
        }

        public void btn_liveimg_Click(object sender, EventArgs e)
        {

           
            t2 = new Thread(new ThreadStart(livecolor));
            t2.Start();


        }

        public void btn_livedepth_Click(object sender, EventArgs e)
        {

            t1 = new Thread(new ThreadStart(livedepth));
            t1.Start();

        }

        public void livedepth()
        {
            i = 0;
            while (i < 1)
            {
                device.captureDepthMap(ref depth);
                Bitmap ddbitmap = new Bitmap((int)depth.width(), (int)depth.height());
                Console.WriteLine("image size : {0}  {1}", (int)depth.width(), (int)depth.height());
                int width = (int)depth.width(), height = (int)depth.height();
                BitmapData bitmapData = ddbitmap.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format32bppRgb);
                int size = width * height * 3;
                byte[] srcArray = new byte[size];
                IntPtr ptr = depth.data();
                System.Runtime.InteropServices.Marshal.Copy(ptr, srcArray, 0, size);
                System.Runtime.InteropServices.Marshal.Copy(srcArray, 0, bitmapData.Scan0, size);
                ddbitmap.UnlockBits(bitmapData);
                cMap.Image = ddbitmap;
            }
        }
        public void livecolor()
        {
            i = 0;
            while (i < 1)
            {
                
                device.captureColorMap(ref color);
                Bitmap ccbitmap = new Bitmap((int)color.width(), (int)color.height());
                Console.WriteLine("image size : {0}  {1}", (int)color.width(), (int)color.height());
                int width = (int)color.width(), height = (int)color.height();
                BitmapData bitmapData = ccbitmap.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);
                int size = width * height * 3;
                byte[] srcArray = new byte[size];
                IntPtr ptr =  color.data();
                System.Runtime.InteropServices.Marshal.Copy(ptr, srcArray, 0, size);
                System.Runtime.InteropServices.Marshal.Copy(srcArray, 0, bitmapData.Scan0, size);
                ccbitmap.UnlockBits(bitmapData);
                cMap.Image = ccbitmap;

            }

        }

        private void btn_stoplive_Click(object sender, EventArgs e)
        {

             i = 1;

        }

    }

}
