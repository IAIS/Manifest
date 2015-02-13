﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Navigation;
using log4net;
using Manifest.Converter;
using Manifest.Resources;
using Manifest.Shared;
using Manifest.Template.Hoopad;
using Manifest.UI.Template;
using Manifest.Utils;
using Microsoft.Win32;
using Warehouse.Exceptions;
using Container = Manifest.Shared.Container;

namespace Manifest.UI.Steps.Hoopad
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
            if (e.Cancelled == true)
            {
                IsLoaded();
                return;
            }
            else
            {
                Voyage voyage = e.Result as Voyage;
                ucVoyage.Init(voyage);
                btnUploadFile.IsEnabled = false;
                IsLoaded();
            }
        }

        private void WorkerOnDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                String path = e.Argument as String;
                Manifest.Template.Hoopad.Manifest manifest = XmlConverter.Convert<Data>(path).Items;
                Voyage voyage = ParameterUtility.GetVoyage();
                ClassConverter.Convert(manifest, voyage);
                foreach (BLSBL blsbl in manifest.BLS)
                {
                    BillOfLading billOfLading = new BillOfLading();
                    ClassConverter.Convert(blsbl, billOfLading);
                    ClassConverter.Convert(blsbl.Shipper, billOfLading);
                    foreach (ContainerDataContainer containerDataContainer in blsbl.ContainerData)
                    {
                        Container container = new Container();
                        ClassConverter.Convert(containerDataContainer, container);
                        ClassConverter.Convert(containerDataContainer, billOfLading);
                        foreach (PricingDataPrice pricingDataPrice in blsbl.PricingData)
                        {
                            Consignment consignment = new Consignment();
                            ClassConverter.Convert(pricingDataPrice, consignment);
                            ClassConverter.Convert(containerDataContainer, consignment);
                            ClassConverter.Convert(blsbl, consignment);
                            consignment.Finilize();
                            container.Consignments.Add(consignment);
                        }
                        billOfLading.Containers.Add(container);
                    }
                    billOfLading.Finilize();
                    voyage.BillOfLadings.Add(billOfLading);
                }
                e.Result = voyage;

            }
            catch (UserInterfaceException ex)
            {
                ShowError(ex);
                e.Cancel = true;
            }
            catch (FormatException ex)
            {
                Log.Error("Format Exception Error While Uploading File(WorkerOnDoWork) in Hoopad Mode.", ex);
                UserInterfaceException exception = new UserInterfaceException(20002, ExceptionMessage.Format, ex);
                ShowError(exception);
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                Log.Error("Unspecific Exception Error While Uploading File(WorkerOnDoWork) in Hoopad Mode.", ex);
                UserInterfaceException exception = new UserInterfaceException(10001, ExceptionMessage.VoyageOpenError, ex);
                ShowError(exception);
                e.Cancel = true;
            }
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
                    IsLoading();
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
                Log.Error("Format Exception Error While Uploading File(BtnUploadFile_OnClick) in Hoopad Mode.", ex);
                UserInterfaceException exception = new UserInterfaceException(20002, ExceptionMessage.Format, ex);
                ShowError(exception);
            }
            catch (Exception ex)
            {
                Log.Error("Unspecific Exception Error While Uploading File(BtnUploadFile_OnClick) in Hoopad Mode.", ex);
                UserInterfaceException exception = new UserInterfaceException(10001, ExceptionMessage.VoyageOpenError, ex);
                ShowError(exception);
            }
        }

        public override void OnNavigatedTo(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            ucVoyage.Init(ParameterUtility.GetVoyage());
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
