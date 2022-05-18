using System.Security.Cryptography;

namespace gimufrontier
{
    /// <summary>
    /// Simple class that handles game cryptation/decryptation
    /// </summary>
    public static class Cryptation
    {
        /// <summary>
        /// Simple AES+Base64
        /// </summary>
        /// <param name="src">raw data to encrypt</param>
        /// <param name="key">AES Key</param>
        /// <param name="iv">AES IV (optional)</param>
        /// <param name="ebc">true if you use EBC mode</param>
        /// <returns>Base64 encrypted data</returns>
        /// <exception cref="Exception">In case cryptation fails</exception>
        private static string RoundAESEnc(byte[] src, byte[] key, byte[]? iv, bool ebc)
        {
            using (var a = Aes.Create())
            {
                // fix for keys < 16
                byte[] realKey = new byte[16];
                Array.Clear(realKey, 0, 16);
                Array.Copy(key, realKey, key.Length);

                a.Key = realKey;

                if (!ebc)
                {
                    if (iv == null)
                        throw new Exception("IV can't be null in CBC mode");

                    a.IV = iv;
                    a.Mode = CipherMode.CBC;
                    a.Padding = PaddingMode.Zeros;
                }
                else
                {
                    a.Mode = CipherMode.ECB;
                    a.Padding = PaddingMode.PKCS7;
                }

                using var t = a.CreateEncryptor();
                return Convert.ToBase64String(t.TransformFinalBlock(src, 0, src.Length));

            }

            throw new Exception("Encryptation round fail!");
        }

        /// <summary>
        /// Simple AES+Base64 decryptation
        /// </summary>
        /// <param name="src">Base64 data to decrypt</param>
        /// <param name="key">AES key</param>
        /// <param name="iv">AES IV (optional)</param>
        /// <param name="g2"></param>
        /// <returns>raw decrypted data</returns>
        /// <exception cref="Exception">In case decryptation fails</exception>
        private static byte[] RoundAESDec(string src, byte[] key, byte[]? iv, bool ebc)
        {
            using (var a = Aes.Create())
            {
                byte[] realKey = new byte[16];
                Array.Clear(realKey, 0, 16);
                Array.Copy(key, realKey, key.Length);

                a.Key = realKey;

                if (ebc)
                {
                    a.Mode = CipherMode.ECB;
                    a.Padding = PaddingMode.PKCS7;
                }
                else
                {
                    if (iv == null)
                        throw new Exception("IV can't be null in CBC mode");

                    a.IV = iv;
                    a.Mode = CipherMode.CBC;
                    a.Padding = PaddingMode.Zeros;
                }

                using var t = a.CreateDecryptor();
                var ub64 = Convert.FromBase64String(src);
                return t.TransformFinalBlock(ub64, 0, ub64.Length);

            }

            throw new Exception("Decryptation round fail!");
        }

        /// <summary>
        /// Live API AES Key (7410958164354871)
        /// </summary>
        private static readonly byte[] SREE_KEY = new byte[] { 0x37, 0x34, 0x31, 0x30, 0x39, 0x35, 0x38, 0x31, 0x36, 0x34, 0x33, 0x35, 0x34, 0x38, 0x37, 0x31 };

        /// <summary>
        /// Live API AES IV (Bfw4encrypedPass)
        /// </summary>
        private static readonly byte[] BF_IV = new byte[] { 0x42, 0x66, 0x77, 0x34, 0x65, 0x6E, 0x63, 0x72, 0x79, 0x70, 0x65, 0x64, 0x50, 0x61, 0x73, 0x73 };
        
        /// <summary>
        /// Perform Live API DLS cryptation
        /// </summary>
        /// <param name="data">data to encrypt</param>
        /// <returns>Encrypted base64 data</returns>
        public static string SREE(byte[] data)
        {
            return RoundAESEnc(data, SREE_KEY, BF_IV, false);
        }

        /// <summary>
        /// Perform action.php decryptation
        /// </summary>
        /// <param name="data">base64 data to decrypt</param>
        /// <param name="key">AES Key</param>
        /// <returns>raw decrypted data</returns>
        public static byte[] Game2Server(string data, byte[] key)
        {
            return RoundAESDec(data, key, null, true);
        }

        /// <summary>
        /// Perform action.php encryptation
        /// </summary>
        /// <param name="data">raw data to encrypt</param>
        /// <param name="key">AES Key</param>
        /// <returns>base64 encrypted data</returns>
        public static string Server2Game(byte[] data, byte[] key)
        {
            return RoundAESEnc(data, key, null, true);
        }
    }
}
