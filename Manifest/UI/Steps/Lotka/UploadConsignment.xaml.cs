using System.Collections.ObjectModel;
using System.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using Manifest.Shared;
using Manifest.UI.Details;
using Manifest.Utils;
using Warehouse.Exceptions;

namespace Manifest.UI.Steps.Lotka
{
    /// <summary>
    /// Interaction logic for UploadConsignment.xaml
    /// </summary>
    public partial class UploadConsignment : DetailsPage
    {
        private ObservableCollection<Consignment> _consignments; 

        public UploadConsignment()
        {
            InitializeComponent();
        }

        private void BtnNewConsignment_OnClick(object sender, RoutedEventArgs e)
        {
            const string message = @"برای افزودن کالای جدید از قسمت اطلاعات کانتینر و ستون افزودن کالا استفاده نمایید";
            const string caption = "ثبت کالای جدید";
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK,
                MessageBoxOptions.RightAlign);
        }

        public override void OnNavigatedTo(NavigationEventArgs e)
        {
            UConsignmentDetails.Init(ParameterUtility.GetConsignments());
        }

        public override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            try
            {
                UConsignmentDetails.Validate();
            }
            catch (UserInterfaceException ex)
            {
                ShowError(ex);
                e.Cancel = true;
            }
        }

    }
}
