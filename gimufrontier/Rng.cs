using System.Security.Cryptography;
using System.Text;

namespace gimufrontier
{
    public static class Rng
    {
        private static readonly string RANDOM_NOSPECIAL = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly string RANDOM_SPECIAL = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789+-*!£$%&/()=?^#@<>";

        public static string NoSpecial(int maxlen)
        {
            var rng = new Random();
            var o = Enumerable.Repeat((byte)RANDOM_NOSPECIAL[rng.Next(RANDOM_NOSPECIAL.Length)], maxlen);
            return Encoding.UTF8.GetString(o.ToArray());
        }

        public static string Special(int maxlen)
        {
            var rng = new Random();
            var o = Enumerable.Repeat((byte)RANDOM_SPECIAL[rng.Next(RANDOM_SPECIAL.Length)], maxlen);
            return Encoding.UTF8.GetString(o.ToArray());
        }

        public static string NewToken(int tokenLen)
        {
            var rng = RandomNumberGenerator.Create();

            var token = new byte[tokenLen];
            rng.GetBytes(token);
            return Convert.ToBase64String(token);
        }
    }
}
