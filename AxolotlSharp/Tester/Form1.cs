using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester
{
    public partial class Form1 : Form
    {
        AxolotlSharp.AxolotlSharp t = new AxolotlSharp.AxolotlSharp();

        public Form1()
        {
            InitializeComponent();


            NewPic();
            

        }

        private void NewPic()
        {
            var ax = t.GetResponse();

            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = new Bitmap(GetStreamFromUrl(ax.url));

            this.Text = ax.facts;
        }

        private static Stream GetStreamFromUrl(string url)
        {
            byte[] imageData = null;

            using (var wc = new System.Net.WebClient())
                imageData = wc.DownloadData(url);

            return new MemoryStream(imageData);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1200;
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //NewPic();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NewPic();
        }
    }
}
