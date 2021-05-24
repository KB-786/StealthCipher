using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace StealthCipher
{
    public partial class Stegno : Form
    {
        public Stegno()
        {
            InitializeComponent();
        }
        public Stegno(String filePath,String pwd)
        {
            InitializeComponent();
            textBox1.Text = filePath;
        }

        private void btn_addFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "PNG Image|*.png |BIK|*.bik";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = ofd.FileName;

                string imageExt = ".jpeg, .bmp, .png, .gif, .tif, .tiff, .ico, .ai, .psd, .svg";
                string txtExt = ".txt,";
                //string avExt = "";

                string fileExt = System.IO.Path.GetExtension(ofd.FileName);
                if (imageExt.Contains(fileExt))
                {
                    //for image
                    panelPictureBox.Visible = true;
                    panelPictureBox.BringToFront();

                    panelRichTextBox.Visible = false;
                    panelMultimedia.Visible = false;

                    // display image in picture box  
                    pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
                    // or larger, but distorted
                    pictureBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxImage.Image = new Bitmap(ofd.FileName);

                }
                else if (txtExt.Contains(fileExt))
                {
                    //for text files
                    panelRichTextBox.Visible = true;
                    panelRichTextBox.BringToFront();

                    panelMultimedia.Visible = false;
                    panelPictureBox.Visible = false;


                    Stream myStream;
                    if ((myStream = ofd.OpenFile()) != null)
                    {
                        string strfilename = ofd.FileName;
                        string filetxt = File.ReadAllText(strfilename);
                        richTextBox1.Text = filetxt;
                    }

                }
                else
                {
                    //for audio, video and other multimedia
                    panelMultimedia.Visible = true;
                    panelMultimedia.BringToFront();

                    panelRichTextBox.Visible = false;
                    panelPictureBox.Visible = false;


                }


            }
            
        }

        private void Stegno_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            if (progressBar1.Value < 100)
            {
                label2.Text = "Encrypting File...";

            }
            else
            {
                label2.Text = "File is successfully encrypted !!";
                groupBox1.Enabled = true;
            }
        }

        private void btn_finish_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length!=0 && textBox2.Text.Length!=0)
            {

            }
            else
            {
                MessageBox.Show("Please select a cover file to proceed. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
