using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Manifest.Converter;
using Manifest.Resources;
using Manifest.Shared;
using Manifest.UI.Details;
using Microsoft.Win32;
using Newtonsoft.Json;
using Warehouse.Exceptions;

namespace Manifest.UI
{
    /// <summary>
    /// Interaction logic for UploadBL.xaml
    /// </summary>
    public partial class UploadBL : System.Windows.Controls.UserControl
    {
        private readonly ObservableCollection<BillOfLading> _billOfLadings = new ObservableCollection<BillOfLading>();

        public UploadBL()
        {
            InitializeComponent();
            gridJFlightConsignment.ItemsSource = _billOfLadings;
            gridJFlightConsignment.Visibility = Visibility.Hidden;
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
                    List<BillOfLading> billOfLadings = SimpleConverter.Convert<BillOfLading>(dialog.FileName, "Manifest.Shared.BillOfLading");
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
                ((App)Application.Current).BillOfLadings = _billOfLadings.ToList();
            }
            catch (Exception ex)
            {
                throw new UserInterfaceException(10001, ExceptionMessage.BillOfLadingOpenError, ex);
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
            if (_billOfLadings.Count == 0)
            {
                gridJFlightConsignment.Visibility = Visibility.Hidden;
            }
        }

        private void BtnNewBillOfLading_OnClick(object sender, RoutedEventArgs e)
        {
            BillOfLading billOfLading = new BillOfLading();
            _billOfLadings.Add(billOfLading);
            BillOfLadingDetails window = new BillOfLadingDetails();
            window.Show();
            window.Init(billOfLading);
            if (_billOfLadings.Count > 0)
            {
                gridJFlightConsignment.Visibility = Visibility.Visible;
            }
        }
    }
}
