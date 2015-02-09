﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Manifest.Shared;

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

        public static String GetPublishedVersion()
        {
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.
                    CurrentVersion.ToString();
            }
            return "0";
        }
    }
}
