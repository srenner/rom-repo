using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console.Models
{
    public class SystemSetting
    {
        [Key]
        public string Name { get; set; }
        public string Value { get; set; }
    }
}


