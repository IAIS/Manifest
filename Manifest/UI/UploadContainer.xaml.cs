using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    public partial class UploadContainer : UserControl
    {
        private readonly ObservableCollection<JManifestContainer> _containers = new ObservableCollection<JManifestContainer>(); 

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
                    List<JManifestContainer> containers = SimpleConverter.Convert<JManifestContainer>(dialog.FileName, "Manifest.Shared.JManifestContainer");
                    _containers.Clear();
                    foreach (JManifestContainer jManifestContainer in containers)
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
            File.WriteAllText("temp.txt", JsonConvert.SerializeObject(_containers), Encoding.UTF8);
        }
    }
}
