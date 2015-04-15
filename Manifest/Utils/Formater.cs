using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manifest.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class Formater
    {
        /// <summary>
        /// نام خاصیت را اصلاح کرده و باز می گرداند
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static String GetTitle(String name)
        {
            String nameformated = "";
            nameformated += name[0];

            for (int i = 1; i < name.Length; i++)
            {
                if (Char.IsUpper(name[i]) && !char.IsUpper(name[i - 1]))
                {
                    nameformated += " ";
                    nameformated += name[i];
                }
                else
                    nameformated += name[i];
            }
            return nameformated;

        }
    }
}

