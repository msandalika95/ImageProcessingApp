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

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        private int contrast;

        public Form3(Image pic1)
        {
            InitializeComponent();
            pictureBox2.Image = pic1;
        }

        public Form3()
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {  
        }

        private void button1_Click(object sender, EventArgs e)
        { 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           // radioButton1.Checked = true;
            //radioButton2.Checked = true;
            //radioButton3.Checked = true;
          
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            /* Bitmap bmp = (Bitmap)Image.FromFile(pictureBox2.ImageLocation);

             for (int x = 0; x < bmp.Width; x++)
             {
                 for (int y = 0; y < bmp.Height; y++)
                 {
                     bmp.GetPixel(x, y);
                     bmp.SetPixel(x, y, Color.FromArgb(128, 0, 128));
                 }
             }

             pictureBox3.Image = bmp;
             MessageBox.Show("Done");
            */

            Bitmap bmap = (Bitmap)pictureBox2.Image;
            Bitmap bimap = (Bitmap)bmap.Clone();
            for (int y = 0; y < bmap.Height; y++)
            {
                for (int x = 0; x < bmap.Width; x++)
                {
                    Color c = bmap.GetPixel(x, y);
                    int nPixelR = 0;
                    int nPixelG = 0;
                    int nPixelB = 0;

                    if (radioButton1.Checked == true)
                    {
                        nPixelR = c.R;
                        nPixelG = c.G - 255;
                        nPixelB = c.B - 255;

                        // bmap.SetPixel(x, y, Color.FromArgb(c.R, c.G - 255, c.B - 255)) ;
                    }
                    else if (radioButton2.Checked == true)
                    {
                        nPixelR = c.R - 255;
                        nPixelG = c.G;
                        nPixelB = c.B - 255;

                        //bmap.SetPixel(x, y, Color.FromArgb(c.R-255,c.G, c.B-255));
                    }
                    else
                    {
                        nPixelR = c.R - 255;
                        nPixelG = c.G - 255;
                        nPixelB = c.B;

                        //bmap.SetPixel(x, y, Color.FromArgb(c.R-255, c.G-255,c.B));
                    }
                    nPixelR = Math.Max(nPixelR, 0);
                    nPixelR = Math.Min(255, nPixelR);

                    nPixelG = Math.Max(nPixelG, 0);
                    nPixelG = Math.Min(255, nPixelG);

                    nPixelB = Math.Max(nPixelB, 0);
                    nPixelB = Math.Min(255, nPixelB);

                    bmap.SetPixel(x, y, Color.FromArgb((byte)nPixelR,
                   (byte)nPixelG, (byte)nPixelB));

                }
                //To show edited(filtered image)
                 pictureBox3.Image = (Bitmap)bmap;
                


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //To clear existing image
            pictureBox3.Image = null;
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //link to the next form using next button
            Form7 frm7 = new Form7(pictureBox3.Image);
            frm7.Show();
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //To apply gray scale to original image 
            Bitmap bmap = (Bitmap)pictureBox2.Image;
            Color c;
            for (int x = 0; x < bmap.Width; x++)
            {
                for (int y = 0; y < bmap.Height; y++)
                {
                    c = bmap.GetPixel(x, y);
                    byte gray = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);

                    bmap.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            pictureBox3.Image = (Bitmap)bmap;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap bmap = (Bitmap)pictureBox2.Image;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    bmap.SetPixel(i, j,
      Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                }
            }
            pictureBox3.Image = (Bitmap)bmap;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap bmap = (Bitmap)pictureBox2.Image;
            //To rotate image along horizontal axis
            bmap.RotateFlip(RotateFlipType.Rotate180FlipY);
            pictureBox3.Image = (Bitmap)bmap;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Bitmap bmap = (Bitmap)pictureBox2.Image;
            if (contrast < -250) contrast = -250;
            if (contrast > 250) contrast = 250;
            contrast = (int)((250.0 + contrast) / 250.0);
            contrast *= contrast;
            Color c;

            //X axis
            for (int i = 0; i < bmap.Width; i++)
            {
                //Y axis
                for (int j = 0; j < bmap.Height; j++)
                {
                    //Consider pixel by pixel
                    c = bmap.GetPixel(i, j);

                    //For RED colored pixels
                    double r = c.R / 255.0;
                    r -= 0.5;
                    r *= contrast;
                    r += 0.5;
                    r *= 255;
                    if (r < 0) r = 0;
                    if (r > 255) r = 255;

                    //For GREEN colored pixels
                    double g = c.G / 255.0;
                    g -= 0.5;
                    g *= contrast;
                    g += 0.5;
                    g *= 255;
                    if (g < 0) g = 0;
                    if (g > 255) g = 255;

                    //For BLUE colored pixels
                    double b = c.B / 255.0;
                    b -= 0.5;
                    b *= contrast;
                    b += 0.5;
                    b *= 255;
                    if (b < 0) b = 0;
                    if (b > 255) b = 255;

                    bmap.SetPixel(i, j,
        Color.FromArgb((byte)r, (byte)g, (byte)b));
                }
            }
            pictureBox3.Image = (Bitmap)bmap;
        }
    }
}
