using System;
using System.Security.Cryptography;
using System.Text;

namespace ProjectIntercept.Security
{
    internal class Encryption
    {
        private const String DefaultPassword = "qpeoqapsocmjacijfqp";

        public static String Encrypt(String original)
        {
            return Encrypt(original, DefaultPassword);
        }

        public static String Encrypt(String original, String password)
        {
            var md5Hash = new MD5CryptoServiceProvider();
            var passwordHash = md5Hash.ComputeHash(Encoding.ASCII.GetBytes(password));
            var cryptoProvider = new TripleDESCryptoServiceProvider {Key = passwordHash, Mode = CipherMode.ECB};
            // A given bit of text is always encrypted the same way
            // when the same password is used.
            var buffer = Encoding.ASCII.GetBytes(original);
            var encrypted = Convert.ToBase64String(
                cryptoProvider.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length)
                );
            return encrypted;
        }

        public static String Decrypt(String encryptedString)
        {
            return Decrypt(encryptedString, DefaultPassword);
        }

        public static String Decrypt(String encryptedString, String password)
        {
            var md5Hash = new MD5CryptoServiceProvider();
            var passwordHash = md5Hash.ComputeHash(Encoding.ASCII.GetBytes(password));
            var cryptoProvider = new TripleDESCryptoServiceProvider();
            if (passwordHash != null) cryptoProvider.Key = passwordHash;
            // A given bit of text is always encrypted the same way
            // when the same password is used.
            cryptoProvider.Mode = CipherMode.ECB;
            var buffer = Convert.FromBase64String(encryptedString);
            var decrypted = Encoding.ASCII.GetString(
                cryptoProvider.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length)
                );
            return decrypted;
        }

        public static string Md5(string password)
        {
            if (password == null) throw new ArgumentNullException("password");

            var x = new MD5CryptoServiceProvider();
            var data = Encoding.ASCII.GetBytes(password);
            data = x.ComputeHash(data);
            var ret = "";
            for (var i = 0; i < data.Length; i++)
                ret += data[i].ToString("x2").ToLower();
            return ret;
        }

        public static string EncodeTo64(string toEncode)
        {
            var toEncodeAsBytes
                = Encoding.ASCII.GetBytes(toEncode);

            var returnValue
                = Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;
        }
    }
}