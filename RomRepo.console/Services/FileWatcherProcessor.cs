using RomRepo.console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console.Services
{
    internal class FileWatcherProcessor
    {
        private List<SystemSetting> _settings;

        public FileWatcherProcessor(List<SystemSetting> settings)
        {
            _settings = settings;
        }


        internal void ProcessFileEvent(FileSystemEventArgs evt)
        {

        }

    }
}
