using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using Manifest.Shared;

namespace Manifest.Utils
{
    /// <summary>
    /// User Control Which Will Handle Filter Result With Search TextBox
    /// </summary>
    public class Details: System.Windows.Controls.UserControl, INotifyPropertyChanged
    {
        protected const string Search = "Search...";
        private string _filterString;
        protected ICollectionView _dataGridCollection;
        public event PropertyChangedEventHandler PropertyChanged;

        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; NotifyPropertyChanged("DataGridCollection"); }
        }

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                NotifyPropertyChanged("FilterString");
                FilterCollection();
            }
        }

        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }

        protected bool Filter(object data)
        {
            if (data != null)
            {
                if (!String.IsNullOrEmpty(_filterString))
                {
                    if (!_filterString.Equals(Search))
                    {
                        foreach (PropertyInfo propertyInfo in Utils.CommonUtility.GetProperties(data, Filters.AllFields))
                        {
                            var value = propertyInfo.GetValue(data, null);
                            if (value != null)
                            {
                                if (value.ToString().Contains(_filterString))
                                {
                                    return true;
                                }
                            }
                        }
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
