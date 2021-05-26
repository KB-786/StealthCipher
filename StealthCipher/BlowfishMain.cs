using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace StealthCipher
{
    class BlowfishMain
    {
        public void EncryptFile(string filePath, string password)
        {
            byte[] content = File.ReadAllBytes(filePath);
            byte[] key = Encoding.UTF8.GetBytes(password);

            var memStream = new MemoryStream();

            var bf = new Blowfish(key);

            BlowfishStream bfStream = new BlowfishStream(memStream, bf, BlowfishStream.Target.Normal);

            bfStream.Write(content, 0, content.Length);
            bfStream.Flush();
            File.WriteAllBytes(filePath, memStream.ToArray());

            //Console.WriteLine("Encrypted successfully : " + filePath);
        }

        public void DecryptFile(string filePath, string password)
        {
            byte[] content = File.ReadAllBytes(filePath);
            byte[] key = Encoding.UTF8.GetBytes(password);

            var memStream = new MemoryStream();

            var bf = new Blowfish(key);

            BlowfishStream bfStream = new BlowfishStream(memStream, bf, BlowfishStream.Target.Encrypted);

            bfStream.Write(content, 0, content.Length);
            bfStream.Flush();
            File.WriteAllBytes(filePath, memStream.ToArray());

            //Console.WriteLine("Decrypted successfully : " + filePath);
        }
    }
}
