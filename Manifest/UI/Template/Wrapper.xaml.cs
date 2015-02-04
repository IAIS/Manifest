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
                this.ContentSource = new Uri("/UI/Steps/Hoopad/Main.xaml", UriKind.Relative);
            }
            if (Utils.ConfiguraionManager.GetInstance().GetApplicaionType() == ApplicaionType.Lootka)
            {
                this.ContentSource = new Uri("/UI/Steps/Lotka/Main.xaml", UriKind.Relative);
            }
            InitializeComponent();
        }

        ModernFrame _mModernFrame = null;
        
        public ModernFrame ModernFrame
        {
            get
            {
                if (null == _mModernFrame)
                {
                    _mModernFrame = GetTemplateChild("ContentFrame") as ModernFrame;
                }
                return _mModernFrame;
            }
        } 
    }
}
