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
        bool steg;
        public decrypt()
        {
            InitializeComponent();
        }

        private void btn_finish_Click(object sender, EventArgs e)
        {
            string encFilepath;
            if (textBox1.Text.Length != 0)
            {
                DecPassword form = new DecPassword();
                form.ShowDialog();

                if (form.okClicked())
                {
                    string pwd = form.getPassword();
                    if (steg == true)
                    {
                        ImgSteganography imgSteg = new ImgSteganography();
                        encFilepath = imgSteg.extractFile(textBox1.Text, pwd);
                    }
                    else
                    {
                        encFilepath = textBox1.Text;
                    }
                    string hash;
                    using (System.Security.Cryptography.MD5 md5hash = System.Security.Cryptography.MD5.Create())
                    {
                        hash = GetMd5Hash(md5hash, pwd);
                    }
                    AuthData fd = new AuthData();
                    string pwdHash = fd.getHash(encFilepath);

                    if (pwdHash.Equals(hash))
                    {
                        fd.SetFinal(encFilepath);
                        try
                        {
                            AES aes = new AES();
                            aes.DecryptFile(encFilepath, pwd);
                            GC.Collect();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("AES: " + ex.Message);
                        }

                        string sequence = fd.removeAuthData(encFilepath);

                        //RC4
                        if (sequence.Contains("RC4"))
                        {
                            try
                            {
                                RC4 rc4 = new RC4();
                                rc4.DecryptFile(encFilepath, pwd);
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
                                bf.DecryptFile(encFilepath, pwd);
                                GC.Collect();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Blowfish: " + ex.Message);
                                btn_finish.Enabled = true;
                            }
                        }

                        //TripleDES
                        if (sequence.Contains("3DES"))
                        {
                            try
                            {
                                TripleDES tDES = new TripleDES(pwd);
                                tDES.DecryptFile(encFilepath);
                                GC.Collect();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("TripleDES: " + ex.Message);
                                btn_finish.Enabled = true;
                            }
                        }

                        //DES
                        if (sequence.Contains(" DES"))
                        {
                            try
                            {
                                String desPwd = pwd.Substring(0, 8);
                                DES des = new DES();
                                des.DecryptFile(encFilepath, desPwd);
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
                                aes.DecryptFile(encFilepath, pwd);
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
                        MessageBox.Show("File decrypted successfully !", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a file to proceed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GetMd5Hash(System.Security.Cryptography.MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        private void btn_addFile_Click(object sender, EventArgs e)
        {
            if(radiobtn_yes.Checked == false && radiobtn_no.Checked == false)
            {
                MessageBox.Show("Please answer the above question !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBox1.Text = ofd.FileName;
                }
            }
        }

        private void radiobtn_yes_CheckedChanged(object sender, EventArgs e)
        {
            steg = true;
        }

        private void radiobtn_no_CheckedChanged(object sender, EventArgs e)
        {
            steg = false;
        }
    }
}
