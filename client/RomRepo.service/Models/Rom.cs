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
        private const string _tempRoot = "/app-cache/tmp";

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

        public string? CRC { get; set; }
        public bool? CRCVerified { get; set; }

        public string? MD5 { get; set; }
        public bool? MD5Verified { get; set; }

        public string? SHA1 { get; set; }
        public bool? SHA1Verified { get; set; }

        public string? SHA256 { get; set; }
        public bool? SHA256Verified { get; set; }

        /// <summary>
        /// Unzips a rom to filesystem
        /// </summary>
        /// <param name="isTemporary">If true, extracted files are subject to deletion policy</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<string> Extract(bool isTemporary)
        {
            var ret = new List<string>();

            string pathRoot = isTemporary ? _tempRoot : _cacheRoot;
            string cachePath = pathRoot + "/" + CoreID.ToString() + "/" + RomID.ToString();
            
            if(!Directory.Exists(cachePath))
            {
                Directory.CreateDirectory(cachePath);
            }
            
            if(Path.EndsWith(".zip"))
            {
                if(SharpCompress.Archives.Zip.ZipArchive.IsZipFile(Path))
                {
                    var archive = SharpCompress.Archives.Zip.ZipArchive.Open(Path);
                    foreach (var entry in archive.Entries)
                    {
                        entry.WriteToDirectory(cachePath);
                        ret.Add(cachePath + "/" + entry.Key);
                    }
                }
                else
                {
                    throw new IOException("Not a valid zip file: " + Path);
                }
            }
            else if(Path.EndsWith(".7z"))
            {
                if(SharpCompress.Archives.SevenZip.SevenZipArchive.IsSevenZipFile(Path))
                {
                    var archive = SharpCompress.Archives.SevenZip.SevenZipArchive.Open(Path);
                    foreach (var entry in archive.Entries)
                    {
                        entry.WriteToDirectory(cachePath);
                        ret.Add(cachePath + "/" + entry.Key);
                    }
                }
                else
                {
                    throw new IOException("Not a valid 7z file: " + Path);
                }
            }
            else
            {
                throw new IOException("File type not supported: " + Path);
            }
            return ret;
        }

        public bool IsArchive()
        {
            var path = Path.ToLower();
            if (path.EndsWith(".zip") || path.EndsWith(".7z"))
            {
                return true;
            }
            else
            {
                return false;
            }
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
