using System.IO.Hashing;

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
        public static string CalculateMD5(string filePath) { throw new NotImplementedException(); }
        public static string CalculateSHA1(string filePath) { throw new NotImplementedException(); }
        public static string CalculateSHA256(string filePath) { throw new NotImplementedException(); }


    }
}
