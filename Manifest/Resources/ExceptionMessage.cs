using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manifest.Resources
{
    public static class ExceptionMessage
    {
        // 10001
        public const String BillOfLadingOpenError = 
            "هنگام باز کردن فایل بارنامه خطا رخ داده است، لطفا فایل مورد نظر را بررسی کرده و دوباره امتحان کنید";

        // 10101
        public const String ContainerOpenError =
            "هنگام باز کردن فایل کانتینر خطا رخ داده است، لطفا فایل مورد نظر را بررسی کرده و دوباره امتحان کنید";

        // 10201
        public const String RelationOpen =
            "هنگام باز کردن فایل ارتباطات خطا رخ داده است، لطفا فایل مورد نظر را بررسی کرده و دوباره امتحان کنید";

    }
}
