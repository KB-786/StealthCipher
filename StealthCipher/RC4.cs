using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace StealthCipher
{
    class RC4
    {
        public void EncryptFile(string filePath, string password)
        {

            byte[] content = File.ReadAllBytes(filePath);

            var sBox = createSbox(password);

            var encryptBytes = PseudoRandomRc4(sBox, content);
            File.WriteAllBytes(filePath, encryptBytes);

            //Console.WriteLine("Encryption Completed.");
        }

        public void DecryptFile(string filePath, string password)
        {

            byte[] content = File.ReadAllBytes(filePath);

            var sBox = createSbox(password);

            var decryptedString = PseudoRandomRc4(sBox, content);
            File.WriteAllBytes(filePath, decryptedString);

            //Console.WriteLine("Decryption Completed.");
        }

        private byte[] PseudoRandomRc4(int[] sBox, byte[] messageBytes)
        {
            var i = 0;
            var j = 0;
            var cnt = 0;
            var tempBox = new int[sBox.Length];
            var result = new byte[messageBytes.Length];

            Array.Copy(sBox, tempBox, tempBox.Length);

            foreach (var textByte in messageBytes)
            {
                i = (i + 1) % 256;
                j = (j + tempBox[i]) % 256;
                var temp = tempBox[i];
                tempBox[i] = tempBox[j];
                tempBox[j] = temp;
                var t = (tempBox[i] + tempBox[j]) % 256;
                var k = tempBox[t];

                var ss = textByte ^ k;
                result[cnt] = (byte)ss;
                cnt++;
            }
            return result;
        }

        private int[] createSbox(string password)
        {
            var asciiKeyBytes = Encoding.ASCII.GetBytes(password);
            var sBox = Enumerable.Range(0, 256).ToArray();

            var j = 0;
            for (var i = 0; i < 256; i++)
            {
                j = (j + sBox[i] + asciiKeyBytes[i % asciiKeyBytes.Length]) % 256;
                sBox[j] = sBox[i];
                sBox[i] = j;
            }

            return sBox;
        }
    }
}
