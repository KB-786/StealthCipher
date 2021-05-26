using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StealthCipher
{
    public partial class EncPassword : Form
    {
        public EncPassword()
        {
            InitializeComponent();
        }

        private void EncPassword_Load(object sender, EventArgs e)
        {
            
        }
        public string getPassword()
        {
            if (btn_submit.Enabled == false)
            {
                //return textBox1.Text;
                string pwd = padPassword(textBox1.Text);
                return pwd;
            }
            else
                return "null";
        }
        private string padPassword(string pwd)
        {
            if(pwd.Length == 16)
            {
                return pwd;
            }
            byte[] newPwd = new byte[16];
            byte[] oldPwd = Encoding.Default.GetBytes(pwd);
            int padding = 16 - pwd.Length;
            char[] arr = {'@', '%', '#', '&', '.', '*', ']','-'};

            int c = 0;
            for(int i = 1; i < padding * 2; i += 2)
            {
                newPwd[i] = Convert.ToByte(arr[c]);
                c++;
            }
            c = 0;
            for(int i = 0; i < padding * 2; i += 2)
            {
                newPwd[i] = oldPwd[c];
                c++;
            }
            if(padding * 2 != 16)
            {
                for(int i = padding * 2; i < 16; i++)
                {
                    newPwd[i] = oldPwd[c];
                    c++;
                }
            }

            string padPwd = Encoding.Default.GetString(newPwd);
            return padPwd;
        }
        public bool okClicked()
        {
            if (btn_submit.Enabled == false)
                return true;
            else
                return false;
        }
        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                if(textBox1.Text.Length>=8)
                {
                    btn_submit.Enabled = false;
                    Close();
                }
                else
                {
                    MessageBox.Show("Password length should be minimum of 8 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Password can't be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
