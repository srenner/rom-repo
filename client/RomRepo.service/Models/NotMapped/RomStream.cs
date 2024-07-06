using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service.Models.NotMapped
{
    /// <summary>
    /// Container class to hold a MemoryStream with its associated Filename
    /// </summary>
    public class RomStream
    {
        public RomStream() 
        { 
            MemoryStream = new MemoryStream();
        }
        public string Filename { get; set; }
        public MemoryStream MemoryStream { get; set; }
    }
}
