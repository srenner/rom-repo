using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service.Models.NotMapped
{
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
