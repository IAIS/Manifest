using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using Manifest.Converter;
using Manifest.Resources;
using Manifest.Shared;
using Manifest.Utils;
using Microsoft.Win32;
using Warehouse.Exceptions;

namespace Manifest.UI.Steps.Lotka
{
    /// <summary>
    /// Interaction logic for UploadContainer.xaml
    /// </summary>
    public partial class UploadContainer : DetailsPage
    {
        public UploadContainer()
        {
            InitializeComponent();
        }

        private void BtnUploadContainer_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;
                dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                
                if (dialog.ShowDialog() == true)
                {
                    List<Container> containers = SimpleConverter.Convert<Container>(dialog.FileName, "Manifest.Shared.Container");
                    ObservableCollection<Container> temp = new ObservableCollection<Container>(containers);
                    UContainerDetails.Init(temp);
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

        private void BtnNewContainer_OnClick(object sender, RoutedEventArgs e)
        {
            const string message = @"برای افزودن کانتینر جدید از قسمت اطلاعات بارنامه و ستون افزودن کانتینر استفاده نمایید";
            const string caption = "ثبت کانتینر جدید";
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK,
                MessageBoxOptions.RightAlign);
        }

        public override void OnNavigatedTo(NavigationEventArgs e)
        {
            UContainerDetails.Init(ParameterUtility.GetContainers());
        }

        public override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            try
            {
                UContainerDetails.Validate();
            }
            catch (UserInterfaceException ex)
            {
                ShowError(ex);
                e.Cancel = true;
            }
        }
    }
}
