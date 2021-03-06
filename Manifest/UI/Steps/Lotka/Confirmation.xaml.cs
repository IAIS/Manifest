﻿using System;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using Ionic.Zip;
using Manifest.Resources;
using Manifest.Shared;
using Manifest.Utils;
using Microsoft.Win32;
using Warehouse.Exceptions;

namespace Manifest.UI.Steps.Lotka
{
    /// <summary>
    /// Interaction logic for Confirmation.xaml
    /// </summary>
    public partial class Confirmation : DetailsPage
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

                    File.WriteAllText(dialog.FileName, GetResult(), Encoding.ASCII);
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

        private void BtnZip_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Zip files (*.zip)|*.zip|All files (*.*)|*.*";
                if (dialog.ShowDialog() == true)
                {
                    using (ZipFile zip = new ZipFile())
                    {
                        String fileName = "Manifest_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        zip.AddEntry(fileName, GetResult(), System.Text.Encoding.ASCII);
                        zip.Save(dialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new UserInterfaceException(10301, ExceptionMessage.VoyagSave, ex);
            }
        }
    }
}
