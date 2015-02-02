using System;
using System.Configuration;
using FirstFloor.ModernUI.Windows.Controls;
using Manifest.Shared;

namespace Manifest.UI
{
    /// <summary>
    /// Interaction logic for Wrapper.xaml
    /// </summary>
    public partial class Wrapper : ModernWindow 
    {
        public Wrapper()
        {
            if (Utils.ConfiguraionManager.GetInstance().GetApplicaionType() == ApplicaionType.Hoopad)
            {
                Uri uri = new Uri("/UI/Template/Main.xaml", UriKind.Relative);
                //            new Uri("pack://application:,,,/Manifest;component/UI\\Template\\Main.xaml");
                this.ContentSource = uri;
                //            this.ContentSource = new Uri("/UI\\Template\\Main.xaml");
                InitializeComponent();
            }
        }
    }
}
