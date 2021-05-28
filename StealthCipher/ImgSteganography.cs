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

        public void hideFile(string coverFilePath, string secretFilePath)
        {
            byte[] content = File.ReadAllBytes(secretFilePath);

            string strContent = Encoding.Default.GetString(content);

            Bitmap image = (Bitmap)Image.FromFile(coverFilePath);

            image = ImgSteganographyHelper.embedText(strContent, image);

            String fileExt = Path.GetExtension(coverFilePath);
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Files (*" + fileExt + ") | *" + fileExt;
            if (sd.ShowDialog() == DialogResult.OK)
            {
                image.Save(coverFilePath);
            }

            //image.Save(savePath);
        }

        public void extractFile(string filePath)
        {
            Bitmap image = (Bitmap)Image.FromFile(filePath);

            string content = ImgSteganographyHelper.extractText(image);

            byte[] bContent = Encoding.Default.GetBytes(content);

            String fileExt = ".txt";
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Files (*" + fileExt + ") | *" + fileExt;
            if (sd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(filePath, bContent);
            }

            //File.WriteAllBytes(savePath, bContent);
        }

    }
}
