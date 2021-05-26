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
                if (form.okClicked())
                {
                    try
                    {
                        string pwd = form.getPassword();


                        /*BlowfishMain bf = new BlowfishMain();
                        bf.DecryptFile(textBox1.Text, pwd);*/

                        RC4 rc4 = new RC4();
                        rc4.DecryptFile(textBox1.Text, pwd);

                        /*TripleDES tDES = new TripleDES(pwd);
                        tDES.DecryptFile(textBox1.Text);
                       

                        String desPwd = pwd.Substring(0, 8);
                        DES des = new DES();
                        des.DecryptFile(textBox1.Text, desPwd);

                        
                        AES aes = new AES();
                        aes.DecryptFile(textBox1.Text, pwd);*/

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
