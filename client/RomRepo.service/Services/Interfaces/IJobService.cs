using RomRepo.service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service.Services.Interfaces
{
    public interface IJobService
    {
        Task<IEnumerable<JobQueue>> GetNewJobs();
        Task<IEnumerable<JobQueue>> GetNewJobs(string jobCode);
        Task<JobQueue> CreateJob(string jobCode);
        Task<JobQueue> StartJob(int jobQueueID);
        Task<JobQueue> UpdateJobProgress(int jobQueueID, int percent);
        Task<JobQueue> FinishJob(int jobQueueID);
    }
}
