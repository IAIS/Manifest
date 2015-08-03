using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Manifest.Converter
{
    public static class TxtConverter
    {
        public static StreamReader Convert(String path)
        {
            StreamReader stream = new StreamReader(path);
            return stream;
        }
    }
}