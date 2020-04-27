/*
                                        1111111111111111111111                                      
                                  111111111111            1111111111                                
                              11111111                            111111                            
                          111111            1111111111111111          111111                        
                        1111          1111111111111111111111111111        1111                      
                      1111      11111111111111111111111111111111111111      11                      
                  1111        1111111111111111111111111111111111111111111111  11                    
                1111      11111111111111111111111111111111111111111111111111111111                  
                11      111111111111111111111111111111111111111111111111111111  1111                
              11      1111111111111111111111111111111111111111111111111111111111  1111              
            1111    11111111111111111111111111111111111111111111111111111111111111  1111            
            11    11111111111111111111111111111111111111111111111111    1111111111    1111          
          11    1111111111111111111111111111111111111111111111111111    111111111111    11          
        1111    1111111111  1111111111111111111111111111111111111111    11111111111111  1111        
        11    111111111111  111111111111111111    1111111111111111    1111111111111111    11        
        11    11111111111111  1111111111111111      11111111111111      1111111111111111  1111      
      1111  111111111111111111  111111111111        111111111111111111111111111111111111    11      
      11    111111111111111111  111111111111    1111  1111111111  1111111111111111111111    1111    
      11    11111111111111  1111  11111111      1111    11111111  111111111111111111111111  1111    
    1111  1111111111111111  1111  11111111    11111111  111111  111111  111111111111111111    11    
    1111  111111111111111111  1111111111      1111111111111111  111111  111111111111111111    11    
    1111  111111111111111111  1111111111    111111111111111111  111111  111111111111111111    1111  
    11    111111111111111111  1111111111    11111111111111    11111111  111111111111111111    1111  
    11    111111111111111111  1111111111    1111111111111111    111111  111111111111111111    1111  
    11    111111111111111111  11111111    111111111111111111    111111  11111111111111111111  1111  
    11    111111111111111111  11111111    111111111111111111    111111  111111111111111111    11    
    1111  111111111111111111    111111    1111111111111111    11  1111  111111111111111111    11    
    1111  111111111111111111    11111111  1111111111111111    11    11  111111111111111111    11    
      11    111111111111111111  1111111111  111111111111    111111      111111111111111111  1111    
      11    111111111111111111  1111111111    1111111111    11111111    1111111111111111    1111    
      1111  111111111111111111  111111111111  1111111111    1111111111  1111111111111111    11      
        11    1111111111111111    1111111111  11111111      1111111111111111111111111111  1111      
        11    11111111111111111111111111111111  111111    1111111111111111111111111111    11        
          11    111111111111111111111111111111  111111    1111111111111111111111111111  1111        
          1111  11111111111111111111111111111111  11      11111111111111111111111111    11          
            11    111111111111111111111111111111        11111111111111111111111111    1111          
            1111    111111111111111111111111111111      11111111111111111111111111    11            
              1111    1111111111111111111111111111    11111111111111111111111111    11              
                1111  1111111111111111111111111111    111111111111111111111111    1111              
                  11      11111111111111111111111111111111111111111111111111    1111                
                    1111    1111111111111111111111111111111111111111111111    11                    
                      1111    1111111111111111111111111111111111111111    1111                      
                        1111      111111111111111111111111111111111111111111                        
                          111111      11111111111111111111111111111111                              
                              111111      111111111111111111111111                                  
                                  111111  1111111111    11                                          
                                                      11                                                                                
 */

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
    public partial class Form1 : Form
    {
        int blahblah0 = 0;
        int blahblah1 = 0;
        string openingfilepath;       
        public Form1()
        {
            InitializeComponent();
            panel1.Enabled = false;
            trackBar1.Value = 150;
            textBox1.Text = Convert.ToString(trackBar1.Value);
            button5.Enabled = false;
        }

        void OpeningImage()
        {
            OpenFileDialog imageOpen = new OpenFileDialog();
            if (imageOpen.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = imageOpen.FileName;
                openingfilepath = imageOpen.SafeFileName + ".txt";
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
                panel1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void BlackWhite()
        {
            try
            {
                trackBar1.Enabled = false;
                textBox1.Enabled = false;
                Bitmap image2 = new Bitmap(pictureBox2.Image);
                progressBar2.Maximum = image2.Height;

                for (int y = 0; y < image2.Height; y++)
                {
                    for (int x = 0; x < image2.Width; x++)
                    {
                        Color p = image2.GetPixel(x, y);
                        int a = p.A;
                        int r = p.R;
                        int g = p.G;
                        int b = p.B;
                        int avg = (r + g + b) / 3;
                        if (avg >= trackBar1.Value)
                        {
                            image2.SetPixel(x, y, Color.White);
                        }
                        else if (avg < trackBar1.Value)
                        {
                            image2.SetPixel(x, y, Color.Black);
                        }
                    }
                    progressBar2.Value = y;
                }
                pictureBox3.Image = image2;
                progressBar2.Value = 0;
                trackBar1.Enabled = true;
                textBox1.Enabled = true;
                blahblah0 = 1;
                if (blahblah1 == 1)
                {
                    button5.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Saving()
        {
            saveFileDialog1.FileName = openingfilepath;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = saveFileDialog1.FileName;
                blahblah1 = 1;
            }            
            if (blahblah0 == 1)
            {
                button5.Enabled = true;
            }
        }

        void Proceeding()
        {
            try
            {
                button5.Enabled = false;
                button3.Enabled = false;
                checkBox1.Enabled = false;
                panel1.Enabled = false;
                panel2.Enabled = false;
                string filepath = textBox2.Text;
                if (!File.Exists(filepath))
                {
                    textBox4.Text = "Creating File.....";
                    File.WriteAllText(filepath, Environment.NewLine);
                    textBox4.Text = "File Created";
                }
                else
                {
                    textBox4.Text = "This file already exists";
                }
                Bitmap image3 = new Bitmap(pictureBox3.Image);
                progressBar3.Maximum = image3.Height;
                progressBar4.Maximum = image3.Width;

                File.AppendAllText(filepath, Environment.NewLine);
                File.AppendAllText(filepath, Environment.NewLine);
                File.AppendAllText(filepath, Environment.NewLine);

                for (int y = 0; y < image3.Height; y++)
                {
                    for (int x = 0; x < image3.Width; x++)
                    {
                        Color p = image3.GetPixel(x, y);
                        if (checkBox1.Checked == false)
                        {
                            if ((p.R == 255) && (p.G == 255) && (p.B == 255))
                            {
                                File.AppendAllText(filepath, "  ");
                            }
                            else if ((p.R == 0) && (p.G == 0) && (p.B == 0))
                            {
                                File.AppendAllText(filepath, "11");
                            }
                        }
                        else if (checkBox1.Checked == true)
                        {
                            if ((p.R == 255) && (p.G == 255) && (p.B == 255))
                            {
                                File.AppendAllText(filepath, "11");
                            }
                            else if ((p.R == 0) && (p.G == 0) && (p.B == 0))
                            {
                                File.AppendAllText(filepath, "  ");
                            }
                        }
                        progressBar4.Value = x;
                    }
                    File.AppendAllText(filepath, Environment.NewLine);
                    progressBar3.Value = y;
                    textBox4.Text = Convert.ToInt32((progressBar3.Value / progressBar3.Maximum) * 100) + "%";
                }
                progressBar4.Value = 0;
                progressBar3.Value = 0;
                textBox4.Text = "Done";
                MessageBox.Show("Done");
                button5.Enabled = true;
                button3.Enabled = true;
                checkBox1.Enabled = true;
                panel1.Enabled = true;
                panel2.Enabled = true;
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
        private void button4_Click(object sender, EventArgs e)
        {
            BlackWhite();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int k = Convert.ToInt32(textBox1.Text);
                    if (k < 0 || k > 255)
                    {
                        MessageBox.Show("Not in Range");
                    }
                    else
                    {
                        trackBar1.Value = k;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(trackBar1.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Saving();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Proceeding();
        }

        
    }
}
