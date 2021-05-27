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

        public string[] removeAuthData(string filePath)
        {
            byte[] b = File.ReadAllBytes(filePath);
            string content = Encoding.Default.GetString(b);
            int n = content.Length;

            int fDataLen = Convert.ToInt32(content.Substring(n - 2, 2));


            string fData = content.Substring(n - fDataLen, fDataLen);


            string pwdHash = fData.Substring(fDataLen - 34, 32);


            string seq = fData.Substring(0, fDataLen - 34);


            string[] seqHash = new string[2];
            seqHash[0] = pwdHash;
            seqHash[1] = seq;

            byte[] fData1 = Encoding.Default.GetBytes(fData);
            int fDataLen1 = fData1.Length;

            int N = b.Length;

            byte[] eContent = new byte[N - fDataLen1];
            Array.Copy(b, 0, eContent, 0, eContent.Length);

            File.WriteAllBytes(filePath, eContent);


            return seqHash;
        }

    }
}
