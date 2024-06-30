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
    public class UnzipWorker : IJobWorker
    {
        public int? EntityID { get; set; }

        private readonly ICoreService _coreService;

        public UnzipWorker(ICoreService coreService)
        {
            _coreService = coreService;
        }

        public async Task ExecuteJob(IEnumerable<Rom> roms)
        {

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
