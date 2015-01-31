using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using Manifest.Shared;

namespace Manifest.Utils
{
    public static class ControlCreator <T>
    {
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
        public static Panel CreateControl(T instance)
        {
            UniformGrid panel = new UniformGrid();
            panel.HorizontalAlignment = HorizontalAlignment.Left;
            panel.FlowDirection = FlowDirection.LeftToRight;
            panel.Columns = 2;
            foreach (PropertyInfo propertyInfo in instance.GetType().GetProperties())
            {
                if (!CommonUtility.IsSimpleProperty(propertyInfo))
                {
                    continue;
                }
                TextBlock label = new TextBlock();
                label.Text = propertyInfo.Name;
                label.Margin = new Thickness(5);
                panel.Children.Add(label);

                TextBox text = new TextBox();
                //                Object value = propertyInfo.GetValue(BillOfLading);
                //                if(value != null)
                //                {
                //                    text.Text = value.ToString();    
                //                }
                text.Margin = new Thickness(5);
                Binding valueBinder = new Binding(propertyInfo.Name);
                valueBinder.Source = instance;
                valueBinder.NotifyOnValidationError = true;
                valueBinder.ValidatesOnExceptions = true;
                valueBinder.ValidatesOnDataErrors = true;
                valueBinder.Mode = BindingMode.TwoWay;
//                RequiredAttribute attribute =
//                    propertyInfo.GetCustomAttributes(typeof (RequiredAttribute), false)
//                        .Cast<RequiredAttribute>()
//                        .Single();
//                attribute.
//                valueBinder.ValidationRules.Add(new V);
                BindingOperations.SetBinding(text, TextBox.TextProperty, valueBinder);
                panel.Children.Add(text);

                
                TextBlock validator = new TextBlock();
                Binding validatorBinding = new Binding("(Validation.Errors)[0].ErrorContent");
                validatorBinding.ElementName = propertyInfo.Name;
                BindingOperations.SetBinding(validator, TextBlock.TextProperty, validatorBinding);

            }

            return panel;
        }
    }
}
