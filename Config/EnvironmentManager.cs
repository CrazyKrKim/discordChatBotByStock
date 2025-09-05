using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


#nullable enable
namespace InvestSupTool.Config
{    public class EnvironmentManager
    {
        private static readonly Dictionary<string, EnvironmentSettings> _environments = new Dictionary<string, EnvironmentSettings>();

        static EnvironmentManager() => AppConfig.ConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");

        public static void InitializeEnvironments()
        {
            _environments["Development"] = new EnvironmentSettings()
            {
                Name = "Development"
            };
            _environments["Production"] = new EnvironmentSettings()
            {
                Name = "Production"
            };
            _environments["Testing"] = new EnvironmentSettings()
            {
                Name = "Testing"
            };
        }

        public static EnvironmentSettings GetCurrentEnvironmentSettings()
        {
            string environment1 = AppConfig.Environment;
            if (_environments.ContainsKey(environment1))
            {
                EnvironmentSettings environment2 = _environments[environment1];
                environment2.DatabaseConnection = AppConfig.ReadValue(environment1, "DatabaseConnection");
                environment2.LogLevel = AppConfig.ReadValue(environment1, "LogLevel");
                environment2.ApiUrl = AppConfig.ReadValue(environment1, "InvestmentApiUrl");
                environment2.AppKey = AppConfig.ReadValue(environment1, "InvestmentAppKey");
                environment2.AppSecret = AppConfig.ReadValue(environment1, "InvestmentAppSecret");
                environment2.AccessToken = AppConfig.ReadValue(environment1, "InvestmentAccessToken");
                environment2.DiscordBotApplicationID = AppConfig.ReadValue(environment1, "DiscordBotApplicationID");
                environment2.DiscordBotToken = AppConfig.ReadValue(environment1, "DiscordBotToken");
                environment2.KospiCodeDownloadUrl = AppConfig.ReadValue(environment1, "KospiCodeDownloadUrl");
                return environment2;
            }
            return new EnvironmentSettings()
            {
                Name = environment1
            };
        }

        public static List<string> GetAvailableEnvironments() => _environments.Keys.ToList();

        public static bool IsValidEnvironment(string environmentName) => _environments.ContainsKey(environmentName);

        public static void ApplyEnvironmentSettings(string environmentName)
        {
            EnvironmentSettings environmentSettings = IsValidEnvironment(environmentName) ? _environments[environmentName] : throw new ArgumentException("Environment '" + environmentName + "' is not valid.");
            AppConfig.WriteValue(environmentName, "DatabaseConnection", environmentSettings.DatabaseConnection ?? "");
            AppConfig.WriteValue(environmentName, "LogLevel", environmentSettings.LogLevel ?? "");
            AppConfig.WriteValue(environmentName, "InvestmentApiUrl", environmentSettings.ApiUrl ?? "");
            AppConfig.WriteValue(environmentName, "InvestmentAppKey", environmentSettings.AppKey ?? "");
            AppConfig.WriteValue(environmentName, "InvestmentAppSecret", environmentSettings.AppSecret ?? "");
            AppConfig.WriteValue(environmentName, "InvestmentAccessToken", environmentSettings.AccessToken ?? "");
            AppConfig.WriteValue(environmentName, "DiscordBotApplicationID", environmentSettings.DiscordBotApplicationID ?? "");
            AppConfig.WriteValue(environmentName, "DiscordBotToken", environmentSettings.DiscordBotToken ?? "");
            AppConfig.WriteValue(environmentName, "KospiCodeDownloadUrl", environmentSettings.KospiCodeDownloadUrl);
            AppConfig.SwitchEnvironment(environmentName);
        }

        public static void ValidateEnvironmentConfiguration()
        {
            string environment = AppConfig.Environment;
            EnvironmentSettings environmentSettings = GetCurrentEnvironmentSettings();
            List<string> values = new List<string>();
            if (string.IsNullOrEmpty(environmentSettings.DatabaseConnection))
                values.Add("Database connection string is not configured");
            if (string.IsNullOrEmpty(environmentSettings.ApiUrl))
                values.Add("API URL is not configured");
            if (string.IsNullOrEmpty(environmentSettings.AppKey))
                values.Add("AppKey is not configured");
            if (string.IsNullOrEmpty(environmentSettings.AppSecret))
                values.Add("AppSecret is not configured");
            if (string.IsNullOrEmpty(environmentSettings.KospiCodeDownloadUrl))
                values.Add("KospiCodeDownloadUrl is not configured");
            if (values.Count > 0)
                throw new InvalidOperationException("Environment configuration validation failed for '" + environment + "':\n" + string.Join("\n", values));
        }

        public static string ReadIniValue(string environment, string key, string defaultValue = "") => AppConfig.ReadValue(environment, key, defaultValue);

        public static void WriteIniValue(string environment, string key, string value) => AppConfig.WriteValue(environment, key, value);

        public static string ReadCurrentEnvironmentValue(string key, string defaultValue = "") => AppConfig.ReadValue(AppConfig.Environment, key, defaultValue);

        public static void WriteCurrentEnvironmentValue(string key, string value) => AppConfig.WriteValue(AppConfig.Environment, key, value);

        public static Dictionary<string, string> ReadEnvironmentAllValues(string environment)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string[] strArray = new string[5]
            {
                "DatabaseConnection",
                "LogLevel",
                "InvestmentApiUrl",
                "InvestmentAppKey",
                "InvestmentAppSecret"
            };
            foreach (string key in strArray)
                dictionary[key] = AppConfig.ReadValue(environment, key);
            return dictionary;
        }

        public static Dictionary<string, string> ReadCurrentEnvironmentAllValues() => ReadEnvironmentAllValues(AppConfig.Environment);

        public static void WriteEnvironmentAllValues(
          string environment,
          Dictionary<string, string> values)
        {
            foreach (KeyValuePair<string, string> keyValuePair in values)
                AppConfig.WriteValue(environment, keyValuePair.Key, keyValuePair.Value);
        }

        public static void WriteCurrentEnvironmentAllValues(Dictionary<string, string> values) => WriteEnvironmentAllValues(AppConfig.Environment, values);
    }
}
