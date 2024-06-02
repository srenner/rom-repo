using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service.Models.NotMapped
{
    [NotMapped]
    public class SystemSettingPostModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
