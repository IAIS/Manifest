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
                    List<BillOfLading> consignments = SimpleConverter.Convert<BillOfLading>(dialog.FileName, "Manifest.Shared.BillOfLading");
                    _billOfLadings.Clear();
                    foreach (BillOfLading consignment in consignments)
                    {
                        _billOfLadings.Add(consignment);
                    }
                    btnNext.IsEnabled = true;
                }
                ((App)Application.Current).BillOfLadings = _billOfLadings.ToList();
            }
            catch (Exception ex)
            {
                throw new UserInterfaceException(10001, ExceptionMessage.BillOfLadingOpenError, ex);
            }
        }

        private void BtnNext_OnClick(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("temp2.txt", JsonConvert.SerializeObject(_billOfLadings), Encoding.UTF8);
        }

        private void GridJFlightConsignment_OnSelected(object sender, RoutedEventArgs e)
        {
            //            BillOfLading billOfLading = (BillOfLading)e.Source;
            //            uBillOfLading.Init(billOfLading);
        }

        private void GridJFlightConsignment_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {
            //            String billNo = ((Button)sender).CommandParameter.ToString();
            //            BillOfLading billOfLading = _billOfLadings.FirstOrDefault(b => b.BillOfLadingNo.Equals(billNo));
            //            BillOfLadingDetails window = new BillOfLadingDetails();
            //            window.SetContent(billOfLading);
            //            window.Show();
            String billNo = ((Button)sender).CommandParameter.ToString();
            BillOfLading billOfLading = _billOfLadings.FirstOrDefault(b => b.BillOfLadingNo.Equals(billNo));
            uBilOfLading.Init(billOfLading);
        }
    }
}
