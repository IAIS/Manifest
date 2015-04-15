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
using Manifest.UI.Details;
using Manifest.Utils;
using Warehouse.Exceptions;

namespace Manifest.UserControl
{
    /// <summary>
    /// Interaction logic for uContainerDetails.xaml
    /// </summary>
    public partial class uContainerDetails : Details, IDetails<Container>
    {
        private ObservableCollection<Container> _containers; 
        public uContainerDetails()
        {
            InitializeComponent();
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

        private void GridContainer_OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
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

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            Container container = ((FrameworkElement)sender).DataContext as Container;
            Consignment consignment = new Consignment();
            container.Consignments.Add(consignment);
            UI.Template.Details window = new UI.Template.Details();
            window.Show();
            window.Init(consignment, DetailsManager.GetInstance().GetConsignmentFilter());
        }

        public void Init(ObservableCollection<Container> items)
        {
            _containers = items;
            DataGridCollection = CollectionViewSource.GetDefaultView(items);
            DataGridCollection.Filter = new Predicate<object>(Filter);
            FilterString = Search;
            HandleDataGrid();
        }

        public void changeRowColor(Container container, Boolean complete)
        {
            var rows = DataGridRowsManager.GetDataGridRows(gridContainer);

            foreach (DataGridRow row in rows)
            {
                Container temp = row.Item as Container;

                if (temp.ContainerNumber.Equals("") || temp.ContainerNumber.Equals(container.ContainerNumber))
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

            foreach (Container container in _containers)
            {
                try
                {
                    Utils.Validator.Validate(container);
                    changeRowColor(container, true);
                    container.Finalize();

                }
                catch (UserInterfaceException ex)
                {
                    changeRowColor(container, false);
                    throw;
                }

            }
            return true;
        }


        public void Add(Container item)
        {
            throw new NotImplementedException();
        }

        public void HandleDataGrid()
        {
            if (_containers.Count == 0)
            {
                this.gridContainer.Visibility = Visibility.Hidden;
            }
            if (_containers.Count > 0)
            {
                this.gridContainer.Visibility = Visibility.Visible;
            }
            foreach (Container container in _containers)
            {
                container.Finalize();
            }
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
    }
}
