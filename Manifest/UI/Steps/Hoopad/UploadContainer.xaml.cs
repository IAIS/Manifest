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
using Manifest.Utils;
using Microsoft.Win32;
using Warehouse.Exceptions;
using Container = Manifest.Shared.Container;

namespace Manifest.UI.Steps.Hoopad
{
    /// <summary>
    /// Interaction logic for UploadContainer.xaml
    /// </summary>
    public partial class UploadContainer : MyControl
    {
        private ObservableCollection<Container> _containers;

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

        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {
            Container container = ((FrameworkElement)sender).DataContext as Container;
            ContainerDetails window = new ContainerDetails();
            window.Show();
            window.Init(container);
            HandleDataGrid();
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            Container container = ((FrameworkElement)sender).DataContext as Container;
            _containers.Remove(container);
            ParameterUtility.RemoveContainer(container);
            HandleDataGrid();
        }

        private void HandleDataGrid()
        {
            if (_containers.Count == 0)
            {
                this.gridContainer.Visibility = Visibility.Hidden;
            }
            if (_containers.Count > 0)
            {
                this.gridContainer.Visibility = Visibility.Visible;
            }
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            Container container = ((FrameworkElement)sender).DataContext as Container;
            Consignment consignment = new Consignment();
            container.Consignments.Add(consignment);
            ConsignmentDetails window = new ConsignmentDetails();
            window.Show();
            window.Init(consignment);
        }

        private void AddContainer(Container container)
        {
            BillOfLading persistedBillOfLading =
                            ParameterUtility.GetBillOfLading()
                                .FirstOrDefault(b => b.Containers.Any(c => c.ContainerNumber.Equals(container.ContainerNumber)));
            if (persistedBillOfLading != null)
            {
                Container persistedContainer = persistedBillOfLading.Containers.FirstOrDefault
                    (c => c.ContainerNumber.Equals(container.ContainerNumber));
                persistedBillOfLading.Containers.Remove(persistedContainer);
                persistedBillOfLading.Containers.Add(container);
                container.Consignments = persistedContainer.Consignments;
                _containers.Remove(persistedContainer);
                _containers.Add(container);
            }
            else
            {
                // فایل مشکل دارد
            }
        }

        private void RemoveContainer(Container container)
        {
            BillOfLading persistedBillOfLading =
                            ParameterUtility.GetBillOfLading()
                                .FirstOrDefault(b => b.Containers.Any(c => c.ContainerNumber.Equals(container.ContainerNumber)));
            Container persistedContainer = persistedBillOfLading.Containers.FirstOrDefault
                    (c => c.ContainerNumber.Equals(container.ContainerNumber));
            persistedBillOfLading.Containers.Remove(persistedContainer);
        }

        public override void OnNavigatedTo(NavigationEventArgs e)
        {
            _containers = ParameterUtility.GetContainers();
            gridContainer.ItemsSource = _containers;
            HandleDataGrid();
        }

        public override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            try
            {
                foreach (Container container in _containers)
                {
                    if (Utils.Validator.Validate(container) == false)
                    {
                        break;
                    }
                }
            }
            catch (UserInterfaceException ex)
            {
                ShowError(ex);
                e.Cancel = true;
            }
        }
    }
}
