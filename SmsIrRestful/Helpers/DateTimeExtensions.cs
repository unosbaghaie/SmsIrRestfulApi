using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsIrRestful
{
    public static class DateTimeExtensions
    {
        public static string GetPersianDate(this DateTime? helper)
        {
            return DateTime.Parse(helper.ToString()).GetPersianDate();
        }
        public static string GetPersianDate(this DateTime helper)
        {
            string format = "yyyy/mm/dd";

            if (helper.Year < 1000) helper = DateTime.Now;
            PersianCalendar pc = new PersianCalendar();

            StringBuilder result = new StringBuilder(format.ToLower());

            result = result.Replace("yyyy", pc.GetYear(helper).ToString());

            result = result.Replace("mm", pc.GetMonth(helper).ToString("00"));

            result = result.Replace("dd", pc.GetDayOfMonth(helper).ToString("00"));

            return result.ToString();
        }
        public static string GetPersianDateWithTime(this DateTime helper)
        {
            string format = "yyyy/mm/dd hh:jj:ss";

            if (helper.Year < 1000) helper = DateTime.Now;
            PersianCalendar pc = new PersianCalendar();

            StringBuilder result = new StringBuilder(format.ToLower());

            result = result.Replace("hh", helper.Hour.ToString());
            result = result.Replace("jj", helper.Minute.ToString());
            result = result.Replace("ss", helper.Second.ToString());

            result = result.Replace("yyyy", pc.GetYear(helper).ToString());

            result = result.Replace("mm", pc.GetMonth(helper).ToString("00"));

            result = result.Replace("dd", pc.GetDayOfMonth(helper).ToString("00"));

            return result.ToString();
        }


        public static string GetPersianDateTime(this DateTime? helper)
        {
            string format = "yyyy/mm/dd";
            return GetPersianDateTime((DateTime)helper, format);
        }
        public static string GetPersianDateTime(this DateTime helper, string format = "yyyy/mm/dd")
        {

            if (helper.Year < 1000) helper = DateTime.Now;
            PersianCalendar pc = new PersianCalendar();

            StringBuilder result = new StringBuilder(format.ToLower());

            result = result.Replace("yyyy", pc.GetYear(helper).ToString());

            result = result.Replace("mm", pc.GetMonth(helper).ToString("00"));

            result = result.Replace("dd", pc.GetDayOfMonth(helper).ToString("00"));

            result.Append(" " + helper.ToString("HH:mm:ss"));


            return result.ToString();
        }
        public static DateTime? GetEnglishDateTime(this string helper)
        {
            string pattern = @"(?>((?>13|14)\d\d)|(\d\d))\/(0?[1-9]|1[012])\/([12][0-9]|3[01]|0?[1-9])";
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(helper, pattern))
                {
                    System.Text.RegularExpressions.Regex d = new System.Text.RegularExpressions.Regex(pattern);
                    int year = int.Parse(d.Match(helper).Groups[1].Value);
                    int month = int.Parse(d.Match(helper).Groups[3].Value);
                    int day = int.Parse(d.Match(helper).Groups[4].Value);
                    PersianCalendar result = new PersianCalendar();
                    return result.ToDateTime(year, month, day, 0, 0, 0, 0);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
        public static DateTime GetEnglishDateTimeNonNullable(this string helper)
        {
            string pattern = @"(?>((?>13|14)\d\d)|(\d\d))\/(0?[1-9]|1[012])\/([12][0-9]|3[01]|0?[1-9])";
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(helper, pattern))
                {
                    System.Text.RegularExpressions.Regex d = new System.Text.RegularExpressions.Regex(pattern);
                    int year = int.Parse(d.Match(helper).Groups[1].Value);
                    int month = int.Parse(d.Match(helper).Groups[3].Value);
                    int day = int.Parse(d.Match(helper).Groups[4].Value);
                    PersianCalendar result = new PersianCalendar();
                    return result.ToDateTime(year, month, day, 0, 0, 0, 0);
                }
                return DateTime.Now;
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }


    }
}
