using System.IO.Hashing;
using System.Security.Cryptography;
using System.Text;

namespace RomRepo.service.Services
{
    public class ChecksumService
    {
        public static string CalculateCRC(string filePath)
        {
            byte[] data = File.ReadAllBytes(filePath);
            var hash = Crc32.Hash(data);
            if(BitConverter.IsLittleEndian)
            {
                hash = hash.Reverse().ToArray();
            }
            return Convert.ToHexString(hash).ToLower();
        }
        
        public static string CalculateHashString<T>(T algo, string filePath) where T : HashAlgorithm
        {
            byte[] data = File.ReadAllBytes(filePath);
            var hash = algo.ComputeHash(data);
            StringBuilder sb = new();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        #region Obsolete

        [Obsolete("Use CalculateHashString<MD5>")]
        public static string CalculateMD5(string filePath)
        {
            byte[] data = File.ReadAllBytes(filePath);
            var hash = MD5.HashData(data);
            StringBuilder sb = new(32);
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        [Obsolete("Use CalculateHashString<SHA1>")]
        public static string CalculateSHA1(string filePath)
        {
            byte[] data = File.ReadAllBytes(filePath);
            var hash = SHA1.HashData(data);
            StringBuilder sb = new();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
        
        [Obsolete("Use CalculateHashString<SHA256>")]
        public static string CalculateSHA256(string filePath)
        {
            byte[] data = File.ReadAllBytes(filePath);
            var hash = SHA256.HashData(data);
            StringBuilder sb = new();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        #endregion

    }
}
