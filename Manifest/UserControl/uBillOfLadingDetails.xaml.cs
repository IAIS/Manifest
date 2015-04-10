using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Manifest.Shared;
using Manifest.UI.Details;
using Manifest.Utils;
using Warehouse.Exceptions;
using Container = Manifest.Shared.Container;

namespace Manifest.UserControl
{
    public partial class uBillOfLadingDetails: Details, IDetails<BillOfLading>
    {
        private readonly DetailsManager _manager;
        private ObservableCollection<BillOfLading> _billOfLadings;

        public uBillOfLadingDetails()
        {
            InitializeComponent();
            _manager = DetailsManager.GetInstance();
        }

        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {
            BillOfLading billOfLading = ((FrameworkElement)sender).DataContext as BillOfLading;
            UI.Template.Details window = new UI.Template.Details();
            window.Show();
            window.Init(billOfLading, _manager.GetBillOfLadingFilters());
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            BillOfLading billOfLading = ((FrameworkElement)sender).DataContext as BillOfLading;
            _billOfLadings.Remove(billOfLading);
            ParameterUtility.GetVoyage().BillOfLadings.Remove(billOfLading);
            HandleDataGrid();
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            BillOfLading billOfLading = ((FrameworkElement)sender).DataContext as BillOfLading;
            Container container = new Container();
            billOfLading.Containers.Add(container);
            ContainerDetails window = new ContainerDetails();
            window.Show();
            window.Init(container);
            HandleDataGrid();
        }

        private void GridJFlightConsignment_OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void UIElement_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text.Equals(Search))
            {
                txtSearch.Text = "";
                txtSearch.Foreground = Brushes.Black;
            }
        }

        private void TxtSearch_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = Search;
                txtSearch.Foreground = Brushes.Gainsboro;
            }
        }

        public void HandleDataGrid()
        {
            if (_billOfLadings.Count > 0)
            {
                gridJFlightConsignment.Visibility = Visibility.Visible;
            }
            else
            {
                gridJFlightConsignment.Visibility = Visibility.Hidden;
            }
        }

        

        public void Init(ObservableCollection<BillOfLading> items)
        {
            _billOfLadings = items;
            DataGridCollection = CollectionViewSource.GetDefaultView(_billOfLadings);
            DataGridCollection.Filter = new Predicate<object>(Filter);
            FilterString = Search;
            HandleDataGrid();
        }

        public bool Validate()
        {
            foreach (BillOfLading billOfLading in _billOfLadings)
            {
                if (Utils.Validator.Validate(billOfLading) == false)
                {
                    return false;
                }
                billOfLading.Finilize();
            }
            return true;
            
        }

        public void Add(BillOfLading billOfLading)
        {
            _billOfLadings.Add(billOfLading);
            ParameterUtility.GetVoyage().BillOfLadings.Add(billOfLading);
            UI.Template.Details window = new UI.Template.Details();
            window.Show();
            window.Init(billOfLading, _manager.GetBillOfLadingFilters());
            HandleDataGrid();
        }

    }
}
