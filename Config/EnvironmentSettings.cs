using System.Runtime.CompilerServices;


#nullable enable
namespace InvestSupTool.Config
{
    public class EnvironmentSettings
    {
        public string Name { get; set; } = string.Empty;

        public string DatabaseConnection { get; set; } = string.Empty;

        public string LogLevel { get; set; } = string.Empty;

        public string ApiUrl { get; set; } = string.Empty;

        public string AppKey { get; set; } = string.Empty;

        public string AppSecret { get; set; } = string.Empty;

        public string AccessToken { get; set; } = string.Empty;

        public string DiscordBotApplicationID { get; set; } = string.Empty;

        public string DiscordBotToken { get; set; } = string.Empty;

        public string KospiCodeDownloadUrl { get; set; } = string.Empty;

        public override string ToString()
        {
            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(47, 4);
            interpolatedStringHandler.AppendLiteral("Environment: ");
            interpolatedStringHandler.AppendFormatted(Name);
            interpolatedStringHandler.AppendLiteral("\n");
            interpolatedStringHandler.AppendLiteral("Database: ");
            interpolatedStringHandler.AppendFormatted(DatabaseConnection);
            interpolatedStringHandler.AppendLiteral("\n");
            interpolatedStringHandler.AppendLiteral("Log Level: ");
            interpolatedStringHandler.AppendFormatted(LogLevel);
            interpolatedStringHandler.AppendLiteral("\n");
            interpolatedStringHandler.AppendLiteral("API URL: ");
            interpolatedStringHandler.AppendFormatted(ApiUrl);
            interpolatedStringHandler.AppendLiteral("\n");
            return interpolatedStringHandler.ToStringAndClear();
        }
    }
}
