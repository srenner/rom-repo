using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console.Services
{
    public interface ICoreService
    {
        Task<int> FindAndAddCores(string rootFolder);
    }
}
