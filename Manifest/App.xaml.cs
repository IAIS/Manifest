using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows;
using Manifest.Shared;
using Manifest.Utils;

namespace Manifest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.Voyage = new Voyage();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            log4net.Config.XmlConfigurator.Configure();
//#if DEBUG
//            const string path = "C:\\Users\\AbouzarKamaee\\Desktop\\2.man";
//            JavaScriptSerializer serializer = new JavaScriptSerializer();
//            serializer.MaxJsonLength = Int32.MaxValue;
//            String hexContent = File.ReadAllText(path);
//            String plainContent = Utils.CommonUtility.HexStringToString(hexContent, Encoding.UTF8);
//            Voyage voyage = serializer.Deserialize<Voyage>(plainContent);
//            ParameterUtility.SetVoyage(voyage);
//        
//#endif
            if (Utils.ConfiguraionManager.GetInstance().GetApplicaionType() == ApplicaionType.Fake)
            {
                FakeServiceHelper.GetInstance().Init();
            }
        }

        public Voyage Voyage { get; set; }
    }
}
