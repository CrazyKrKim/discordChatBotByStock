using InvestSupTool.Config;
using InvestSupTool.ControlForm;
using InvestSupTool.Util;
using log4net.Config;

namespace InvestSupTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.InitLog4Net();
            LogUtil.Info("Current Environment: " + AppConfig.Environment);
            try
            {
                EnvironmentManager.ValidateEnvironmentConfiguration();
                LogUtil.Info("Environment configuration is valid!");
            }
            catch (InvalidOperationException ex)
            {
                LogUtil.Error("InvalidOperationException", (Exception)ex);
            }
        }

        private void InitLog4Net()
        {
            string str = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");
            if (!File.Exists(str))
                return;
            XmlConfigurator.Configure(new FileInfo(str));
        }

        private void _ButtonEnvironmentSetting_Click(object sender, EventArgs e)
        {
            using (FormEnvironmentSetting environmentSetting = new FormEnvironmentSetting())
            {
                environmentSetting.ShowDialog();
            }
        }
    }
}
