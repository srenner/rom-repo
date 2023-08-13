using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.lib
{
    public static class FileUtil
    {
        public static bool TestNetworkPath(string path)
        {
            return new FileInfo(path).Exists;
        }

    }
}
