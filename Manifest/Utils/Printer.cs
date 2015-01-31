using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                if (CommonUtility.IsSimpleProperty(propertyInfo))
                {
                    builder.Append("\"" + propertyInfo.GetValue(instance) + "\",");    
                }
            }
            // برای  پاک کردن یک ویرگول اضافی که در حلقه ی بالا اضافه شده است
            return builder.ToString().Substring(0, builder.Length - 1);
        }
    }
}
