using RomRepo.service.Models;
using RomRepo.service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service.Services
{
    public class JobService : IJobService
    {
        public Task<JobQueue> CreateJob(string jobCode)
        {
            throw new NotImplementedException();
        }

        public Task<JobQueue> FinishJob(int jobQueueID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<JobQueue>> GetNewJobs()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<JobQueue>> GetNewJobs(string jobCode)
        {
            throw new NotImplementedException();
        }

        public Task<JobQueue> StartJob(int jobQueueID)
        {
            throw new NotImplementedException();
        }

        public Task<JobQueue> UpdateJobProgress(int jobQueueID, int percent)
        {
            throw new NotImplementedException();
        }
    }
}
