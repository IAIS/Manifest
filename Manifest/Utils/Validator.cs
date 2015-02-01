using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Manifest.Resources;
using Warehouse.Exceptions;

namespace Manifest.Utils
{
    public static class Validator
    {
        public static bool Validate(Object instance)
        {
            StringBuilder builder = new StringBuilder();
            PropertyInfo[] requiredPropery = GetRequiredAttributes(instance.GetType());
            foreach (PropertyInfo propertyInfo in requiredPropery)
            {
                if (CommonUtility.IsSimpleProperty(propertyInfo))
                {
                    var value = propertyInfo.GetValue(instance);
                    if (value == null || String.IsNullOrEmpty(value.ToString()))
                    {
                        builder.AppendLine(String.Format(ExceptionMessage.Validation, propertyInfo.Name));
                    }
                }
            }
            if (builder.Length == 0)
            {
                return true;
            }
            else
            {
                const string message = @"اطلاعات وارد شده ناقص می باشد، لطفا اطلاعات را با استفاده از ستون ویرایش تکمیل کرده و دوباره امتحان کنید.";
                throw new UserInterfaceException(20001, message + System.Environment.NewLine + System.Environment.NewLine + builder.ToString());
            }
        }

        private static PropertyInfo[] GetRequiredAttributes(Type type)
        {
            List<PropertyInfo> result = new List<PropertyInfo>();
            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                if (CommonUtility.IsSimpleProperty(propertyInfo))
                {
                    if (CommonUtility.IsRequired(propertyInfo))
                    {
                        result.Add(propertyInfo);
                    }
                }
            }
            return result.ToArray();
        }
    }
}
