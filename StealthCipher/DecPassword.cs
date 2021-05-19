using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StealthCipher
{
    public partial class DecPassword : Form
    {
        public DecPassword()
        {
            InitializeComponent();
        }
        public String getPassword()
        {
            if (btn_submit.Enabled == false)
                return textBox1.Text;
            else
                return "null";
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
                btn_submit.Enabled = false;
                Close();
            }
            else
            {
                MessageBox.Show("Password can't be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
