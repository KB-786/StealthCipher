using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
			if (textBox1.Text.Length != 0)
			{
                if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true || checkBox5.Checked == true)
                {
                    EncPassword form = new EncPassword();
                    form.ShowDialog();
                    if (checkBox1.Checked == true)  //AES
                    {
                        if (form.okClicked())
                        {
                            try
                            {
                                String pwd = form.getPassword();
                                AES des = new AES();
                                des.EncryptFile(textBox1.Text, pwd);
                                GC.Collect();
                                btn_finish.Enabled = false;
                                Close();
                                Stegno steg = new Stegno(textBox1.Text,pwd);
                                steg.ShowDialog();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                btn_finish.Enabled = true;
                            }
                        }
                    }
                    if (checkBox2.Checked == true)  //DES
                    {
                        if (form.okClicked())
                        {
                            try
                            {
                                String pwd = form.getPassword();
                                String desPwd = pwd.Substring(0, 8);
                                DES des = new DES();
                                des.EncryptFile(textBox1.Text, desPwd);
                                GC.Collect();
                                btn_finish.Enabled = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                btn_finish.Enabled = true;
                            }
                        }
                    }
                    if (checkBox3.Checked == true)  //Triple DES
                    {
                        if (form.okClicked())
                        {
                            try
                            {
                                String pwd = form.getPassword();
                                TripleDES tDES = new TripleDES(pwd);
                                tDES.EncryptFile(textBox1.Text);
                                GC.Collect();
                                btn_finish.Enabled = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                btn_finish.Enabled = true;
                            }
                        }
                    }
                    if (checkBox4.Checked == true)  //4
                    {

                    }
                    if (checkBox5.Checked == true)  //5
                    {

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
