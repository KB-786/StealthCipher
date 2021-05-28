using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace StealthCipher
{
    class ImgSteganography
    {

        public void hideFile(string coverFilePath, string secretFilePath, string pwd)
        {
            /*byte[] content = File.ReadAllBytes(secretFilePath);
            string strContent = Encoding.Default.GetString(content);*/
            string strContent = File.ReadAllText(secretFilePath);

            Bitmap image = (Bitmap)Image.FromFile(coverFilePath);

            strContent = Crypto.EncryptStringAES(strContent, pwd);

            image = ImgSteganographyHelper.embedText(strContent, image);

            string directory = Path.GetDirectoryName(coverFilePath);
            string filename = Path.GetFileNameWithoutExtension(coverFilePath);
            string fileExt = Path.GetExtension(coverFilePath);
            int i = 1;
            string finalpath = directory + "\\" + filename + i + fileExt;

            while (true)
            {
                if (File.Exists(finalpath))
                {
                    i++;
                    finalpath = directory + "\\" + filename + i + fileExt;
                }
                else
                {
                    break;
                }
            }
            
            image.Save(finalpath, ImageFormat.Bmp);
        }

        public string extractFile(string filePath, string pwd)
        {
            Bitmap image = (Bitmap)Image.FromFile(filePath);

            string content = ImgSteganographyHelper.extractText(image);

            try
            {
                content = Crypto.DecryptStringAES(content, pwd);
            }
            catch
            {
                MessageBox.Show("Wrong password", "Error");
            }

            /*byte[] bContent = Encoding.Default.GetBytes(content);*/

            string directory = Path.GetDirectoryName(filePath);
            int i = 1;
            string finalpath = directory + "\\" + "output" + i + ".txt";
            while (true)
            {
                if (File.Exists(finalpath))
                {
                    i++;
                    finalpath = directory + "\\" + "output" + i + ".txt";
                }
                else
                {
                    break;
                }
            }

            /*File.WriteAllBytes(finalpath, bContent);*/
            File.WriteAllText(finalpath, content);

            return finalpath;
        }

    }
}
