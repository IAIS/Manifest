using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ionic.Zip;
using Microsoft.Win32;

namespace Manifest.Utils
{
    public static class ArchiveHelper
    {
        public static void Compress(string fileName)
        {
            string path = Path.GetDirectoryName(fileName);
            if (path != null)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            using (ZipFile zip = new ZipFile())
            {
                String entryName = "Manifest_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                zip.AddEntry(entryName, Printer.GetResult(), System.Text.Encoding.ASCII);
                zip.Save(fileName);
            }
        }
    }
}
