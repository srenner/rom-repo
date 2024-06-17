using RomRepo.service;
using SharpCompress.Archives;
using SharpCompress.Common;
using SharpCompress.Readers;
using SharpCompress.IO;
using SharpCompress.Compressors.Deflate;
using System.IO;
using System.Net;

namespace RomRepo.console.Models
{
    /// <summary>
    /// Represents a single game (a single file, a folder, or a 7z/zip)
    /// </summary>
    public class Rom : IFileScannable
    {
        private const string _cacheRoot = "/app-cache";

        public int RomID { get; set; }

        public int? CoreID { get; set; }
        public Core? Core { get; set; }

        public required string Path { get; set; }

        public bool IsFavorite { get; set; } = false;
        public int? StarRating { get; set; }
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Patched rom, i.e. fan translation, rom hack, etc. Can use ParentRomID to specify original game.
        /// </summary>
        public bool IsPatch { get; set; } = false;


        public int? ParentRomID { get; set; }
        public Rom? ParentRom { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns>Temporary paths of extracted files</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<string> Extract()
        {
            var ret = new List<string>();
            string cachePath = _cacheRoot + "/" + CoreID.ToString() + "/" + RomID.ToString();
            if(!Directory.Exists(cachePath))
            {
                Directory.CreateDirectory(cachePath);
            }
            
            if(Path.EndsWith(".zip"))
            {
                var archive = SharpCompress.Archives.Zip.ZipArchive.Open(Path);
                foreach(var entry in archive.Entries)
                {
                    entry.WriteToDirectory(cachePath);
                    ret.Add(cachePath + "/" + entry.Key);
                }
            }
            else if(Path.EndsWith(".7z"))
            {
                throw new NotImplementedException(".7z not supported yet");
            }
            return ret;
        }

        public bool Compress()
        {
            return false;
        }

        public string GetPath()
        {
            return this.Path;
        }

        public DateTime GetLastUpdated()
        {
            return this.DateUpdated;
        }
    }
}
