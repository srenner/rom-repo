using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service.ViewModels
{
    public class DirectoryInfoViewModel
    {
        public string Name { get; set; }
        public string? Parent { get; set; }
        public string FullPath { get; set; }
    }
}
