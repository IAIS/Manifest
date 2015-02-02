using System;
using System.Collections.Generic;
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
    }
}
