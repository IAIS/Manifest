using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using log4net;
using Manifest.Resources;
using Manifest.Shared;
using Manifest.Utils;
using Microsoft.Win32;
using Warehouse.Exceptions;
using Container = Manifest.Shared.Container;

namespace Manifest.UI.Steps.Fake
{
    /// <summary>
    /// Interaction logic for UploadFile.xaml
    /// </summary>
    public partial class UploadFile : DetailsPage
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public UploadFile()
        {
            InitializeComponent();
        }

        private void WorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void WorkerOnDoWork(object sender, DoWorkEventArgs e)
        {
            Voyage manifest = null;

            #region UploadManifest
            try
            {
                String path = e.Argument as String;

                manifest = FakeHelper.GenerateFakeManifest(path);

                ParameterUtility.SetVoyage(manifest);

            }
            catch (UserInterfaceException ex)
            {
                ShowError(ex);
                e.Cancel = true;
            }
            catch (FormatException ex)
            {
                Log.Error("Format Exception Error While Uploading Fake File(WorkerOnDoWork).", ex);
                UserInterfaceException exception = new UserInterfaceException(20002, ExceptionMessage.Format, ex);
                ShowError(exception);
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                Log.Error("Unspecific Exception Error While Uploading Fake File (WorkerOnDoWork).", ex);
                UserInterfaceException exception = new UserInterfaceException(10001, ExceptionMessage.VoyageOpenError, ex);
                ShowError(exception);
                e.Cancel = true;
            }
            #endregion UploadManifest

            #region SaveFile
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (dialog.ShowDialog() == true)
                {

                    File.WriteAllText(dialog.FileName, GetResult(manifest), Encoding.ASCII);
                }
            }
            catch (Exception ex)
            {
                throw new UserInterfaceException(10301, ExceptionMessage.VoyagSave, ex);
            }
            #endregion SaveFile
        }

        private String GetResult(Voyage manifest)
        {
            StringBuilder builder = new StringBuilder("");
            builder.AppendLine("\"VOY\"," + Printer.Print(manifest));

            List<BillOfLading> billOfLadings = manifest.BillOfLadings.ToList();
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

        private void BtnUploadFile_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;
                dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (dialog.ShowDialog() == true)
                {
                    BackgroundWorker worker = new BackgroundWorker();
                    worker.DoWork += WorkerOnDoWork;
                    worker.RunWorkerCompleted += WorkerOnRunWorkerCompleted;
                    worker.RunWorkerAsync(dialog.FileName);
                }
            }
            catch (UserInterfaceException ex)
            {
                ShowError(ex);
            }
            catch (FormatException ex)
            {
                Log.Error("Format Exception Error While Uploading Fake File.", ex);
                UserInterfaceException exception = new UserInterfaceException(40001, ExceptionMessage.Format, ex);
                ShowError(exception);
            }
            catch (Exception ex)
            {
                Log.Error("Unspecific Exception Error While Uploading Fake File.", ex);
                UserInterfaceException exception = new UserInterfaceException(40002, ExceptionMessage.VoyageOpenError, ex);
                ShowError(exception);
            }
        }

        public override void OnNavigatedTo(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {

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
    }
}
