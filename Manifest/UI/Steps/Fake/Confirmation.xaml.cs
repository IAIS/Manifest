using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using Ionic.Zip;
using Manifest.Resources;
using Manifest.Shared;
using Manifest.Utils;
using Microsoft.Win32;
using Warehouse.Exceptions;

namespace Manifest.UI.Steps.Fake
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
                    File.WriteAllText(dialog.FileName, Printer.GetResult(), Encoding.ASCII);
                }
            }
            catch (Exception ex)
            {
                throw new UserInterfaceException(10301, ExceptionMessage.VoyagSave, ex);
            }
        }



        public override void OnNavigatedTo(NavigationEventArgs e)
        {
            txtResult.Text = Utils.Printer.GetResult();
        }

        public override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {

        }

        private void BtnZip_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog { Filter = "Zip files (*.zip)|*.zip|All files (*.*)|*.*" };
                if (dialog.ShowDialog() == true)
                {
                    ArchiveHelper.Compress(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                throw new UserInterfaceException(10301, ExceptionMessage.VoyagSave, ex);
            }
        }
    }
}
