using System.Security.Cryptography;
using System.Text;

namespace Utils
{
    public static class StringExtensions
    {
        public static string Md5(this string input)
        {
<<<<<<< HEAD
            using var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);
            var sb = new StringBuilder();
=======
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);
                var sb = new StringBuilder();

                sb.Append(hashBytes.Select(_ => _.ToString("X2")));
                foreach (var hashByte in hashBytes)
                {
                    sb.Append(hashByte.ToString("X2"));
                }
>>>>>>> f0c2a7537f1f47e30b52364019e11d70eb28d9d9

            foreach (var hashByte in hashBytes)
            {
                sb.Append(hashByte.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
