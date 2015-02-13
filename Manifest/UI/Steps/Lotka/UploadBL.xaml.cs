using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FirstFloor.ModernUI.Windows.Navigation;
using Manifest.Converter;
using Manifest.Resources;
using Manifest.Shared;
using Manifest.UI.Details;
using Manifest.Utils;
using Microsoft.Win32;
using Warehouse.Exceptions;

namespace Manifest.UI.Steps.Lotka
{
    /// <summary>
    /// Interaction logic for UploadBL.xaml
    /// </summary>
    public partial class UploadBL : DetailsPage
    {
        public UploadBL()
        {
            InitializeComponent();
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
                    ObservableCollection<BillOfLading> temp  = new ObservableCollection<BillOfLading>(billOfLadings);
                    ParameterUtility.SetBillOfLading(temp);
                    UBillOfLadingDetails.Init(temp);
                }
                
            }
            catch (UserInterfaceException ex)
            {
                ShowError(ex);
            }
            catch (FormatException ex)
            {
                UserInterfaceException exception = new UserInterfaceException(20002, ExceptionMessage.Format, ex);
                ShowError(exception);
            }
            catch (Exception ex)
            {
                UserInterfaceException exception = new UserInterfaceException(10001, ExceptionMessage.BillOfLadingOpenError, ex);
                ShowError(exception);
            }
        }

        private void BtnNewBillOfLading_OnClick(object sender, RoutedEventArgs e)
        {
            BillOfLading billOfLading = new BillOfLading();
            UBillOfLadingDetails.Add(billOfLading);
        }

        public override void OnNavigatedTo(NavigationEventArgs e)
        {
            UBillOfLadingDetails.Init(ParameterUtility.GetBillOfLading());
        }

        public override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            try
            {
                UBillOfLadingDetails.Validate();
            }
            catch (UserInterfaceException ex)
            {
                ShowError(ex);
                e.Cancel = true;
            }
        }
    }
}
