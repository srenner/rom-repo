using RomRepo.console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service
{
    public static class ExtensionMethods
    {
        public static Core FromDirectoryInfo(this DirectoryInfo di)
        {
            return new()
            {
                Path = di.FullName,
                Name = di.Name,
                DateCreated = di.CreationTime,
                DateUpdated = di.LastWriteTime,
                IsActive = true
            };
        }
    }
}
