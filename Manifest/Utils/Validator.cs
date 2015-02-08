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
                    var value = propertyInfo.GetValue(instance, null);
                    if (value == null || String.IsNullOrEmpty(value.ToString()))
                    {
                        builder.AppendLine(String.Format(ExceptionMessage.ValidationBlank, propertyInfo.Name));
                    }
                }
            }
            if (builder.Length > 0)
            {
                const string message = @"اطلاعات {0} ناقص می باشد، لطفا اطلاعات را با استفاده از ستون ویرایش تکمیل کرده و دوباره امتحان کنید.";
                throw new UserInterfaceException(20001, String.Format(message, instance) + System.Environment.NewLine + System.Environment.NewLine + builder.ToString());
            }
            PropertyInfo[] properties = instance.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                if (typeof (String) != propertyInfo.PropertyType)
                {
                    continue;
                }
                if (!HasMaxLength(propertyInfo))
                {
                    continue;    
                }
                var value = propertyInfo.GetValue(instance, null);
                if (value == null)
                {
                    continue;
                }
                int maxLength = GetMaxLength(propertyInfo);
                String convertedValue = (String) System.Convert.ChangeType(value, propertyInfo.PropertyType);
                if (convertedValue.Length > maxLength)
                {
                    builder.AppendLine(String.Format(ExceptionMessage.ValidationMaxLength, propertyInfo.Name));
                }
            }
            if (builder.Length > 0)
            {
                const string message = @"اطلاعات {0} غیرمجاز می باشد، لطفا اطلاعات را با استفاده از ستون ویرایش تصحیح کرده و دوباره امتحان کنید.";
                throw new UserInterfaceException(20003, String.Format(message, instance) + System.Environment.NewLine + System.Environment.NewLine + builder.ToString());
            }
            return true;
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

        private static bool HasMaxLength(PropertyInfo propertyInfo)
        {
            return false;
//            var attr = propertyInfo.GetCustomAttributes(typeof(MaxLengthAttribute), false).FirstOrDefault();
//            if (attr == null)
//            {
//                return false;
//            }
//            return true;
        }

        private static int GetMaxLength(PropertyInfo propertyInfo)
        {
            throw new NotImplementedException();
//            MaxLengthAttribute attr = (MaxLengthAttribute)propertyInfo.GetCustomAttributes(typeof(MaxLengthAttribute), false).FirstOrDefault();
//            return attr.Length;
        }

    }
}
