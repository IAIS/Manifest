using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Manifest.Converter;
using Manifest.Resources;
using Manifest.Shared;
using Manifest.Template.Hoopad;
using Manifest.Utils;
using Microsoft.Win32;
using Warehouse.Exceptions;

namespace Manifest.UI.Steps.Hoopad
{
    /// <summary>
    /// Interaction logic for UploadFile.xaml
    /// </summary>
    public partial class UploadFile : MyControl
    {
        public UploadFile()
        {
            InitializeComponent();
        }

        private void BtnUploadFile_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;
                dialog.Filter = "Xml files (*.xml)|*.xml|All files (*.*)|*.*";
                if (dialog.ShowDialog() == true)
                {
                    Data data = XmlConverter.Convert<Data>(dialog.FileName);
                    Voyage voyage = ParameterUtility.GetVoyage();
                    foreach (Template.Hoopad.Manifest dataManifest in data.Items)
                    {
                        ClassConverter.Convert(dataManifest, voyage);
                    }
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
                UserInterfaceException exception = new UserInterfaceException(10001, ExceptionMessage.VoyageOpenError, ex);
                ShowError(exception);
            }
        }
    }
}
