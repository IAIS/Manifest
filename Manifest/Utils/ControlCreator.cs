using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Manifest.Utils
{
    public class ControlCreator<T>
    {
        private static ControlCreator<T> _instance = null;

        private ControlCreator()
        {

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
        public Panel CreateControl(T instance)
        {
            Grid grid = new Grid();    
            grid.HorizontalAlignment = HorizontalAlignment.Left;
            grid.FlowDirection = FlowDirection.LeftToRight;

            for (int i = 0; i < 3; i ++)
            {
                ColumnDefinition column = new ColumnDefinition();
                column.Width = new GridLength(200);
                grid.ColumnDefinitions.Add(column);
            }
            
            int rowIndex = 0;

            foreach (PropertyInfo propertyInfo in instance.GetType().GetProperties())
            {
                if (!CommonUtility.IsSimpleProperty(propertyInfo))
                {
                    continue;
                }
                RowDefinition row = new RowDefinition();
                row.MinHeight = 30;
                grid.RowDefinitions.Add(row);

                TextBlock label = new TextBlock();
                label.Text = propertyInfo.Name;
                label.Margin = new Thickness(5);
                Grid.SetColumn(label, 0);
                Grid.SetRow(label, rowIndex);
                grid.Children.Add(label);

                if (propertyInfo.PropertyType == typeof(DateTime))
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
