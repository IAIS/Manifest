using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Manifest.Shared;
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
                    builder.Append(GetValue(propertyInfo, instance));
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

        /// <summary>
        /// با توجه به فرمت انتخاب شده امکان وجود خط جدید و ... در فایل نهایی وجود ندارد
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        private static string GetValue(PropertyInfo propertyInfo, Object instance)
        {
            string stringValue = "\"\",";
            if (propertyInfo.PropertyType == typeof(DateTime))
            {
                stringValue = "\"" + CommonUtility.ConvertDateTime((DateTime) propertyInfo.GetValue(instance, null)) + "\",";
            }
            else if (propertyInfo.PropertyType == typeof(double))
            {
                stringValue =  "\"" + ((double)propertyInfo.GetValue(instance, null)) + "\",";
            }
            else if (propertyInfo.PropertyType == typeof(int))
            {
                stringValue = "\"" + ((int)propertyInfo.GetValue(instance, null)) + "\",";
            }
            else if (propertyInfo.PropertyType == typeof (string))
            {
                stringValue = "\"" + (propertyInfo.GetValue(instance, null)) + "\",";
            }
            else
            {
                var temp = propertyInfo.GetValue(instance, null);
                if (temp != null)
                {
                    stringValue = "\"" + temp + "\",";
                }
            }
            return stringValue.Replace("\r", "").Replace("\n", "");
        }

        /// <summary>
        /// نتیجه را به صورت یک رشته باز می گرداند
        /// </summary>
        /// <returns></returns>
        public static String GetResult()
        {
            StringBuilder builder = new StringBuilder("");
            builder.AppendLine("\"VOY\"," + Printer.Print(ParameterUtility.GetVoyage()));

            ObservableCollection<BillOfLading> billOfLadings = ParameterUtility.GetBillOfLading();
            foreach (BillOfLading billOfLading in billOfLadings)
            {
                builder.AppendLine("\"BOL\"," + Printer.Print(billOfLading));
                foreach (Container container in billOfLading.Containers)
                {
                    builder.AppendLine("\"CTR\"," + Printer.Print(container));
                    foreach (Consignment consignment in container.Consignments)
                    {
                        builder.AppendLine("\"CON\"," + Printer.Print(consignment));
                    }
                }
            }
            return builder.ToString();
        }

    }
}
