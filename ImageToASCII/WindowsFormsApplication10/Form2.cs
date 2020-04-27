using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication10
{
    public partial class Form2 : Form
    {
        char[] characters = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '+', '=', '`', '~', '{', '}', '[', ']', ';', ':', '<', '>', '.', ',', '|', '?' };
        public Form2()
        {
            InitializeComponent();
        }

        void OpeningImage()
        {
            OpenFileDialog imageOpen = new OpenFileDialog();
            if (imageOpen.ShowDialog() == DialogResult.OK)
            {
                label2.Text = imageOpen.FileName;
                pictureBox1.ImageLocation = imageOpen.FileName;
            }
        }

        void Gryscaling()
        {
            try
            {
                Bitmap image1 = new Bitmap(pictureBox1.Image);
                progressBar1.Maximum = image1.Height;
                for (int y = 0; y < image1.Height; y++)
                {
                    for (int x = 0; x < image1.Width; x++)
                    {
                        Color p = image1.GetPixel(x, y);
                        int a = p.A;
                        int r = p.R;
                        int g = p.G;
                        int b = p.B;
                        int avg = (r + g + b) / 3;
                        image1.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                    }
                    progressBar1.Value = y;
                }
                progressBar1.Value = 0;
                pictureBox2.Image = image1;
                MessageBox.Show("Finished");
                //panel1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Saving()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label4.Text = saveFileDialog1.FileName;
               // blahblah1 = 1;
            }
           // if (blahblah0 == 1)
           // {
            //    button5.Enabled = true;
            //}
        }
        void nnn()
        {
            try
            {
                string filepath = label4.Text;
                if (!File.Exists(filepath))
                {
                    label5.Text = "Creating...";
                    File.WriteAllText(filepath, Environment.NewLine);
                    label5.Text = "Created";
                }
                Bitmap imagex = new Bitmap(pictureBox2.Image);
                progressBar2.Maximum = imagex.Height;
                label5.Text = "Proccessing...";
                for (int y = 0; y < imagex.Height; y++)
                {
                    for (int x = 0; x < imagex.Width; x++)
                    {
                        Color p = imagex.GetPixel(x, y);
                        float bb = (((p.R + p.G + p.B) / 3)/255)*90;
                        label7.Text = Convert.ToString(bb);
                        int aa = Convert.ToInt32(bb);
                        label8.Text = Convert.ToString(aa);
                        if (aa == 90)
                        {
                            File.AppendAllText(filepath,"  ");
                        }
                        else
                        {
                            File.AppendAllText(filepath,Convert.ToString(characters[aa+1]));
                            File.AppendAllText(filepath, Convert.ToString(characters[aa+1]));
                        }

                    }
                    File.AppendAllText(filepath, Environment.NewLine);
                    progressBar2.Value = y;
                }
                progressBar2.Value = 0;
                label5.Text = "Done";
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpeningImage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Gryscaling();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Saving();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            nnn();
        }
    }
}
