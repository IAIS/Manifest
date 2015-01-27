using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Manifest.Shared;

namespace Manifest.UserControl
{
    /// <summary>
    /// Interaction logic for uBillOfLading.xaml
    /// </summary>
    public partial class uBillOfLading : System.Windows.Controls.UserControl
    {
        private BillOfLading BillOfLading { get; set; }

        public uBillOfLading()
        {
            BillOfLading = new BillOfLading();
            InitializeComponent();
        }

        public void Init(BillOfLading billOfLading)
        {
            pnlContainer.Children.Clear();
            this.BillOfLading = billOfLading;
            CreateControls();
        }

        private void CreateControls()
        {
            foreach (PropertyInfo propertyInfo in BillOfLading.GetType().GetProperties())
            {
                TextBlock label = new TextBlock();
                label.Text = propertyInfo.Name;
                label.Margin = new Thickness(5);
                pnlContainer.Children.Add(label);
//                Binding binding = new Binding();
//                binding.Source = label; // set the source object instead of ElementName
//                binding.Path = new PropertyPath(TextBox.TextProperty);
//                BindingOperations.SetBinding(label, TextBlock.text TextBox.VisibilityProperty, binding);


                TextBox text = new TextBox();
                Object value = propertyInfo.GetValue(BillOfLading);
                if(value != null)
                {
                    text.Text = value.ToString();    
                }
                text.Margin = new Thickness(5);
                pnlContainer.Children.Add(text);
            }
            
        }
    }
}

