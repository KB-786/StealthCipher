using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StealthCipher
{
    public partial class decrypt : Form
    {
        public decrypt()
        {
            InitializeComponent();
        }

        private void btn_finish_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                DecPassword form = new DecPassword();
                form.ShowDialog();

                string sequence = "AES,DES,3des,Blowfish,RC4";

                if (form.okClicked())
                {
                    string pwd = form.getPassword();
                    //RC4
                    if (sequence.Contains("RC4"))
                    {
                        try
                        {
                            RC4 rc4 = new RC4();
                            rc4.DecryptFile(textBox1.Text, pwd);
                            GC.Collect();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("RC4: " + ex.Message);
                            btn_finish.Enabled = true;
                        }
                    }

                    //Blowfish
                    if (sequence.Contains("Blowfish"))
                    {
                        try
                        {
                            BlowfishMain bf = new BlowfishMain();
                            bf.DecryptFile(textBox1.Text, pwd);
                            GC.Collect();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Blowfish: " + ex.Message);
                            btn_finish.Enabled = true;
                        }
                    }
                    
                    //TripleDES
                    if (sequence.Contains("3des"))
                    {
                        try
                        {
                            TripleDES tDES = new TripleDES(pwd);
                            tDES.DecryptFile(textBox1.Text);
                            GC.Collect();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("TripleDES: " + ex.Message);
                            btn_finish.Enabled = true;
                        }
                    }

                    //DES
                    if (sequence.Contains("DES"))
                    {
                        try
                        {
                            String desPwd = pwd.Substring(0, 8);
                            DES des = new DES();
                            des.DecryptFile(textBox1.Text, desPwd);
                            GC.Collect();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("DES: " + ex.Message);
                            btn_finish.Enabled = true;
                        }
                    }
                    
                    //AES
                    if (sequence.Contains("AES"))
                    {
                        try
                        {
                            AES aes = new AES();
                            aes.DecryptFile(textBox1.Text, pwd);
                            GC.Collect();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("AES: " + ex.Message);
                            btn_finish.Enabled = true;
                        }
                    }
                    
                    btn_finish.Enabled = false;
                    Message.Visible = true;
                    Message.Text = "File decrypted !";
                }
            }
            else
            {
                MessageBox.Show("Please select a file to proceed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_addFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }
    }
}
