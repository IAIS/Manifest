using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
    public partial class UploadBL : UserControl
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
                    List <BillOfLading> consignments = SimpleConverter.Convert<BillOfLading>(dialog.FileName, "Manifest.Shared.BillOfLading");
                    _billOfLadings.Clear();
                    foreach (BillOfLading consignment in consignments)
                    {
                        _billOfLadings.Add(consignment);
                    }
                    btnNext.IsEnabled = true;
                }
                ((App) Application.Current).BillOfLadings = _billOfLadings.ToList();
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
    }
}
