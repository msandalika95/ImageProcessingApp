using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             //this.BackColor = Color.DarkSlateGray;
            //this.BackgroundImage = Image.FromFile("C:\Users\USER\Pictures\ImageProcessing\b.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if ((this.textBox1.Text == "sandali") && (this.textBox2.Text == "1234"))
            {
                MessageBox.Show(" You are granted with access ");
                Form2 frm2 = new Form2();
                frm2.Show();
            }
            else {
                MessageBox.Show(" You are not granted with access ");
            }   
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           // pictureBox1.Image = new Bitmap(@"C:\Users\USER\Pictures\ImageProcessing\a.png");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
