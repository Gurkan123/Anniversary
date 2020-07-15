using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string name = "esin";




            Bitmap myBitmap = new Bitmap(@"C:\Users\Asus\Desktop\picture.png");
            Graphics g = Graphics.FromImage(myBitmap);
           


            var nameUpper = name.ToUpper();
            var metin = "Sevgili "+nameUpper+" ,\n\nBugün Philips\nailemize katılmanın\nyıl dönümü.\nNe mutlu bize!\nBirlikte çalışıp\nbirlikte güleceğimiz\nnice yıllara...";




            Color rgb = Color.FromArgb(77, 42, 98);
            SolidBrush drawBrush = new SolidBrush(rgb);

            StringFormat strFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            

            g.DrawString(metin,
                         new Font("Open Sans", 14, FontStyle.Bold), drawBrush,
                         new RectangleF(0, 0, 1070, 800),
                         strFormat);

            var kayit = (@"C:\Users\Asus\Desktop\Anniversary_"+name+".png");
            myBitmap.Save(kayit);


        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
