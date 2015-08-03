using System;
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
            if (Utils.ConfiguraionManager.GetInstance().GetApplicaionType() == ApplicaionType.Hoopad )
            {
                this.ContentSource = new Uri("/UI/Steps/Hoopad/Main.xaml", UriKind.Relative);
            }
            if (Utils.ConfiguraionManager.GetInstance().GetApplicaionType() == ApplicaionType.Lotka)
            {
                this.ContentSource = new Uri("/UI/Steps/Lotka/Main.xaml", UriKind.Relative);
            }
            InitializeComponent();
            
        }

    }
}
