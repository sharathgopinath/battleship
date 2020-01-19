using Application.Common.Interfaces;
using System;
using System.Text;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.IO;

namespace Infrastructure.Services
{
    public class EncryptionService : IEncryptionService
    {
        private const string KEY = "ay$a5%&jwrtmnh;lasjdf25253";
        private const string IV = "abc@98797hjkas$&asd(*$%";

        public T Decrypt<T>(string encryptedCode)
        {
            string jsonString = "";
            byte[] _ivByte = { };
            _ivByte = Encoding.UTF8.GetBytes(IV.Substring(0, 8));
            byte[] _keybyte = { };
            _keybyte = Encoding.UTF8.GetBytes(KEY.Substring(0, 8));
            MemoryStream ms = null; CryptoStream cs = null;
            byte[] inputbyteArray = new byte[encryptedCode.Replace(" ", "+").Length];
            inputbyteArray = Convert.FromBase64String(encryptedCode.Replace(" ", "+"));
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                ms = new MemoryStream();
                cs = new CryptoStream(ms, des.CreateDecryptor(_keybyte, _ivByte), CryptoStreamMode.Write);
                cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8;
                jsonString = encoding.GetString(ms.ToArray());
            }

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public string Encrypt<T>(T input)
        {
            var jsonString = JsonConvert.SerializeObject(input);

            try
            {
                string ToReturn = "";
                byte[] _ivByte = { };
                _ivByte = System.Text.Encoding.UTF8.GetBytes(IV.Substring(0, 8));
                byte[] _keybyte = { };
                _keybyte = System.Text.Encoding.UTF8.GetBytes(KEY.Substring(0, 8));
                MemoryStream ms = null; CryptoStream cs = null;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(jsonString);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(_keybyte, _ivByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }
    }
}
