using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Manifest.Template.Hoopad;
using Warehouse.Exceptions;

namespace Manifest.Converter
{
    public class ClassConverter
    {
        private static ClassConverter _instance;
        private const String StructurePath = "Structure/Map.xml";
        private ClassConverter()
        {

        }

        public static ClassConverter GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ClassConverter();
            }
            return _instance;
        }

        public static void Convert(Object sourceInstance, Object destinationInstance)
        {
            PropertyInfo[][] properties = FetchProperties(sourceInstance.GetType().FullName, destinationInstance.GetType().FullName);
            foreach (PropertyInfo[] propertyInfo in properties)
            {
                var value = propertyInfo[0].GetValue(sourceInstance, null);
                if (propertyInfo[0].PropertyType.FullName.Equals("System.String"))
                {
                    value = ((String) value).Replace("\r", " ").Replace("\n", " ").Trim();
                }
                var convertedValue = System.Convert.ChangeType(value, propertyInfo[1].PropertyType);
                propertyInfo[1].SetValue(destinationInstance, convertedValue, null);
            }
        }

        /// <summary>
        /// آرایه ی دوبعدی از خاصیت ها بر می گرداند هر سطر آن نگاشت بین دو پارامتر را نشان می دهد
        /// ستون اول خاصیت در مبدا و ستون دوم آن خاصیت در مقصد است
        /// </summary>
        /// <param name="sourceClassName"></param>
        /// <param name="destinationClassName"></param>
        /// <returns></returns>
        private static PropertyInfo[][] FetchProperties(String sourceClassName, String destinationClassName)
        {
            Map map =
                XmlConverter.Convert<maps>(StructurePath)
                    .Items.FirstOrDefault(m => m.sourceClass.Equals(sourceClassName) && m.destinationClass.Equals(destinationClassName));
            List<PropertyInfo[]> result = new List<PropertyInfo[]>();
            Type sourceType = Type.GetType(sourceClassName);
            Type destinationType = Type.GetType(destinationClassName);
            foreach (Property mapProperty in map.property)
            {
                PropertyInfo sourceProperty = sourceType.GetProperty(mapProperty.src);
                if (sourceProperty == null)
                {
                    throw new UserInterfaceException("خطا در خواندن قایل نگاشت رخ داده است. لطفا با پشتیبانی تماس بگیرید.");
                }
                PropertyInfo destinationProperty = destinationType.GetProperty(mapProperty.dest);
                if (destinationProperty == null)
                {
                    throw new UserInterfaceException("خطا در خواندن قایل نگاشت رخ داده است. لطفا با پشتیبانی تماس بگیرید.");
                }
                result.Add(new PropertyInfo[] { sourceProperty, destinationProperty });
            }
            return result.ToArray();
        }
    }
}
