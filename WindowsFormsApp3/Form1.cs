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
using System.Net.Mail;

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



            //create the mail message
            MailMessage mail = new MailMessage();

            //set the addresses
            mail.From = new MailAddress("ali_grkn_ky@hotmail.com");
            mail.To.Add("resimalarintel@outlook.com");

            //set the content
            mail.Subject = "This is an email";

            //first we create the Plain Text part
            AlternateView plainView = AlternateView.CreateAlternateViewFromString("alternate", null, "text/plain");


            //then we create the Html part
            //to embed images, we need to use the prefix 'cid' in the img src value
            //the cid value will map to the Content-Id of a Linked resource.
            //thus <img src='cid:companylogo'> will map to a LinkedResource with a ContentId of 'companylogo'
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString("<img src=cid:companylogo>", null, "text/html");

            //create the LinkedResource (embedded image)
            LinkedResource logo = new LinkedResource(@"C:\Users\Asus\Desktop\Anniversary_" + name + ".png", "image/jpeg");
            logo.ContentId = "companylogo";
            //add the LinkedResource to the appropriate view
            htmlView.LinkedResources.Add(logo);

            //add the views
            mail.AlternateViews.Add(plainView);
            mail.AlternateViews.Add(htmlView);

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials =

                new System.Net.NetworkCredential("ali_grkn_ky@hotmail.com", "19951995_?");//kullanici adi ve sifre sicili

            smtp.Port = 587;

            smtp.Host = "smtp.office365.com";
            smtp.EnableSsl = true;

            smtp.Send(mail);

           


        }

       
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
