using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service.Models
{
    public class JobQueue
    {
        public int JobQueueID { get; set; }

        public string JobCode { get; set; }

        /// <summary>
        /// Primary key value of whichever model is being worked
        /// </summary>
        public int? EntityID { get; set; }

        public int TimeLimitSeconds { get; set; }

        public int PercentComplete { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DatePickedUp { get; set; }
        public DateTime? DateComplete { get; set; }
    }
}
