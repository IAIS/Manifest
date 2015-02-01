using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using Manifest.Resources;
using Manifest.Shared;
using Manifest.Utils;
using Microsoft.Win32;
using Warehouse.Exceptions;

namespace Manifest.UI
{
    /// <summary>
    /// Interaction logic for Confirmation.xaml
    /// </summary>
    public partial class Confirmation : MyControl
    {
        public Confirmation()
        {
            InitializeComponent();
        }

        private void BtnSubmit_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (dialog.ShowDialog() == true)
                {
                    
                    File.WriteAllText(dialog.FileName, GetResult(), Encoding.Unicode);
                }
            }
            catch (Exception ex)
            {
                throw new UserInterfaceException(10301, ExceptionMessage.VoyagSave, ex);
            }
        }

        private String GetResult()
        {
            StringBuilder builder = new StringBuilder("");
            builder.AppendLine("\"VOY\"," + Printer.Print(ParameterUtility.GetVoyage()));

            ObservableCollection<BillOfLading> billOfLadings = ParameterUtility.GetBillOfLading();
            foreach (BillOfLading billOfLading in billOfLadings)
            {
                builder.AppendLine("\"BOL\"," + Printer.Print(billOfLading));
                foreach (Container container in billOfLading.Containers)
                {
                    builder.AppendLine("\"CTR\"," + Printer.Print(container));
                    foreach (Consignment consignment in container.Consignments)
                    {
                        builder.AppendLine("\"CON\"," + Printer.Print(consignment));
                    }
                }
            }
            return builder.ToString();
        }

        public override void OnNavigatedTo(NavigationEventArgs e)
        {
            txtResult.Text = GetResult();
        }

        public override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {

        }
    }
}
