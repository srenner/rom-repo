using SharpCompress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service
{
    public class FileSystemPoller<T> where T : IFileScannable    
    {
        public DateTime? LastScannedUTC { get; private set; }

        public DirectoryInfo Directory { get; private set; }

        public IEnumerable<T> MappedContents { get; set; }

        public FileSystemPoller(string path)
        {
            Directory = new DirectoryInfo(path);
        }

        public async Task ScanAsync(IEnumerable<T> existingStoredItems)
        {
            MappedContents = new List<T>();

            var dirs = Directory.GetDirectories();
            foreach (var dir in dirs)
            {
                Console.WriteLine(dir.FullName);

            }
        }

    }
}
