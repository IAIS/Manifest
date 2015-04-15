using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using Manifest.Shared;
using Manifest.UI.Details;
using Manifest.Utils;
using Warehouse.Exceptions;
using Container = Manifest.Shared.Container;
using DataGridTextColumn = FirstFloor.ModernUI.Windows.Controls.DataGridTextColumn;

namespace Manifest.Utils
{
    class DataGridRowsManager
    {
        public static IEnumerable<DataGridRow> GetDataGridRows(System.Windows.Controls.DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }



    }
}
