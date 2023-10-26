using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console.DataAccess
{
    public interface IRepoRepo
    {
        void GetAllCores();
        void GetCore(int coreID);
        void UpdateCore(int coreID);

        void GetRomsForCore(int coreID);
        void GetRom(int romID);
        void UpdateRom(int romID);


        void GetSystemSettings();
        void AddSystemSetting();
        void UpdateSystemSetting();


    }
}
