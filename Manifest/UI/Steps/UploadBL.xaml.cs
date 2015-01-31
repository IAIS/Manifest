using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using Manifest.Converter;
using Manifest.Resources;
using Manifest.Shared;
using Manifest.UI.Details;
using Manifest.Utils;
using Microsoft.Win32;
using Newtonsoft.Json;
using Warehouse.Exceptions;

namespace Manifest.UI
{
    /// <summary>
    /// Interaction logic for UploadBL.xaml
    /// </summary>
    public partial class UploadBL : System.Windows.Controls.UserControl, IContent
    {
        private ObservableCollection<BillOfLading> _billOfLadings;

        public UploadBL()
        {
            InitializeComponent();
            
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            _billOfLadings = ParameterUtility.GetBillOfLading();
            gridJFlightConsignment.ItemsSource = _billOfLadings;
            HandleDataGrid();
        }

        private void BtnUploadBillOfLading_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;
                dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (dialog.ShowDialog() == true)
                {

                    List<BillOfLading> billOfLadings = SimpleConverter.Convert<BillOfLading>(dialog.FileName,
                        "Manifest.Shared.BillOfLading");
                    _billOfLadings.Clear();
                    foreach (BillOfLading billOfLading in billOfLadings)
                    {
                        _billOfLadings.Add(billOfLading);
                    }
                }
                if (_billOfLadings.Count > 0)
                {
                    gridJFlightConsignment.Visibility = Visibility.Visible;
                }
                ParameterUtility.SetBillOfLading(_billOfLadings);
            }
            catch (Exception ex)
            {
                throw new UserInterfaceException(10001, ExceptionMessage.BillOfLadingOpenError, ex);
            }
            finally
            {
                HandleDataGrid();
            }
        }

        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {
            String billNo = ((Button)sender).CommandParameter.ToString();
            BillOfLading billOfLading = _billOfLadings.FirstOrDefault(b => b.BillOfLadingNo.Equals(billNo));
            BillOfLadingDetails window = new BillOfLadingDetails();
            window.Show();
            window.Init(billOfLading);
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            String billNo = ((Button)sender).CommandParameter.ToString();
            BillOfLading billOfLading = _billOfLadings.FirstOrDefault(b => b.BillOfLadingNo.Equals(billNo));
            _billOfLadings.Remove(billOfLading);
            HandleDataGrid();
        }

        private void BtnNewBillOfLading_OnClick(object sender, RoutedEventArgs e)
        {
            BillOfLading billOfLading = new BillOfLading();
            _billOfLadings.Add(billOfLading);
            BillOfLadingDetails window = new BillOfLadingDetails();
            window.Show();
            window.Init(billOfLading);
            HandleDataGrid();
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            String billNo = ((Button)sender).CommandParameter.ToString();
            BillOfLading billOfLading = _billOfLadings.FirstOrDefault(b => b.BillOfLadingNo.Equals(billNo));
            Container container = new Container();
            billOfLading.Containers.Add(container);
            ContainerDetails window = new ContainerDetails();
            window.Show();
            window.Init(container);
            HandleDataGrid();
        }

        private void HandleDataGrid()
        {
            if (_billOfLadings.Count > 0)
            {
                gridJFlightConsignment.Visibility = Visibility.Visible;
            }
            else
            {
                gridJFlightConsignment.Visibility = Visibility.Hidden;
            }
        }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {

        }



        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {

        }
    }
}
