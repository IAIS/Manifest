using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Manifest.Resources;
using System.ComponentModel;
using System.Linq;
//using System.Net.NetworkInformation;
//using System.Windows.Automation.Peers;




namespace Manifest.Utils
{
    public class ControlCreator<T>
    {
        private static ControlCreator<T> _instance = null;

        string[] comboPropertyInfo = new string[12];
        
        private ControlCreator()
        {
            comboPropertyInfo[0] = "TradeCode";
            comboPropertyInfo[1] = "TransShipmentMode";
            comboPropertyInfo[2] = "CargoCode";
            comboPropertyInfo[3] = "ConsolidatedCargoIndicator";
            comboPropertyInfo[4] = "StorageRequestCode";
            comboPropertyInfo[5] = "SlacIndicator";

            /****** Consignmenet.cs *******/
            comboPropertyInfo[6] = "UsedOrNewIndicator";
            comboPropertyInfo[7] = "DangerousGoodIndicator";
            comboPropertyInfo[8] = "UnitOfTemperature";
            comboPropertyInfo[9] = "StorageRequestedForDangerousGoods";
            comboPropertyInfo[10] = "RefrigerationRequired";
            comboPropertyInfo[11] = "UnitOfRefregerationTemperature";
        }

        public static ControlCreator<T> GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ControlCreator<T>();
            }
            return _instance;
        }

        /// <summary>
        /// به ازای هر ویژگی در 
        /// <paramref name="instance"/>
        /// یک سطر ایجاد می کند که خانه ی اول آن نام ویژگی
        /// و خانه ی دوم آن مقدارش در یک 
        /// <see cref="TextBox"/>
        /// است و آن را به 
        /// <paramref name="panel"/>
        /// اضافه می کند و باز می گرداند
        /// </summary>
        /// <param name="instance"></param>
        public Panel CreateControl(T instance, Filters filter)
        {
            Grid grid = new Grid();    
            grid.HorizontalAlignment = HorizontalAlignment.Left;
            grid.FlowDirection = FlowDirection.LeftToRight;

            ColumnDefinition column1 = new ColumnDefinition();
            column1.Width = new GridLength(250);
            grid.ColumnDefinitions.Add(column1);

            ColumnDefinition column2 = new ColumnDefinition();
            column2.Width = new GridLength(150);
            grid.ColumnDefinitions.Add(column2);

            ColumnDefinition column3 = new ColumnDefinition();
            column3.Width = new GridLength(150);
            grid.ColumnDefinitions.Add(column3);

            int rowIndex = 0;
            PropertyInfo[] properties = CommonUtility.GetProperties(instance, filter);
            foreach (PropertyInfo propertyInfo in properties)
            {
                RowDefinition row = new RowDefinition();
                row.MinHeight = 30;
                grid.RowDefinitions.Add(row);

                TextBlock label = new TextBlock();
                label.Text = Formater.GetTitle(propertyInfo.Name);
                label.Margin = new Thickness(5);
                Grid.SetColumn(label, 0);
                Grid.SetRow(label, rowIndex);
                grid.Children.Add(label);

                if (comboPropertyInfo.Contains(propertyInfo.Name))
                {
                    ArrayList comboList = new ArrayList();
                    comboList = ComboBoxesValues.comboListCreator(propertyInfo.Name);
                    ComboBox comboPicker = new ComboBox();
                    comboPicker.ItemsSource = comboList;

                    //Dictionary<string, string> comboDictionary = new Dictionary<string, string>();
                    //comboDictionary.Add("t", "test");
                    //comboDictionary.Add("r", "rest");

                    comboPicker.Name = propertyInfo.Name;
                    comboPicker.Margin = new Thickness(5);
                    Binding valueBinder = new Binding(propertyInfo.Name);
                    valueBinder.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    valueBinder.Source = instance;
                    valueBinder.NotifyOnValidationError = true;
                    valueBinder.ValidatesOnExceptions = true;
                    valueBinder.ValidatesOnDataErrors = true;
                    valueBinder.Mode = BindingMode.TwoWay;
                    BindingOperations.SetBinding(comboPicker, ComboBox.TextProperty, valueBinder);
                    Grid.SetColumn(comboPicker, 1);
                    Grid.SetRow(comboPicker, rowIndex);
                    grid.Children.Add(comboPicker);
                }
                else if (propertyInfo.PropertyType == typeof(DateTime))
                {
                    DatePicker datePicker = new DatePicker();
                    datePicker.Name = propertyInfo.Name;
                    datePicker.Margin = new Thickness(5);
                    Binding valueBinder = new Binding(propertyInfo.Name);
                    valueBinder.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    valueBinder.Source = instance;
                    valueBinder.NotifyOnValidationError = true;
                    valueBinder.ValidatesOnExceptions = true;
                    valueBinder.ValidatesOnDataErrors = true;
                    valueBinder.Mode = BindingMode.TwoWay;
                    BindingOperations.SetBinding(datePicker, DatePicker.TextProperty, valueBinder);
                    Grid.SetColumn(datePicker, 1);
                    Grid.SetRow(datePicker, rowIndex);
                    grid.Children.Add(datePicker);
                }
                else
                {
                    TextBox text = new TextBox();
                    text.Name = propertyInfo.Name;
                    text.Margin = new Thickness(5);
                    text.TextWrapping = TextWrapping.WrapWithOverflow;
                    Binding valueBinder = new Binding(propertyInfo.Name);
                    valueBinder.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    valueBinder.Source = instance;
                    valueBinder.NotifyOnValidationError = true;
                    valueBinder.ValidatesOnExceptions = true;
                    valueBinder.ValidatesOnDataErrors = true;
                    valueBinder.Mode = BindingMode.TwoWay;
                    BindingOperations.SetBinding(text, TextBox.TextProperty, valueBinder);
                    Grid.SetColumn(text, 1);
                    Grid.SetRow(text, rowIndex);
                    grid.Children.Add(text);
                }



                if (CommonUtility.IsRequired(propertyInfo))
                {
                    TextBlock lblStar = new TextBlock();
                    lblStar.Foreground = System.Windows.Media.Brushes.Red;
                    lblStar.Text = "*";
                    Grid.SetColumn(lblStar, 2);
                    Grid.SetRow(lblStar, rowIndex);
                    grid.Children.Add(lblStar);
                }

                rowIndex ++;
            }
            return grid;
        }

        


        private void TextOnLostFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            //            (Button) sender)
            //            throw new UserInterfaceException(123, "asf");
        }
    }
}
