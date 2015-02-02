using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Manifest.Shared;
using Manifest.Template.Lootka;

namespace Manifest.Converter
{
    public static class XmlConverter
    {
        public static List<T> Convert<T>(String path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof (Data));
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            Data result = (Data)serializer.Deserialize(stream);
            Console.WriteLine(result);
            return null;
        }
    }
}
