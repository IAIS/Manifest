using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for UploadContainer.xaml
    /// </summary>
    public partial class UploadContainer : System.Windows.Controls.UserControl
    {
        private readonly ObservableCollection<Container> _containers = new ObservableCollection<Container>(); 

        public UploadContainer()
        {
            InitializeComponent();
            gridContainer.ItemsSource = _containers;
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
                    _containers.Clear();
                    foreach (Container jManifestContainer in containers)
                    {
                        _containers.Add(jManifestContainer);
                    }
                    btnNext.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                throw new UserInterfaceException(10101, ExceptionMessage.ContainerOpenError, ex);
            }
        }

        private void BtnNext_OnClick(object sender, RoutedEventArgs e)
        {
            List<BillOfLading> billOfLadings = ((App)Application.Current).BillOfLadings;
            IEnumerable<Container> persistedContainers = billOfLadings.SelectMany(b => b.Containers);
            foreach (Container container in _containers)
            {
                Container persistedContainer = persistedContainers.FirstOrDefault();
                persistedContainer.SealNo = container.SealNo;
                persistedContainer.TareWeightInMT = container.TareWeightInMT;
            }
            
            
        }
    }
}
