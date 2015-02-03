using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
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
    /// Interaction logic for UploadVoyage.xaml
    /// </summary>
    public partial class UploadVoyage : MyControl
    {

        public UploadVoyage()
        {
            InitializeComponent();
        }

        private void BtnUploadVoyage_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;
                dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (dialog.ShowDialog() == true)
                {
                    if (ParameterUtility.GetBillOfLading().Count > 0)
                    {
                        const string caption = "ثبت اطلاعات بارنامه";
                        const string content =
                            @"با بارگزاری اطلاعات مانیفست تمام بارنامه های ثبت شده و اطلاعات کانتینر و کالاهای مرتبط با آن ها حدف می شوند.
\nآیا مطمئن هستید می خواهید اطلاعات بارنامه را ثبت کنید؟";
                        if (MessageBox.Show(String.Format(content), caption, MessageBoxButton.YesNo,
                            MessageBoxImage.Warning,
                            MessageBoxResult.Yes, MessageBoxOptions.RightAlign) == MessageBoxResult.No)
                        {
                            return;
                        }
                    }
                    List<Voyage> voyages = SimpleConverter.Convert<Voyage>(dialog.FileName, "Manifest.Shared.Voyage");
                    if (voyages.Count == 1)
                    {
                        //TODO: do what is written in jira
                        ParameterUtility.SetVoyage(voyages.FirstOrDefault());
                        ucVoyage.Init(voyages.FirstOrDefault());
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

        public override void OnNavigatedTo(NavigationEventArgs e)
        {
            ucVoyage.Init(ParameterUtility.GetVoyage());
//            
        }

        public override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            try
            {
                if (Utils.Validator.Validate(ParameterUtility.GetVoyage()) == false)
                {
                    return;
                }
            }
            catch (UserInterfaceException ex)
            {
                ShowError(ex);
                e.Cancel = true;
            }
        }

        private void BtnTest_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;
                dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (dialog.ShowDialog() == true)
                {
                    XmlConverter.Convert<Data>(dialog.FileName);
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
