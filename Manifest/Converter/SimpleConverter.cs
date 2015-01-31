using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using Manifest.Annotations;

namespace Manifest.Converter
{
    /// <summary>
    /// خواندن از فایل هایی که ساختار آن ها در فایل
    /// <paramref name="StructurePath"/>
    /// ذخیره شده است
    /// </summary>
    /// <remarks>
    /// این کلاس برای نوع داده های اولیه مثل اعداد صحیح و رشته به طور کامل کار می کند
    /// در صورتی که کلاس مورد نظر داری فرزندانی باشد و بخواهیم به جای مقادیر کلاس مقادیر
    /// فرزندان را تغییر دهیم باید در سازنده ی کلاس پدر حتما شئ فرزند ایجاد شده باشد و 
    /// این که از نوع کلاس فرزند دقیقا یک فرزند وجود داشته باشد
    /// </remarks>
    public static class SimpleConverter
    {
        private const String StructurePath = "Structure/Templates.xml";
        private const String Delimiter = "-|-";

        public static List<T> Convert<T>(String path, String className)
        {
            String[][] values = SimpleConverter.FetchValues(path);
            PropertyInfo[][] properties = SimpleConverter.FetchFileInfo(className);
            List<T> instances = SimpleConverter.CrateInstances<T>(values, properties);
            return instances;
        }

        /// <summary>
        /// این تابع سعی می کند ساختاری
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static List<T> CrateInstances<T>(String[][] values, PropertyInfo[][] properties)
        {
            List<T> result = new List<T>(values.Length);
            foreach (String[] instance in values)
            {
                T item = (T)Activator.CreateInstance(typeof(T));
                for (int i = 0; i < instance.Length; i++)
                {
                    if (properties[i] == null) // Uknown
                    {
                        continue;
                    }
                    else
                    {
                        if (properties[i].Length == 1) // Simple Property
                        {
                            PropertyInfo propertyInfo = properties[i][0];
                            Type underlayingType = Nullable.GetUnderlyingType(propertyInfo.PropertyType);
                            if (underlayingType == null) // NonNullable Property
                            {
                                var refined = System.Convert.ChangeType(instance[i], propertyInfo.PropertyType);
                                propertyInfo.SetValue(item, refined);   
                            }
                            else    // Nullable Property
                            {
                                var refined = System.Convert.ChangeType(instance[i], underlayingType);
                                propertyInfo.SetValue(item, refined);
                            }
                        }
                        else if (properties[i].Length == 2)     // Navigation Property
                        {
                            PropertyInfo childInstanceType = properties[i][0];
                            PropertyInfo childPropertyType = properties[i][1];
                            var childInstance = childInstanceType.GetValue(item);
                            Type underlayingType = Nullable.GetUnderlyingType(childPropertyType.PropertyType);
                            if (underlayingType == null) // NonNullable Property
                            {
                                var refined = System.Convert.ChangeType(instance[i], childPropertyType.PropertyType);
                                childPropertyType.SetValue(childInstance, refined);
                            }
                            else    // Nullable Property
                            {
                                var refined = System.Convert.ChangeType(instance[i], underlayingType);
                                childPropertyType.SetValue(childInstance, refined);
                            }
                        }
                        else
                        {
                            throw new NotSupportedException("تعداد خاصیت Property باید یک یا دو باشد.");
                        }
                    }
                }
                result.Add(item);
            }
            return result;
        }

        /// <summary>
        /// مقادیر را از فایل دریافت می کند
        /// </summary>
        /// <param name="path">
        /// آدرس فایلی که مقادیر از آن خوانده می شود
        /// </param>
        /// <returns></returns>
        private static String[][] FetchValues(String path)
        {
            List<String[]> result = new List<String[]>();
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                String line = reader.ReadLine();
                line = line.Substring(0, line.Length - 3);
                String[] values = line.Split(new string[] { Delimiter }, StringSplitOptions.None);
                for (int i = 0; i < values.Length; i++)
                {
                    if (String.IsNullOrWhiteSpace(values[i]))
                    {
                        values[i] = null;
                    }
                }
                result.Add(values);
            }
            reader.Close();
            return result.ToArray();
        }

        /// <summary>
        /// ساختار کلاس را از فایل 
        /// xml
        /// دریافت می کند
        /// </summary>
        /// <param name="className"></param>
        /// <returns>
        /// </returns>
        private static PropertyInfo[][] FetchFileInfo(String className)
        {
            List<PropertyInfo[]> result = new List<PropertyInfo[]>();
            XmlReader xmlReader = XmlReader.Create(StructurePath);
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    if (xmlReader.LocalName.Equals("Files"))
                    {
                        xmlReader.Read();
                        while (xmlReader.ReadToNextSibling("File"))
                        {
                            if (xmlReader.LocalName.Equals("File"))
                            {
                                if (xmlReader["class"].Equals(className))
                                {
                                    Type classType = Type.GetType(xmlReader["class"]);
                                    //                        var person = Activator.CreateInstance(classType);
                                    //                        PropertyInfo[] properties = new PropertyInfo[xmlReader.ChildNodes];
                                    while (xmlReader.Read())
                                    {
                                        if (xmlReader.NodeType == XmlNodeType.Element)
                                        {
                                            if (xmlReader.LocalName.Equals("Property"))
                                            {
                                                String name = xmlReader["name"];
                                                if (name.Contains("."))
                                                {
                                                    String[] tokens = name.Split('.');
                                                    PropertyInfo instanceType = classType.GetProperty(tokens[0]);
                                                    PropertyInfo propertyType = instanceType.PropertyType.GetProperty(tokens[1]);
                                                    result.Add(new PropertyInfo[] {instanceType, propertyType});
                                                }
                                                else
                                                {
                                                    PropertyInfo propertyInfo = classType.GetProperty(name);
                                                    result.Add(new PropertyInfo[]{propertyInfo});
                                                }
                                            }
                                            // در صورتی که گره ی موجود در فایل کانفیگ نامشخص باشد آن را نادیده می گیرد
                                            else if (xmlReader.LocalName.Equals("Uknown"))  
                                            {
                                                result.Add(null);
                                            }
                                            else
                                            {
                                                xmlReader.Close();
                                                return result.ToArray();
                                            }
                                        }
                                    }
                                }
                            }
                            
                        }
                    }
                }
            }
            xmlReader.Close();
            if (result.Count == 0)
            {
                return null;
            }
            return result.ToArray();
        }
    }
}
