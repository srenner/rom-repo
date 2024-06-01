using RomRepo.console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service.Services.Interfaces
{
    public interface ICoreService
    {
        Task<IEnumerable<Core>> GetAllCores();
        Task<IEnumerable<Core>> GetActiveCores();
        Task<IEnumerable<Core>> GetInactiveCores();
        Task<IEnumerable<DirectoryInfo>> DiscoverCores();
        List<Core> GetFileSystemCores();
        Task<Core> AddCore(Core core);
        Task<int> AddCores(List<Core> cores);

        Task<bool> UpdateCore(Core core);
    }
}
