using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console
{
    public class SystemSettingEnum
    {
        private SystemSettingEnum(string value) 
        { 
            Value = value; 
        }

        private SystemSettingEnum(string value, bool isRequired, bool isReadOnly)
        {
            Value = value;
            IsRequired = isRequired;
            IsReadOnly = isReadOnly;
        }

        public string Value { get; private set; }
        public bool? IsRequired { get; private set; }
        public bool? IsReadOnly { get; private set; }

        /// <summary>
        /// GUID identifier for each client install. Used for analytics and API keys.
        /// </summary>
        public static SystemSettingEnum UniqueIdentifier 
        { 
            get 
            { 
                return new SystemSettingEnum("UniqueIdentifier", isRequired: true, isReadOnly: true); 
            } 
        }
        public static SystemSettingEnum SendAnalytics 
        { 
            get 
            { 
                return new SystemSettingEnum(value: "SendAnalytics", isRequired: false, isReadOnly: false);
            }
        }
        public static SystemSettingEnum UseApi 
        { 
            get 
            { 
                return new SystemSettingEnum(value: "UseApi", isRequired: false, isReadOnly: false);
            }
        }
        /// <summary>
        /// Base folder for game storage
        /// </summary>
        public static SystemSettingEnum RomRootFolder 
        { 
            get 
            {
                return new SystemSettingEnum(value: "RomRootFolder", isRequired: true, isReadOnly: false);
            }
        }
        /// <summary>
        /// Base folder for save file storage
        /// </summary>
        public static SystemSettingEnum SavesRootFolder
        { 
            get 
            { 
                return new SystemSettingEnum(value: "SavesRootFolder", isRequired: false, isReadOnly: false);
            }
        }
        /// <summary>
        /// Base folder for savestate storage
        /// </summary>
        public static SystemSettingEnum SaveStatesRootFolder
        { 
            get 
            { 
                return new SystemSettingEnum(value: "SaveStatesRootFolder", isRequired: false, isReadOnly: false);
            }
        }
        /// <summary>
        /// Server generated key for API
        /// </summary>
        public static SystemSettingEnum ApiKey 
        { 
            get 
            { 
                return new SystemSettingEnum(value: "ApiKey", isRequired: false, isReadOnly: true);
            }
        }
    }
}
