using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Utils
{
    public static class StringExtensions
    {
        public static string Md5(this string input)
        {
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

                return sb.ToString();
            }
        }
    }
}