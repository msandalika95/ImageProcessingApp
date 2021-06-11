using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form7 : Form
    {
        private Image pic1;

        public Form7(Image pic1)
        {
            InitializeComponent();
            pictureBox3.Image = pic1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = (@"C:\Users\ardha\Desktop");
            saveFile.Filter = "Image Files(*.jpg, *.png, *.tiff, *.bmp, *.gif) | *.jpg; *.png; *.tiff; *.bmp; *.gif";
            saveFile.Title = "Save an image";
            saveFile.AddExtension = true;
            saveFile.DefaultExt = "bmp";
            saveFile.FilterIndex = 2;
            saveFile.RestoreDirectory = true;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string fName = saveFile.FileName;
                pictureBox3.Image.Save(fName, ImageFormat.Bmp);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
