using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using System.IO;

namespace StealthCipher
{
    class AES
    {
        byte[] abc;
        byte[,] table;
        public void EncryptFile(string filePath, string key)
        {
            abc = new byte[256];
            for (int i = 0; i < 256; i++)
                abc[i] = Convert.ToByte(i);
            table = new byte[256, 256];
            for (int i = 0; i < 256; i++)
                for (int j = 0; j < 256; j++)
                {
                    table[i, j] = abc[(i + j) % 256];
                }

            byte[] fileContent = File.ReadAllBytes(filePath);
            byte[] passwordTmp = Encoding.ASCII.GetBytes(key);
            byte[] keys = new byte[fileContent.Length];
            for (int i = 0; i < fileContent.Length; i++)
                keys[i] = passwordTmp[i % passwordTmp.Length];

            //Encrypt
            byte[] result = new byte[fileContent.Length];
            for (int i = 0; i < fileContent.Length; i++)
            {
                byte value = fileContent[i];
                byte ky = keys[i];
                int valueIndex = -1, keyIndex = -1;
                for (int j = 0; j < 256; j++)
                {
                    if (abc[j] == value)
                    {
                        valueIndex = j;
                        break;
                    }
                }
                for (int j = 0; j < 256; j++)
                {
                    if (abc[j] == ky)
                    {
                        keyIndex = j;
                        break;
                    }
                }
                result[i] = table[keyIndex, valueIndex];
            }
            File.WriteAllBytes(filePath, result);

        }
        public void DecryptFile(string filePath, string key)
        {
            abc = new byte[256];
            for (int i = 0; i < 256; i++)
                abc[i] = Convert.ToByte(i);
            table = new byte[256, 256];
            for (int i = 0; i < 256; i++)
                for (int j = 0; j < 256; j++)
                {
                    table[i, j] = abc[(i + j) % 256];
                }

            byte[] fileContent = File.ReadAllBytes(filePath);
            byte[] passwordTmp = Encoding.ASCII.GetBytes(key);
            byte[] keys = new byte[fileContent.Length];
            for (int i = 0; i < fileContent.Length; i++)
                keys[i] = passwordTmp[i % passwordTmp.Length];

            //Decrypt
            byte[] result = new byte[fileContent.Length];
            for (int i = 0; i < fileContent.Length; i++)
            {
                byte value = fileContent[i];
                byte ky = keys[i];
                int valueIndex = -1, keyIndex = -1;
                for (int j = 0; j < 256; j++)
                {
                    if (abc[j] == ky)
                    {
                        keyIndex = j;
                        break;
                    }
                }
                for (int j = 0; j < 256; j++)
                {
                    if (table[keyIndex, j] == value)
                    {
                        valueIndex = j;
                        break;
                    }
                }
                result[i] = abc[valueIndex];
            }
            File.WriteAllBytes(filePath, result);
        }
    }
}
