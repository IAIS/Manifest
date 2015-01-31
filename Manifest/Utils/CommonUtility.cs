using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using Manifest.Shared;

namespace Manifest.Utils
{
    public static class CommonUtility
    {
        /// <summary>
        /// مشخص می کند که آیا خاصیت داده شده ساده است یا نه
        /// </summary>
        /// <remarks>
        /// منظور از خاصیت ساده خاصیت هایی غیر مجموعه (مثل لیست) است
        /// </remarks>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public static bool IsSimpleProperty(PropertyInfo propertyInfo)
        {
            if (typeof(String) != propertyInfo.PropertyType &&
                    typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType))
            {
                return false;
            }
            return true;
        }
    }
}
