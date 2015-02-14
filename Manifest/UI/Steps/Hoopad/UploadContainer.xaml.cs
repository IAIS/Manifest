using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FirstFloor.ModernUI.Windows.Navigation;
using Manifest.Converter;
using Manifest.Resources;
using Manifest.Shared;
using Manifest.UI.Details;
using Manifest.UserControl;
using Manifest.Utils;
using Microsoft.Win32;
using Warehouse.Exceptions;
using Container = Manifest.Shared.Container;

namespace Manifest.UI.Steps.Hoopad
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
