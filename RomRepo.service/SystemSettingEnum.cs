using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console
{
    public  class SystemSettingEnum
    {
        private SystemSettingEnum(string value) { Value = value; }

        public string Value { get; private set; }

        public static SystemSettingEnum UniqueIdentifier { get { return new SystemSettingEnum("UniqueIdentifier"); } }
        public static SystemSettingEnum SendAnalytics { get { return new SystemSettingEnum("SendAnalytics"); } }
        public static SystemSettingEnum UseApi { get { return new SystemSettingEnum("UseApi"); } }
        public static SystemSettingEnum RomRootFolder { get { return new SystemSettingEnum("RomRootFolder"); } }
        public static SystemSettingEnum SavesRootFolder { get { return new SystemSettingEnum("SavesRootFolder"); } }
        public static SystemSettingEnum SaveStatesRootFolder { get { return new SystemSettingEnum("SaveStatesRootFolder"); } }
        public static SystemSettingEnum ApiKey { get { return new SystemSettingEnum("ApiKey"); } }

    }
}
