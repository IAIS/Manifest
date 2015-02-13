using System.Collections.ObjectModel;
using System.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using Manifest.Shared;
using Manifest.Utils;
using Warehouse.Exceptions;

namespace Manifest.UI.Steps.Hoopad
{
    public partial class UploadBL : DetailsPage
    {
        public UploadBL()
        {
            InitializeComponent();
        }

        public override void OnNavigatedTo(NavigationEventArgs e)
        {
            uBillOfLadingDetails.Init(ParameterUtility.GetBillOfLading());
        }

        public override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            try
            {
                uBillOfLadingDetails.Validate();
            }
            catch (UserInterfaceException ex)
            {
                ShowError(ex);
                e.Cancel = true;
            }
        }

        private void BtnNewBillOfLading_OnClick(object sender, RoutedEventArgs e)
        {
            BillOfLading billOfLading = new BillOfLading();
            uBillOfLadingDetails.Add(billOfLading);
        }
    }
}
