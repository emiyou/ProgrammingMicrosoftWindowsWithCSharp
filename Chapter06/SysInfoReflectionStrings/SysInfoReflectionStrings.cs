using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SysInfoReflectionStrings
{
    public class SysInfoReflectionStrings
    {
        private static bool bValidInfo;
        private static int iCount;
        private static string[] astrLabels;
        private static string[] astrValues;

        static SysInfoReflectionStrings()
        {
            SystemEvents.UserPreferenceChanged += UserPreferenceChanged;
            SystemEvents.DisplaySettingsChanged += DisplaySettingsChanged;
        }

        public static string[] Labels
        {
            get
            {
                GetSysInfo();
                return astrLabels;   
            }
        }

        public static string[] Values
        {
            get
            {
                GetSysInfo();
                return astrValues;
            }
        }

        public static int Count
        {
            get
            {
                GetSysInfo();
                return iCount;
            }
        }

        static void GetSysInfo()
        {
            if (bValidInfo)
            {
                return;
            }
            Type type = typeof(SystemInformation);
            PropertyInfo[] apropinfo = type.GetProperties();
            iCount = 0;
            foreach (PropertyInfo propertyInfo in apropinfo)
            {
                if (propertyInfo.CanRead && propertyInfo.GetGetMethod().IsStatic)
                {
                    iCount++;
                }
            }
            astrLabels=new string[iCount];
            astrValues = new string[iCount];
            iCount = 0;
            foreach (PropertyInfo pi in apropinfo)
            {
                if (pi.CanRead && pi.GetGetMethod().IsStatic)
                {
                    astrLabels[iCount] = pi.Name;
                    astrValues[iCount] = pi.GetValue(type, null).ToString();
                    iCount++;
                }
            }
            Array.Sort(astrLabels, astrValues);
            bValidInfo = true;
        }

        static void UserPreferenceChanged(object obj, UserPreferenceChangedEventArgs ea)
        {
            bValidInfo = false;
        }

        static void DisplaySettingsChanged(object obj, EventArgs ea)
        {
            bValidInfo = false;
        }

        public static float MaxLabelWidth(Graphics grfx, Font font)
        {
            return MaxWidth(Labels, grfx, font);
        }

        public static float MaxValueWidth(Graphics grfx, Font font)
        {
            return MaxWidth(Values, grfx, font);
        }

        static float MaxWidth(string[] astr, Graphics grfx, Font font)
        {
            float fMax = 0;
            GetSysInfo();
            foreach (var str in astr)
            {
                fMax = Math.Max(fMax, grfx.MeasureString(str, font).Width);
            }
            return fMax;
        }
    }
}
