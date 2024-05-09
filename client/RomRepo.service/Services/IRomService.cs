using RomRepo.console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console.Services
{
    public interface IRomService
    {
        List<Rom> GetFileSystemRoms(Core core);
    }
}
