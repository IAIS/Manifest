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
            UI.Details.ContainerDetails window = new UI.Details.ContainerDetails();
            window.Show();
            window.Init(container);
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            Container container = ((FrameworkElement)sender).DataContext as Container;
            _containers.Remove(container);
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

        public void Init(ObservableCollection<Container> items)
        {
            _containers = items;
            DataGridCollection = CollectionViewSource.GetDefaultView(items);
            DataGridCollection.Filter = new Predicate<object>(Filter);
            FilterString = Search;
            HandleDataGrid();
        }

        public bool Validate()
        {
            foreach (Container container in _containers)
            {
                if (Utils.Validator.Validate(container) == false)
                {
                    return false;
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
            throw new NotImplementedException();
        }
    }
}
