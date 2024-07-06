using RomRepo.console.Migrations;
using RomRepo.service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service.Workers
{
    /// <summary>
    /// Unzips all individual roms and packs them in a single zip file.
    /// </summary>
    public class UnpackWorker : IJobWorker
    {
        public int? EntityID { get; set; }
        public int PercentComplete { get; set; }

        private readonly ICoreService _coreService;

        public UnpackWorker(ICoreService coreService)
        {
            _coreService = coreService;
        }

        public async Task ExecuteJob<Rom>(IEnumerable<Rom> roms)
        {
            throw new NotImplementedException();
        }

        public async Task ExecuteJob(int? entityID)
        {
            if ((entityID.HasValue))
            {
                this.EntityID = entityID;    
            }
            while (true)
            {
                await Task.Delay(1000);
            }
        }
    }
}
