using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console.Services
{
    internal class RomService : IRomService
    {
        private readonly ILogger<RomService> _logger;
        public RomService(ILogger<RomService> logger) 
        {
            _logger = logger;
        }


        public bool ExtractRom(string filePath)
        {

            return true;
        }

    }
}
