using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mmind.apiSharp;
using System.Drawing.Imaging;


namespace CaptureCloudFromDepth
{

    public partial class ShowMap : Form
    {

        public ShowMap()
        {
            InitializeComponent();
        }
        //public void SetABCDEFG(int cnt)
        //{
        //    _cnt = cnt;
        //}

        public void SetColor(ref mmind.apiSharp.ColorMap _color)
        {
            color = _color;
        }
        public void SetDepth(ref mmind.apiSharp.DepthMap _depth)
        {
            depth = _depth;
        }

        private mmind.apiSharp.ColorMap color;
        private mmind.apiSharp.DepthMap depth;
        //private int _cnt;


        private void cMap_Click(object sender, EventArgs e) 
        {
            Bitmap img = new Bitmap("C:\\Users\\mech-mind\\Desktop\\ColorMap.png");
            int w = img.Width;
            int h = img.Height;
            int _picWidth = w;
            int _picHeight = h;
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            cMap.Image = img;
        }


        private void ShowMap_Load(object sender, EventArgs e)
        {

        }

        private void btn_depth_Click(object sender, EventArgs e)
        {
            Bitmap dbitmap = new Bitmap((int)depth.width(), (int)depth.height());
            Console.WriteLine("image size : {0}  {1}", (int)depth.width(), (int)depth.height());
            int width = (int)depth.width(), height = (int)depth.height();//图片的宽度和高度
                                                                         //在内存中以读写模式锁定Bitmap
            BitmapData bitmapData = dbitmap.LockBits(
            new Rectangle(0, 0, width, height),
            ImageLockMode.ReadWrite,
            PixelFormat.Format32bppRgb);
            //图片像素点数组的长度，由于一个像素点占了3个字节，所以要乘上3
            int size = width * height * 3;
            //缓冲区数组
            byte[] srcArray = new byte[size];
            //获取第一个像素的地址
            IntPtr ptr = depth.data();
            //把像素值复制到缓冲区
            System.Runtime.InteropServices.Marshal.Copy(ptr, srcArray, 0, size);
            System.Runtime.InteropServices.Marshal.Copy(srcArray, 0, bitmapData.Scan0, size);
            //从内存中解锁
            dbitmap.UnlockBits(bitmapData);
            cMap.Image = dbitmap;
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            Bitmap cbitmap = new Bitmap((int)color.width(), (int)color.height());
            Console.WriteLine("image size : {0}  {1}", (int)color.width(), (int)color.height());
            int width = (int)color.width(), height = (int)color.height();//图片的宽度和高度
                                                                         //在内存中以读写模式锁定Bitmap
            BitmapData bitmapData = cbitmap.LockBits(
            new Rectangle(0, 0, width, height),
            ImageLockMode.ReadWrite,
            PixelFormat.Format24bppRgb);
            //图片像素点数组的长度，由于一个像素点占了3个字节，所以要乘上3
            int size = width * height * 3;
            //缓冲区数组
            byte[] srcArray = new byte[size];
            //获取第一个像素的地址
            IntPtr ptr = color.data();
            //把像素值复制到缓冲区
            System.Runtime.InteropServices.Marshal.Copy(ptr, srcArray, 0, size);
            System.Runtime.InteropServices.Marshal.Copy(srcArray, 0, bitmapData.Scan0, size);
            //从内存中解锁
            cbitmap.UnlockBits(bitmapData);
            cMap.Image = cbitmap;
        }

    }

}
