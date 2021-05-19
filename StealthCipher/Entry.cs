using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StealthCipher
{
    public partial class entry : Form
    {
        public entry()
        {
            InitializeComponent();
        }

        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            encrypt enc = new encrypt();
            enc.ShowDialog();
        }

        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            decrypt dec = new decrypt();
            dec.ShowDialog();
        }

        private void linkLabel1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Firstly, Tell us something about you :)", linkLabel1);
        }
    }
}
