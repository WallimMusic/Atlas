using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Collections.Generic;

namespace IniOkuYaz
{
    public class IniFile
    {
        public const int MaxSectionSize = 32767;

        private string m_path;

        [System.Security.SuppressUnmanagedCodeSecurity]
        private static class NativeMethods
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public static extern int GetPrivateProfileSectionNames(IntPtr lpszReturnBuffer,
                                                                   uint nSize,
                                                                   string lpFileName);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public static extern uint GetPrivateProfileString(string lpAppName,
                                                              string lpKeyName,
                                                              string lpDefault,
                                                              StringBuilder lpReturnedString,
                                                              int nSize,
                                                              string lpFileName);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public static extern uint GetPrivateProfileString(string lpAppName,
                                                              string lpKeyName,
                                                              string lpDefault,
            [In,
            Out] char[] lpReturnedString,
                                                              int nSize,
                                                              string lpFileName);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public static extern int GetPrivateProfileString(string lpAppName,
                                                             string lpKeyName,
                                                             string lpDefault,
                                                             IntPtr lpReturnedString,
                                                             uint nSize,
                                                             string lpFileName);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public static extern int GetPrivateProfileInt(string lpAppName,
                                                          string lpKeyName,
                                                          int lpDefault,
                                                          string lpFileName);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public static extern int GetPrivateProfileSection(string lpAppName,
                                                              IntPtr lpReturnedString,
                                                              uint nSize,
                                                              string lpFileName);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool WritePrivateProfileString(string lpAppName,
                                                                string lpKeyName,
                                                                string lpString,
                                                                string lpFileName);
        }

        public IniFile(string path)
        {
            m_path = System.IO.Path.GetFullPath(path);
        }

        public string Path
        {
            get
            {
                return m_path;
            }
        }

        public string IniOku(string sectionName,
                                string keyName,
                                string defaultValue)
        {
            if (sectionName == null)
            {
                throw new ArgumentNullException("sectionName");
            }
            if (keyName == null)
            {
                throw new ArgumentNullException("keyName");
            }
            var retval = new StringBuilder(IniFile.MaxSectionSize);

            NativeMethods.GetPrivateProfileString(sectionName,
                                                  keyName,
                                                  defaultValue,
                                                  retval,
                                                  IniFile.MaxSectionSize,
                                                  m_path);

            return retval.ToString();
        }

        public int GetInt16(string sectionName,
                            string keyName,
                            short defaultValue)
        {
            var retval = GetInt32(sectionName, keyName, defaultValue);

            return Convert.ToInt16(retval);
        }

        public int GetInt32(string sectionName,
                            string keyName,
                            int defaultValue)
        {
            if (sectionName == null)
            {
                throw new ArgumentNullException("sectionName");
            }
            if (keyName == null)
            {
                throw new ArgumentNullException("keyName");
            }
            return NativeMethods.GetPrivateProfileInt(sectionName, keyName, defaultValue, m_path);
        }

        public double GetDouble(string sectionName,
                                string keyName,
                                double defaultValue)
        {
            var retval = IniOku(sectionName, keyName, string.Empty);

            if (retval == null || retval.Length == 0)
            {
                return defaultValue;
            }

            return Convert.ToDouble(retval, CultureInfo.InvariantCulture);
        }

        public List<KeyValuePair<string, string>> GetSectionValuesAsList(string sectionName)
        {
            List<KeyValuePair<string, string>> retval;
            string[] keyValuePairs;
            string key, value;
            int equalSignPos;

            if (sectionName == null)
            {
                throw new ArgumentNullException("sectionName");
            }
            var ptr = Marshal.AllocCoTaskMem(IniFile.MaxSectionSize);

            try
            {
                var len = NativeMethods.GetPrivateProfileSection(sectionName,
                                                                 ptr,
                                                                 IniFile.MaxSectionSize,
                                                                 m_path);

                keyValuePairs = ConvertNullSeperatedStringToStringArray(ptr, len);
            }
            finally
            {
                Marshal.FreeCoTaskMem(ptr);
            }

            retval = new List<KeyValuePair<string, string>>(keyValuePairs.Length);

            for (var i = 0; i < keyValuePairs.Length; ++i)
            {
                equalSignPos = keyValuePairs[i].IndexOf('=');

                key = keyValuePairs[i].Substring(0, equalSignPos);

                value = keyValuePairs[i].Substring(equalSignPos + 1,
                                                   keyValuePairs[i].Length - equalSignPos - 1);

                retval.Add(new KeyValuePair<string, string>(key, value));
            }

            return retval;
        }

        public Dictionary<string, string> GetSectionValues(string sectionName)
        {
            List<KeyValuePair<string, string>> keyValuePairs;
            Dictionary<string, string> retval;

            keyValuePairs = GetSectionValuesAsList(sectionName);

            retval = new Dictionary<string, string>(keyValuePairs.Count);

            foreach (KeyValuePair<string, string> keyValuePair in keyValuePairs)
            {
                if (!retval.ContainsKey(keyValuePair.Key))
                {
                    retval.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }

            return retval;
        }

        public string[] GetKeyNames(string sectionName)
        {
            int len;
            string[] retval;

            if (sectionName == null)
            {
                throw new ArgumentNullException("sectionName");
            }
            var ptr = Marshal.AllocCoTaskMem(IniFile.MaxSectionSize);

            try
            {
                len = NativeMethods.GetPrivateProfileString(sectionName,
                                                            null,
                                                            null,
                                                            ptr,
                                                            IniFile.MaxSectionSize,
                                                            m_path);

                retval = ConvertNullSeperatedStringToStringArray(ptr, len);
            }
            finally
            {
                Marshal.FreeCoTaskMem(ptr);
            }

            return retval;
        }

        public string[] GetSectionNames()
        {
            string[] retval;
            int len;

            var ptr = Marshal.AllocCoTaskMem(IniFile.MaxSectionSize);

            try
            {
                len = NativeMethods.GetPrivateProfileSectionNames(ptr,
                    IniFile.MaxSectionSize, m_path);

                retval = ConvertNullSeperatedStringToStringArray(ptr, len);
            }
            finally
            {
                Marshal.FreeCoTaskMem(ptr);
            }
            return retval;
        }

        private static string[] ConvertNullSeperatedStringToStringArray(IntPtr ptr, int valLength)
        {
            string[] retval;

            if (valLength == 0)
            {
                retval = new string[0];
            }
            else
            {
                var buff = Marshal.PtrToStringAuto(ptr, valLength - 1);

                retval = buff.Split('\0');
            }

            return retval;
        }

        private void WriteValueInternal(string sectionName, string keyName, string value)
        {
            if (!NativeMethods.WritePrivateProfileString(sectionName, keyName, value, m_path))
            {
                throw new System.ComponentModel.Win32Exception();
            }
        }

        public void IniYaz(string sectionName, string keyName, string value)
        {
            if (sectionName == null)
            {
                throw new ArgumentNullException("sectionName");
            }
            if (keyName == null)
            {
                throw new ArgumentNullException("keyName");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            WriteValueInternal(sectionName, keyName, value);
        }

        public void IniYaz(string sectionName, string keyName, short value)
        {
            IniYaz(sectionName, keyName, (int)value);
        }

        public void IniYaz(string sectionName, string keyName, int value)
        {
            IniYaz(sectionName, keyName, value.ToString(CultureInfo.InvariantCulture));
        }

        public void IniYaz(string sectionName, string keyName, float value)
        {
            IniYaz(sectionName, keyName, value.ToString(CultureInfo.InvariantCulture));
        }

        public void IniYaz(string sectionName, string keyName, double value)
        {
            IniYaz(sectionName, keyName, value.ToString(CultureInfo.InvariantCulture));
        }

        public void DeleteKey(string sectionName, string keyName)
        {
            if (sectionName == null)
            {
                throw new ArgumentNullException("sectionName");
            }
            if (keyName == null)
            {
                throw new ArgumentNullException("keyName");
            }
            WriteValueInternal(sectionName, keyName, null);
        }

        public void DeleteSection(string sectionName)
        {
            if (sectionName == null)
            {
                throw new ArgumentNullException("sectionName");
            }
            WriteValueInternal(sectionName, null, null);
        }
    }
}
