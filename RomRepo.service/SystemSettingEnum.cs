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

        /// <summary>
        /// GUID identifier for each client install. Used for analytics and API keys.
        /// </summary>
        public static SystemSettingEnum UniqueIdentifier { get { return new SystemSettingEnum("UniqueIdentifier"); } }
        public static SystemSettingEnum SendAnalytics { get { return new SystemSettingEnum("SendAnalytics"); } }
        public static SystemSettingEnum UseApi { get { return new SystemSettingEnum("UseApi"); } }
        /// <summary>
        /// Base folder for game storage
        /// </summary>
        public static SystemSettingEnum RomRootFolder { get { return new SystemSettingEnum("RomRootFolder"); } }
        /// <summary>
        /// Base folder for save file storage
        /// </summary>
        public static SystemSettingEnum SavesRootFolder { get { return new SystemSettingEnum("SavesRootFolder"); } }
        /// <summary>
        /// Base folder for savestate storage
        /// </summary>
        public static SystemSettingEnum SaveStatesRootFolder { get { return new SystemSettingEnum("SaveStatesRootFolder"); } }
        /// <summary>
        /// Server generated key for API
        /// </summary>
        public static SystemSettingEnum ApiKey { get { return new SystemSettingEnum("ApiKey"); } }
    }
}
