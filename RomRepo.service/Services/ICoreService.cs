using RomRepo.console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console.Services
{
    public interface ICoreService
    {
        Task<IEnumerable<Core>> GetActiveCores();
        List<Core> GetFileSystemCores(string rootFolder);
        Task<Core> AddCore(Core core);
        Task<int> AddCores(List<Core> cores);

        Task<bool> UpdateCore(Core core);
    }
}
