﻿using RomRepo.service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service.Workers
{
    internal interface IJobWorker
    {
        public int? EntityID { get; set; }
        public Task ExecuteJob(int? entityID);
    }
}
