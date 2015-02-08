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
    public partial class UploadConsignment : MyControl
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

        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {
            Consignment consignment = ((FrameworkElement)sender).DataContext as Consignment;
            ConsignmentDetails window = new ConsignmentDetails();
            window.Show();
            window.Init(consignment);
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            Consignment consignment =  ((FrameworkElement)sender).DataContext as Consignment;
            _consignments.Remove(consignment);
            ParameterUtility.RemoveConsignment(consignment);
            HandleDataGrid();
        }

        private void HandleDataGrid()
        {
            if (_consignments.Count == 0)
            {
                gridJFlightConsignment.Visibility = Visibility.Hidden;
            }
            else
            {
                gridJFlightConsignment.Visibility = Visibility.Visible;
            }
        }

        public override void OnNavigatedTo(NavigationEventArgs e)
        {
            _consignments = ParameterUtility.GetConsignments();
            gridJFlightConsignment.ItemsSource = _consignments;
            HandleDataGrid();
        }

        public override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            try
            {
                foreach (Consignment consignment in _consignments)
                {
                    if (Utils.Validator.Validate(consignment) == false)
                    {
                        break;
                    }
                }
            }
            catch (UserInterfaceException ex)
            {
                ShowError(ex);
                e.Cancel = true;
            }
        }

    }
}
