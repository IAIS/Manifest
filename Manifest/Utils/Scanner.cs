using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Manifest.Utils
{
    public class Scanner
    {
        public static T Scan<T>(List<String> input) where T : new()
        {
            input.RemoveAt(0);

            T instance = new T();
            Type type = instance.GetType();
            PropertyInfo[] properties = (from prop in type.GetProperties()
                                         let display = Attribute.GetCustomAttribute(prop, typeof(DisplayAttribute)) as DisplayAttribute
                                         where display != null
                                         let order = display.Order
                                         orderby order ascending
                                         select prop).ToArray();
            for (int i = 0; i < properties.Length; i++)
            {
                try
                {
                    //PropertyInfo propertyInfo = properties[i];
                    if (CommonUtility.IsSimpleProperty(properties[i]))
                    {

                        TypeConverter typeConverter = TypeDescriptor.GetConverter(properties[i].PropertyType);

                        if ((properties[i].PropertyType == typeof (Int32) ||
                             properties[i].PropertyType == typeof (Double)) && input[i].Equals(""))
                        {
                            input[i] = "0";                                 
                        }

                        object propValue = typeConverter.ConvertFromString(input[i]);
                        properties[i].SetValue(instance, propValue, null);

                    }
                }
                catch (Exception)
                {
                    //TODO: DO log   
                }
                
            }
            return instance;
        }
    }
}