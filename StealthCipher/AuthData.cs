using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace StealthCipher
{
    class AuthData
    {

        public void addAuthData(string filePath, string data)
        {
            byte[] content = File.ReadAllBytes(filePath);
            int lenContent = content.Length;

            byte[] bData = Encoding.Default.GetBytes(data);
            int lenData = bData.Length;

            byte[] fContent = new byte[lenContent + lenData];

            Array.Copy(content, 0, fContent, 0, lenContent);
            Array.Copy(bData, 0, fContent, lenContent, lenData);

            File.WriteAllBytes(filePath, fContent);
        }

        public string removeAuthData(string filePath)
        {
            byte[] b = File.ReadAllBytes(filePath);
            string content = Encoding.Default.GetString(b);
            int n = content.Length;

            int seqLen = Convert.ToInt32(content.Substring(n - 2, 2));

            string seq = content.Substring(n - seqLen - 2, seqLen + 2);

            byte[] fData = Encoding.Default.GetBytes(seq);
            int fDataLen = fData.Length;

            int N = b.Length;

            byte[] eContent = new byte[N - fDataLen];
            Array.Copy(b, 0, eContent, 0, eContent.Length);

            File.WriteAllBytes(filePath, eContent);

            return seq;
        }
        public void setHash(string filePath, string hash)
        {
            byte[] content = File.ReadAllBytes(filePath);
            int lenContent = content.Length;

            byte[] bData = Encoding.Default.GetBytes(hash);
            int lenData = bData.Length;

            byte[] fContent = new byte[lenContent + lenData];

            Array.Copy(content, 0, fContent, 0, lenContent);
            Array.Copy(bData, 0, fContent, lenContent, lenData);

            File.WriteAllBytes(filePath, fContent);
        }
        public string getHash(string filePath)
        {
            byte[] b = File.ReadAllBytes(filePath);
            string content = Encoding.Default.GetString(b);
            int n = content.Length;
            string hash = content.Substring(n - 32, 32);
            return hash;
        }
        public void SetFinal(string filePath)
        {
            byte[] b = File.ReadAllBytes(filePath);
            string content = Encoding.Default.GetString(b);
            int n = content.Length;

            string hash = content.Substring(n - 32, 32);
            byte[] pwdHash = Encoding.Default.GetBytes(hash);
            int hashLen = pwdHash.Length;

            int N = b.Length;
            byte[] eContent = new byte[N - hashLen];
            Array.Copy(b, 0, eContent, 0, eContent.Length);

            File.WriteAllBytes(filePath, eContent);
        }

    }
}
