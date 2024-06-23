using RomRepo.console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service.Services.Interfaces
{
    public interface IRomService
    {
        Task<Rom> GetRom(int romID);
        Task<IEnumerable<Rom>> GetRomsForCore(int coreID);

        /// <summary>
        /// Returns list of Roms that are not in the database
        /// </summary>
        /// <param name="core"></param>
        /// <returns></returns>
        Task<IEnumerable<Rom>> DiscoverRoms(Core core);

        Task<Rom> AddRom(Rom rom);
        Task<int> AddRoms(IEnumerable<Rom> roms);

        MemoryStream ExtractAndPack(IEnumerable<Rom> roms);
    }
}
