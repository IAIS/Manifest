using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using FirstFloor.ModernUI.Windows;
using Manifest.Shared;
using Manifest.UI.Details;
using Manifest.Utils;
using Warehouse.Exceptions;
using FragmentNavigationEventArgs = FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs;
using NavigatingCancelEventArgs = FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs;
using NavigationEventArgs = FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs;

namespace Manifest.UI.Steps
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

        private void BtnUploadConsignment_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
            HandleDataGrid();
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
