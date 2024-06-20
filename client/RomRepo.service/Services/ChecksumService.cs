using System.IO.Hashing;
using System.Security.Cryptography;
using System.Text;

namespace RomRepo.service.Services
{
    public static class ChecksumService
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
        public static string CalculateSHA1(string filePath) { throw new NotImplementedException(); }
        public static string CalculateSHA256(string filePath) { throw new NotImplementedException(); }


    }
}
