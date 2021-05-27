using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace StealthCipher
{
    public partial class encrypt : Form
    {
        public encrypt()
        {
            InitializeComponent();
        }

        private void btn_addFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }
        private void btn_finish_Click(object sender, EventArgs e)
        {
            string sequence = "";
			if (textBox1.Text.Length != 0)
			{
                if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true || checkBox5.Checked == true)
                {
                    EncPassword form = new EncPassword();
                    form.ShowDialog();
                    
                    if (form.okClicked())
                    {
                        string pwd = form.getPassword();
                        if (checkBox1.Checked == true)  //AES
                        {
                            try
                            {
                                AES des = new AES();
                                des.EncryptFile(textBox1.Text, pwd);
                                GC.Collect();
                                btn_finish.Enabled = false;
                                sequence += " AES,";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("AES:" + ex.Message);
                                btn_finish.Enabled = true;
                            }
                        }
                        if (checkBox2.Checked == true)  //DES
                        {
                            try
                            {
                                String desPwd = pwd.Substring(0, 8);
                                DES des = new DES();
                                des.EncryptFile(textBox1.Text, desPwd);
                                GC.Collect();
                                btn_finish.Enabled = false;
                                sequence += " DES,";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("DES:" + ex.Message);
                                btn_finish.Enabled = true;
                            }
                        }
                        if (checkBox3.Checked == true)  //Triple DES
                        {
                            try
                            {
                                TripleDES tDES = new TripleDES(pwd);
                                tDES.EncryptFile(textBox1.Text);
                                GC.Collect();
                                btn_finish.Enabled = false;
                                sequence += " 3DES,";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("TripleDES:" + ex.Message);
                                btn_finish.Enabled = true;
                            }
                        }
                        if (checkBox4.Checked == true)  //Blowfish
                        {
                            try
                            {
                                BlowfishMain bf = new BlowfishMain();
                                bf.EncryptFile(textBox1.Text, pwd);
                                GC.Collect();
                                btn_finish.Enabled = false;
                                sequence += " Blowfish,";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Blowfish:" + ex.Message);
                                btn_finish.Enabled = true;
                            }
                        }
                        if (checkBox5.Checked == true)  //RC4
                        {
                            try
                            {
                                RC4 rc4 = new RC4();
                                rc4.EncryptFile(textBox1.Text, pwd);
                                GC.Collect();
                                btn_finish.Enabled = false;
                                sequence += " RC4";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("RC4:" + ex.Message);
                                btn_finish.Enabled = true;
                            }
                        }
                        Close();
                        string hash;
                        using (System.Security.Cryptography.MD5 md5hash = System.Security.Cryptography.MD5.Create())
                        {
                            hash = GetMd5Hash(md5hash, pwd);
                        }
                        Stegno steg = new Stegno(textBox1.Text, hash, sequence);
                        steg.ShowDialog();
                    }
                }
				else
				{
					MessageBox.Show("Please choose at least one encryption algorithm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Please add a file to proceed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
        private string GetMd5Hash(System.Security.Cryptography.MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for(int i=0;i<data.Length;i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label1.Visible = true;
            }
            if (checkBox1.Checked == false)
            {
                label1.Visible = false;
            }
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                label2.Visible = true;
            }
            if (checkBox2.Checked == false)
            {
                label2.Visible = false;
            }
        }

        private void checkBox3_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                label3.Visible = true;
            }
            if (checkBox3.Checked == false)
            {
                label3.Visible = false;
            }
        }

        private void checkBox4_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                label4.Visible = true;
            }
            if (checkBox4.Checked == false)
            {
                label4.Visible = false;
            }
        }

        private void checkBox5_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                label5.Visible = true;
            }
            if (checkBox5.Checked == false)
            {
                label5.Visible = false;
            }
        }
    }
}
