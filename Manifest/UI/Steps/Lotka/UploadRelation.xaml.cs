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
    /// Interaction logic for UploadRelation.xaml
    /// </summary>
    public partial class UploadRelation : DetailsPage
    {
        private ObservableCollection<JRelation> _relations;

        public UploadRelation()
        {
            InitializeComponent();
        }

        public override void OnNavigatedTo(NavigationEventArgs e)
        {
            _relations = ParameterUtility.GetRelations();
            gridRelation.ItemsSource = _relations;
            HandleDataGrid();
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
                    List<JRelation> relations = SimpleConverter.Convert<JRelation>(dialog.FileName,
                        "Manifest.Shared.JRelation");
                    _relations.Clear();
                    foreach (JRelation relation in relations)
                    {
                        _relations.Add(relation);
                        AddRelation(relations);
                    }
                    HandleDataGrid();
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

        private void BtnNew_OnClick(object sender, RoutedEventArgs e)
        {
            JRelation relation = new JRelation();
            _relations.Add(relation);
            AddRelation(relation);
            ReationDetails window = new ReationDetails();
            window.Show();
            window.Init(relation);
            HandleDataGrid();
        }

        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {
            String containerNumber = ((Button)sender).CommandParameter.ToString();
            JRelation relation = _relations.FirstOrDefault(c => c.Number.Equals(containerNumber));
            ReationDetails window = new ReationDetails();
            window.Show();
            window.Init(relation);
            HandleDataGrid();
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            String containerNumber = ((Button)sender).CommandParameter.ToString();
            JRelation relation = _relations.FirstOrDefault(c => c.Number.Equals(containerNumber));
            RemoveRelation(relation);
            _relations.Remove(relation);
            HandleDataGrid();
        }

        private void HandleDataGrid()
        {
            if (this._relations.Count == 0)
            {
                this.gridRelation.Visibility = Visibility.Hidden;
            }
            if (this._relations.Count > 0)
            {
                this.gridRelation.Visibility = Visibility.Visible;
            }
        }

        private void AddRelation(ICollection<JRelation> relations)
        {
            
            foreach (JRelation relation in _relations)
            {
                AddRelation(relation);
            }
        }

        private void AddRelation(JRelation relation)
        {
            ObservableCollection<BillOfLading> billOfLadings = ParameterUtility.GetBillOfLading();
            BillOfLading billOfLading = billOfLadings.FirstOrDefault(b => b.BillOfLadingNo.Equals(relation.BolNumber));
            if (billOfLading == null)   // اطلاعات بارگذاری شده مشکل دار است
            {
                return;
            }
            if (!billOfLading.Containers.Any(c => c.ContainerNumber.Equals(relation.Number)))
            {
                Container container = new Container()
                {
                    ContainerNumber = relation.Number,
                };
                container.Consignments.Add(new Consignment()
                {
                    ConsignmentWeightInKg = relation.ConsignmentWeightInKg,
                    NoOfPallets = relation.QuantityInConsignment,
                });
                billOfLading.Containers.Add(container);
            }
        }

        private void RemoveRelation(JRelation relation)
        {
            ObservableCollection<BillOfLading> billOfLadings = ParameterUtility.GetBillOfLading();
            BillOfLading billOfLading = billOfLadings.FirstOrDefault(b => b.BillOfLadingNo.Equals(relation.BolNumber));
            billOfLading.Containers.Remove(billOfLading.Containers.FirstOrDefault(c => c.ContainerNumber.Equals(relation.Number)));
        }

        public override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            try
            {
                foreach (JRelation relation in _relations)
                {
                    if (Utils.Validator.Validate(relation) == false)
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

        private void GridRelation_OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
