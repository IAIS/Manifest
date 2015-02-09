using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Manifest.Shared;

namespace Manifest.Converter
{
    public static class XmlConverter
    {
        public static T Convert<T>(String path)
        {
            // if line below throw exception just turn off stop on exception or use continue while debugging
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            T result = (T)serializer.Deserialize(stream);
            return result;
        }
    }
}
