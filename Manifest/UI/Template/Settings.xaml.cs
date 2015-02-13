using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Manifest.Shared;
using Manifest.Utils;
using NavigationEventArgs = FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs;

namespace Manifest.UI.Template
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : DetailsPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        public override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            cbxApplicationType.ItemsSource = Enum.GetNames(typeof (ApplicaionType));
            cbxApplicationType.SelectedIndex = (int)ConfiguraionManager.GetInstance().GetApplicaionType();
            lblVersion.Text = Utils.CommonUtility.GetPublishedVersion();
            txtLineCode.Text = ConfiguraionManager.GetInstance().GetLineCode();
            txtVoyageAgentCode.Text = ConfiguraionManager.GetInstance().GetVoyageAgentCode();
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            Wrapper window = (Wrapper)Window.GetWindow(this);
            ConfiguraionManager.GetInstance().SetApplicationType(cbxApplicationType.SelectedValue.ToString());
            ConfiguraionManager.GetInstance().SetLineCode(txtLineCode.Text);
            ConfiguraionManager.GetInstance().SetVoyageAgentCode(txtVoyageAgentCode.Text);
            Wrapper newWindows = new Wrapper();
            newWindows.Show();
            window.Close();
        }
    }
}
