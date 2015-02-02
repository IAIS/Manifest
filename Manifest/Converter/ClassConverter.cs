using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            PropertyInfo[][] properties = FetchProperties(sourceInstance.GetType().FullName,
                destinationInstance.GetType().FullName);
            foreach (PropertyInfo[] propertyInfo in properties)
            {
                propertyInfo[1].SetValue(propertyInfo[0].GetValue(sourceInstance), destinationInstance);
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
            mapsMap map =
                XmlConverter.Convert<maps>(StructurePath)
                    .FirstOrDefault()
                    .Items.FirstOrDefault(m => m.sourceClass.Equals(sourceClassName) && m.destinationClass.Equals(destinationClassName));
            List<PropertyInfo[]> result = new List<PropertyInfo[]>();
            Type sourceType = Type.GetType(sourceClassName);
            Type destinationType = Type.GetType(destinationClassName);
            foreach (mapsMapProperty mapProperty in map.property)
            {
                result.Add(new PropertyInfo[] { sourceType.GetProperty(mapProperty.src), destinationType.GetProperty(mapProperty.src) });
            }
            return result.ToArray();
        }
    }
}
