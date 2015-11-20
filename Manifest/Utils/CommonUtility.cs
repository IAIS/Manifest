using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Manifest.Utils
{
    public static class CommonUtility
    {
        static private readonly string[] HexArray = {
        "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D", "0E", "0F",
        "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "1A", "1B", "1C", "1D", "1E", "1F",
        "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "2A", "2B", "2C", "2D", "2E", "2F",
        "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "3A", "3B", "3C", "3D", "3E", "3F",
        "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "4A", "4B", "4C", "4D", "4E", "4F",
        "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "5A", "5B", "5C", "5D", "5E", "5F",
        "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "6A", "6B", "6C", "6D", "6E", "6F",
        "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "7A", "7B", "7C", "7D", "7E", "7F",
        "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "8A", "8B", "8C", "8D", "8E", "8F",
        "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "9A", "9B", "9C", "9D", "9E", "9F",
        "A0", "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "AA", "AB", "AC", "AD", "AE", "AF",
        "B0", "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "BA", "BB", "BC", "BD", "BE", "BF",
        "C0", "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "CA", "CB", "CC", "CD", "CE", "CF",
        "D0", "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "DA", "DB", "DC", "DD", "DE", "DF",
        "E0", "E1", "E2", "E3", "E4", "E5", "E6", "E7", "E8", "E9", "EA", "EB", "EC", "ED", "EE", "EF",
        "F0", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "FA", "FB", "FC", "FD", "FE", "FF"};

        private static readonly Char[] PersianNumber = new Char[] { '۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹' };
        private static readonly Char[] EnglishNumber = new Char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        /// <summary>
        /// مشخص می کند که آیا خاصیت داده شده ساده است یا نه
        /// </summary>
        /// <remarks>
        /// منظور از خاصیت ساده خاصیت هایی غیر مجموعه (مثل لیست) است
        /// </remarks>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public static bool IsSimpleProperty(PropertyInfo propertyInfo)
        {
            if (typeof(String) != propertyInfo.PropertyType &&
                    typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// آیا خاصیت اجباری است یا خیر
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public static bool IsRequired(PropertyInfo propertyInfo)
        {
            return System.Attribute.GetCustomAttributes(propertyInfo, false)
                .Any(t => t is RequiredAttribute);  
        }

        public static String StringToHexString(String s, Encoding encoding)
        {
            byte[] bytes = encoding.GetBytes(s);
            var sb = new StringBuilder();
            for (int j = 0; j < bytes.Length; j++)
            {
                sb.Append((HexArray[bytes[j] & 0xFF]));
            }
            return sb.ToString();
        }

        public static String HexStringToString(String s, Encoding encoding)
        {
            int discard;
            var d = HexEncoding.GetBytes(s, out discard);
            string res = encoding.GetString(d);
            return res;
        }

        public static PropertyInfo[] GetProperties(Object instance, Filters filter)
        {
            Type type = instance.GetType();

            switch (filter)
            {
                case Filters.AllFields:
                    {
                        PropertyInfo[] properties = type.GetProperties();
                        List<PropertyInfo> result = new List<PropertyInfo>();
                        foreach (PropertyInfo property in properties)
                        {
                            if (Utils.CommonUtility.IsSimpleProperty(property))
                            {
                                result.Add(property);
                            }
                        }
                        return result.ToArray();
                    }
                case Filters.RequiredFields:
                    {
                        PropertyInfo[] properties = type.GetProperties();
                        List<PropertyInfo> result = new List<PropertyInfo>();
                        foreach (PropertyInfo property in properties)
                        {
                            if (Utils.CommonUtility.IsSimpleProperty(property))
                            {
                                if (Utils.CommonUtility.IsRequired(property))
                                {
                                    result.Add(property);
                                }
                            }
                        }
                        return result.ToArray();
                    }
                case Filters.EmptyRequiredFields:
                    {
                        PropertyInfo[] properties = type.GetProperties();
                        List<PropertyInfo> result = new List<PropertyInfo>();
                        foreach (PropertyInfo property in properties)
                        {
                            if (Utils.CommonUtility.IsSimpleProperty(property))
                            {
                                if (Utils.CommonUtility.IsRequired(property))
                                {
                                    var value = property.GetValue(instance, null);
                                    if (value == null || String.IsNullOrEmpty(value.ToString()))
                                    {
                                        result.Add(property);
                                    }
                                }
                            }
                        }
                        return result.ToArray();
                    }
            }
            return null;
        }

        public static bool IsEmpty(String value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return true;
            }
            if (value.Trim().Equals("0"))
            {
                return true;
            }
            // TODO: Uncomment Code Below In Proper Time
//            if (value.Trim().Equals("-"))
//            {
//                return true;
//            }
            return false;
        }

        public static bool HasMaxLength(PropertyInfo propertyInfo)
        {
            var attr = propertyInfo.GetCustomAttributes(typeof(MyStringLengthAttribute), false).FirstOrDefault();
            if (attr == null)
            {
                return false;
            }
            return true;
        }

        public static int GetMaxLength(PropertyInfo propertyInfo)
        {
            MyStringLengthAttribute attr = (MyStringLengthAttribute)propertyInfo.GetCustomAttributes(typeof(MyStringLengthAttribute), false).FirstOrDefault();
            return attr.MaximumLength;
        }


        /// <summary>
        /// Return <paramref name="dateTime"/> in DD-MMM-CCYY Format.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ConvertDateTime(String dateTime)
        {
            if (dateTime == null)
            {
                return null;
            }
            if (dateTime.Length == 11) // به فرمت مناسب نشان داده شده است
            {
                return dateTime;
            }
            else if (dateTime.Length == 8) // به فرمت هوپاد است
            {
                string year = dateTime.Substring(0, 4);
                string month = dateTime.Substring(4, 2);
                string day = dateTime.Substring(6, 2);
                DateTime res = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));
                return res.ToString("dd-MMM-yyyy");
            }
            return "-";
        }

        public static string ConvertDateTime(DateTime dateTime)
        {
            return dateTime.ToString("dd-MMM-yyyy");
        }

        public static String GetPublishedVersion()
        {
            try
            {
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.
                        CurrentVersion.ToString();
                }
            }
            catch (Exception)
            {
                // Debuge Mode
            }

            return "0";
        }

        /// <summary>
        /// تاریخ هجری به فرمت 
        /// YYYY/MM/DD
        /// را به تاریخ میلادی تبدیل می کند
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime DateConverterHijriToMiladi(String date)
        {
            PersianCalendar calendar = new PersianCalendar();

            char[] chr = { '/' };

            int year = ConvetToInt(date.Split(chr)[0]);
            if (year < 1300)
                year += 1300;
            int month =ConvetToInt(date.Split(chr)[1]);
            int day = ConvetToInt(date.Split(chr)[2].Split(' ')[0]);

            int hour;
            int minute;
            int sec;
            if (date.Contains(" "))
            {
                string time = date.Split(' ')[1];
                hour = ConvetToInt(time.Split(':')[0]);
                minute = ConvetToInt(time.Split(':')[1]);
                sec = ConvetToInt(time.Split(':')[2]);
            }
            else
            {
                hour = minute = sec = 0;
            }
            return calendar.ToDateTime(year, month, day, hour, minute, sec, 0);
        }

        public static Int32 ConvetToInt(String input)
        {
            String text = CorrectNumber(input);
            Int32 res;
            if (Int32.TryParse(text, out res))
            {
                return res;
            }
            return -1;

        }


        /// <summary>
        /// اعداد فارسی رو به انگلیسی تبدیل می کند که در به نوع داده عددی قابل تبدیل باشند
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static String CorrectNumber(String input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                return null;
            }
            for (int i = 0; i < PersianNumber.Length; i++)
            {
                input = input.Replace(PersianNumber[i], EnglishNumber[i]);
            }
            return input;
        }

    }
}
