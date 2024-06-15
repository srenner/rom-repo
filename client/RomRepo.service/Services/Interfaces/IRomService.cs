﻿using RomRepo.console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service.Services.Interfaces
{
    public interface IRomService
    {
        Task<IEnumerable<Rom>> DiscoverRoms(Core core);
    }
}
