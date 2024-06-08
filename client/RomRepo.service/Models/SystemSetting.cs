using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console.Models
{
    [Serializable]
    public class SystemSetting
    {
        [Key]
        public string Name { get; set; }
        public string? Value { get; set; }

        public string DataType { get; set; }
        public bool IsRequired { get; set; }
        public bool IsReadOnly { get; set; }
    }
}


