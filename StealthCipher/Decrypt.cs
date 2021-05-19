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
                        /*String pwd = form.getPassword();
                        TripleDES tDES = new TripleDES(pwd);
                        tDES.DecryptFile(textBox1.Text);
                        GC.Collect();
                        btn_finish.Enabled = false;*/

                        /*string pwd = form.getPassword();
                        DES des = new DES();
                        des.DecryptFile(textBox1.Text, pwd);
                        GC.Collect();
                        btn_finish.Enabled = false;*/
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
