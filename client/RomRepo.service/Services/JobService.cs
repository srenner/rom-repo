using RomRepo.console.DataAccess;
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
        private readonly IClientRepo _clientRepo;
        public JobService(IClientRepo clientRepo)
        {
            _clientRepo = clientRepo;
        }

        public Task<JobQueue> CreateJob(string jobCode)
        {
            throw new NotImplementedException();
        }

        public Task<JobQueue> FinishJob(int jobQueueID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<JobQueue>> GetNewJobs()
        {
            return await _clientRepo.GetNewJobs();
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
