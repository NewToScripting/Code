using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Server.Proxy;
using Server.Proxy.SlideFileServiceReference;
using Server.Proxy.SlidesServiceReference;

namespace Inspire.SlideManager.Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
           Slides slides = SlideManager.GetSlides();
           dataGridView1.DataSource = slides;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Slide slide = new Slide();

            slide.GUID = Guid.NewGuid().ToString();
            slide.Name = "Panch Haircutters";
            

            SlideManager.AddSlide(slide);
            dataGridView1.DataSource = slide;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Slide slide = new Slide();

            slide.GUID = "c9e97ed0-31a2-4148-86cb-f8c78333a56d";
            slide.Name = "Panch Haircutters Updated";


            SlideManager.UpdateSlide(slide);
            dataGridView1.DataSource = slide;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SlideManager.DeleteSlide("19a535eb-f51a-42cc-94a0-1b91b0ded3bb");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SlideFile slidefile = SlideFileManager.GetSlideFile("c9e97ed0-31a2-4148-86cb-f8c78333a56d");
            txtBox1.Text = slidefile.GUID;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SlideFile slide = new SlideFile();

            slide.GUID = Guid.NewGuid().ToString();
            //slide.Name = "Panch Haircutters";


            SlideFileManager.AddSlideFile(slide);
         
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SlideFile slide = new SlideFile();

            slide.GUID = "c9e97ed0-31a2-4148-86cb-f8c78333a56d";
            //slide.Name = "Panch Haircutters Updated";


            SlideFileManager.UpdateSlideFile(slide);
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SlideFileManager.DeleteSlideFile("aa118402-9280-4b6c-8629-ce41221ed0d9");
        }
    }
}