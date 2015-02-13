using System;
using System.Collections.Generic;
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
using Manifest.Utils;

namespace Manifest.UserControl
{
    /// <summary>
    /// Interaction logic for uDetails.xaml
    /// </summary>
    public partial class uDetails : System.Windows.Controls.UserControl
    {
        private Object _instance;
        private DetailsManager _manager;

        public uDetails()
        {
            InitializeComponent();
        }

        public void Init(Object instance, Filters filter)
        {
            this._instance = instance;
            switch (filter)
            {
                case Filters.AllFields:
                    radioAll.IsChecked = true;
                    break;
                case Filters.RequiredFields:
                    radioRequired.IsChecked = true;
                    break;
                case Filters.EmptyRequiredFields:
                    radioEmptyRequired.IsChecked = true;
                    break;
            }
        }

        private void Radio_OnChecked(object sender, RoutedEventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            Filters filter = (Filters)Enum.Parse(typeof(Filters), radio.Content.ToString().Replace(" ", ""));
            pnlContainer.Children.RemoveAt(pnlContainer.Children.Count - 1);
            Panel panel = Utils.ControlCreator<Object>.GetInstance().CreateControl(_instance, filter);
            DetailsManager.GetInstance().SetFilter(_instance.GetType().Name, filter);
            pnlContainer.Children.Add(panel);
        }
    }
}
