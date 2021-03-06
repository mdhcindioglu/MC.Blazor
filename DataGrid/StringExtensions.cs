﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MC.Blazor
{
    public static class objectExtensions
    {
        public static string ToPhoneFormat(this string str)
        {
            if (str.Length == 10)
                return $"({str.Substring(0, 3)}) {str.Substring(3, 3)} {str.Substring(6, 4)}";
            else
                return str;
        }

        public static object GetValue(this object obj, string property) =>
            obj.GetType().GetProperty(property).GetValue(obj);

        public static string GetString(this object obj, string property) =>
            obj.GetType().GetProperty(property).GetValue(obj).ToString();

        public static bool GetBool(this object obj, string property)
        {
            try { return (bool)obj.GetType().GetProperty(property).GetValue(obj); }
            catch { return false; }
        }

        public static int GetInt(this object obj, string property)
        {
            try { return Int32.Parse(obj.GetType().GetProperty(property).GetValue(obj).ToString()); }
            catch { return 0; }
        }
        public static DateTime GetDateTime(this object obj, string property)
        {
            try { return DateTime.Parse(obj.GetType().GetProperty(property).GetValue(obj).ToString()); }
            catch { return new DateTime(); }
        }

        public static decimal GetDecimal(this object obj, string property)
        {
            try { return decimal.Parse(obj.GetType().GetProperty(property).GetValue(obj).ToString()); }
            catch { return 0; }
        }

        public static void SetBool(this object obj, string property, bool newValue)
        {
            try { obj.GetType().GetProperty(property).SetValue(obj, newValue); }
            catch { }
        }
    }
}
