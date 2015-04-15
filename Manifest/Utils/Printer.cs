using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Manifest.Template.Hoopad;

namespace Manifest.Utils
{
    public static class Printer
    {
        /// <summary>
        /// اطلاعات کلاس ورودی را به فرمتی بسیار شبیه 
        /// CSV
        /// باز می گرداند
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static String Print(Object instance)
        {
            StringBuilder builder = new StringBuilder();
            Type type = instance.GetType();
            PropertyInfo[] properties = (from prop in type.GetProperties()
                               let display = Attribute.GetCustomAttribute(prop, typeof(DisplayAttribute)) as DisplayAttribute
                               where display != null
                               let order = display.Order
                               orderby order ascending
                               select prop).ToArray();
            for(int i = 0; i < properties.Length; i++)
            {
                PropertyInfo propertyInfo = properties[i];
                if (CommonUtility.IsSimpleProperty(propertyInfo))
                {
                    if(propertyInfo.PropertyType == typeof(DateTime))
                    {
                        builder.Append("\"" + CommonUtility.ConvertDateTime((DateTime)propertyInfo.GetValue(instance, null)) + "\",");    
                    }
                    else
                    {
                        builder.Append("\"" + propertyInfo.GetValue(instance, null) + "\",");    
                    }
                }
            }
            if (builder.ToString().Length >= 1)
            {
                // برای  پاک کردن یک ویرگول اضافی که در حلقه ی بالا اضافه شده است
                return builder.ToString().Substring(0, builder.Length - 1);
            }
            else
            {
                return builder.ToString();
            }
            
        }
    }
}
