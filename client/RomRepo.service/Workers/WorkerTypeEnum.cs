using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service.Workers
{
    public class WorkerTypeEnum
    {
        public string Value { get; private set; }

        private WorkerTypeEnum(string value)
        {
            Value = value;
        }

        public static List<string> GetAll()
        {
            // TODO Use reflection to populate list automatically...?
            var list = new List<string>();
            list.Add(WorkerTypeEnum.Unpack.Value);
            list.Add(WorkerTypeEnum.Zip.Value);
            list.Add(WorkerTypeEnum.Checksum.Value);
            list.Add(WorkerTypeEnum.Filescan.Value);
            return list;
        }

        public static WorkerTypeEnum Unpack
        {
            get
            {
                return new WorkerTypeEnum("unpack");
            }
        }

        public static WorkerTypeEnum Zip
        {
            get
            {
                return new WorkerTypeEnum("zip");
            }
        }

        public static WorkerTypeEnum Checksum
        {
            get
            {
                return new WorkerTypeEnum("checksum");
            }
        }

        public static WorkerTypeEnum Filescan
        {
            get
            {
                return new WorkerTypeEnum("filescan");
            }
        }
    }
}
