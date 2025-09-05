using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;


#nullable enable
namespace InvestSupTool.Config
{
    public class AppConfig
    {
        private static string _configPath = "config.ini";
        private static string _environment = "Development";

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(
          string section,
          string key,
          string val,
          string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(
          string section,
          string key,
          string def,
          StringBuilder retVal,
          int size,
          string filePath);

        public static string Environment
        {
            get => _environment;
            set => _environment = value;
        }

        public static string ConfigPath
        {
            get => _configPath;
            set => _configPath = value;
        }

        public static void WriteValue(string section, string key, string value) => WritePrivateProfileString(section, key, value, _configPath);

        public static string ReadValue(string section, string key, string defaultValue = "")
        {
            StringBuilder retVal = new StringBuilder(511);
            GetPrivateProfileString(section, key, defaultValue, retVal, 511, _configPath);
            return retVal.ToString();
        }

        public static void InitializeConfig()
        {
            if (!File.Exists(_configPath))
                CreateDefaultConfig();
            _environment = ReadValue("Environment", "Current", "Development");
        }

        private static void CreateDefaultConfig()
        {
            WriteValue("Environment", "Current", "Development");
            WriteValue("Environment", "Available", "Development,Production,Testing");
        }

        public static void SwitchEnvironment(string newEnvironment)
        {
            string str = ReadValue("Environment", "Available");
            if (!str.Contains(newEnvironment))
                throw new ArgumentException("Environment '" + newEnvironment + "' is not available. Available environments: " + str);
            WriteValue("Environment", "Current", newEnvironment);
            _environment = newEnvironment;
        }
    }
}
