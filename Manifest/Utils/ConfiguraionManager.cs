using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manifest.Shared;

namespace Manifest.Utils
{
    public class ConfiguraionManager
    {
        private static ConfiguraionManager _instance;

        private ConfiguraionManager()
        {
            
        }

        public static ConfiguraionManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConfiguraionManager();
            }
            return _instance;
        }

        public ApplicaionType GetApplicaionType()
        {
            return (ApplicaionType)Enum.Parse(typeof(ApplicaionType), System.Configuration.ConfigurationManager.AppSettings["ApplicationType"]);
        }

        public void SetApplicationType(String applicationType)
        {
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings["ApplicationType"].Value = applicationType;
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
