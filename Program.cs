using InvestSupTool.Config;
using System;
using System.Windows.Forms;

namespace InvestSupTool
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            // ISSUE: reference to a compiler-generated method
            ApplicationConfiguration.Initialize();
            AppConfig.InitializeConfig();
            EnvironmentManager.InitializeEnvironments();
            Application.Run((Form)new Form1());
        }
    }
}