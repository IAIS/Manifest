using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Manifest.Shared;
using Manifest.Utils;
using Warehouse.Exceptions;

namespace Manifest.UserControl
{
    /// <summary>
    /// Interaction logic for uConsignmentDetails.xaml
    /// </summary>
    public partial class uConsignmentDetails : Details, IDetails<Consignment>
    {
        private ObservableCollection<Consignment> _consignments;
        private readonly DetailsManager _manager;

        public uConsignmentDetails()
        {
            InitializeComponent();
            _manager = DetailsManager.GetInstance();
        }

        public void Init(ObservableCollection<Consignment> items)
        {
            _consignments = items;
            DataGridCollection = CollectionViewSource.GetDefaultView(items);
            DataGridCollection.Filter = new Predicate<object>(Filter);
            FilterString = Search;
            HandleDataGrid();
        }

        public void changeRowColor(Consignment consignment, Boolean complete)
        {
            var rows = DataGridRowsManager.GetDataGridRows(gridConsignment);

            foreach (DataGridRow row in rows)
            {
                Consignment temp = row.Item as Consignment;

                if (temp.SerialNumber.Equals("") || temp.SerialNumber.Equals(consignment.SerialNumber))
                {
                    if (!complete)
                        row.Background = Brushes.Tomato;
                    if (complete)
                        row.Background = Brushes.White;
                }
            }

        }

        public bool Validate()
        {

            foreach (Consignment consignment in _consignments)
            {
                try
                {
                    Utils.Validator.Validate(consignment);
                    changeRowColor(consignment, true);
                    consignment.Finilize();

                }
                catch (UserInterfaceException ex)
                {
                    changeRowColor(consignment, false);
                    throw;
                }

            }
            return true;
        }

        public void Add(Consignment item)
        {
            throw new NotImplementedException();
        }

        public void HandleDataGrid()
        {
            if (_consignments.Count == 0)
            {
                gridConsignment.Visibility = Visibility.Hidden;
            }
            else
            {
                gridConsignment.Visibility = Visibility.Visible;
            }
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

        private void GridJFlightConsignment_OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {
            Consignment consignment = ((FrameworkElement)sender).DataContext as Consignment;
            UI.Template.Details window = new UI.Template.Details();
            window.Show();
            window.Init(consignment, _manager.GetConsignmentFilter());
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            Consignment consignment = ((FrameworkElement)sender).DataContext as Consignment;
            ParameterUtility.RemoveConsignment(consignment);
            _consignments.Remove(consignment);
            HandleDataGrid();
        }
    }
}
