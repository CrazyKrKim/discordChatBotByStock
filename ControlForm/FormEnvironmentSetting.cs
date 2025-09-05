using InvestSupTool.Config;
using InvestSupTool.StockAPI;
using InvestSupTool.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestSupTool.ControlForm
{
    public partial class FormEnvironmentSetting : Form
    {
        public FormEnvironmentSetting()
        {
            InitializeComponent();
            this.InitForm();
            this.SampleRequestHeaderSetting();
            this.SampleQueryParameter();
        }

        private void InitForm()
        {
            string appKey = EnvironmentManager.GetCurrentEnvironmentSettings().AppKey;
            string appSecret = EnvironmentManager.GetCurrentEnvironmentSettings().AppSecret;
            string accessToken = EnvironmentManager.GetCurrentEnvironmentSettings().AccessToken;
            string discordBotToken = EnvironmentManager.GetCurrentEnvironmentSettings().DiscordBotToken;
            this._TextBoxAppKey.Text = appKey;
            this._TextBoxAppSecret.Text = appSecret;
            this._TextBoxAccessToken.Text = accessToken;
            this._TextBoxUrl.Text = "/uapi/domestic-stock/v1/quotations/inquire-price";
            this._TextBoxDiscordToken.Text = discordBotToken;
        }

        private void SampleRequestHeaderSetting() => this._TextBoxRequestHeader.Text = JObject.Parse(JsonConvert.SerializeObject((object)new JObject()
    {
      {
        "authorization",
        (JToken) this._TextBoxAccessToken.Text
      },
      {
        "appkey",
        (JToken) this._TextBoxAppKey.Text
      },
      {
        "appsecret",
        (JToken) this._TextBoxAppSecret.Text
      },
      {
        "tr_id",
        (JToken) "FHKST01010100"
      },
      {
        "custtype",
        (JToken) "P"
      }
    }, Formatting.Indented)).ToString();

        private void SampleQueryParameter() => this._TextBoxQueryParameter.Text = JObject.Parse(JsonConvert.SerializeObject((object)new JObject()
    {
      {
        "FID_COND_MRKT_DIV_CODE",
        (JToken) "J"
      },
      {
        "FID_INPUT_ISCD",
        (JToken) "005930"
      }
    }, Formatting.Indented)).ToString();

        private async void _ButtonAPICall_Click(
#nullable enable
        object sender, EventArgs e)
        {
            string url = EnvironmentManager.GetCurrentEnvironmentSettings().ApiUrl + this._TextBoxUrl.Text.Trim();
            Dictionary<string, string> headers = JsonConvert.DeserializeObject<Dictionary<string, string>>(this._TextBoxRequestHeader.Text);
            Dictionary<string, string> queryParams = JsonConvert.DeserializeObject<Dictionary<string, string>>(this._TextBoxQueryParameter.Text);
            if (headers == null || queryParams == null)
            {
                int num = (int)MessageBox.Show("Request headers or query parameters are invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                url = (string)null;
                headers = (Dictionary<string, string>)null;
                queryParams = (Dictionary<string, string>)null;
            }
            else
            {
                RichTextBox richTextBox = this._TextBoxResponseBody;
                string str = await RestApiUtil.PostRequest(url, this._TextBoxRequestBody.Text, headers, queryParams);
                richTextBox.Text = str;
                richTextBox = (RichTextBox)null;
                str = (string)null;
                url = (string)null;
                headers = (Dictionary<string, string>)null;
                queryParams = (Dictionary<string, string>)null;
            }
        }

        private async void _ButtonDiscordStart_Click(object sender, EventArgs e) => await DiscordBotUtil.Instance.StartAsync(this._TextBoxDiscordToken.Text);

        private async void _ButtonDiscordStop_Click(object sender, EventArgs e) => await DiscordBotUtil.Instance.StopAsync();

        private async void _ButtonKospiCodeDownload_Click(object sender, EventArgs e)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            await RestApiUtil.RequestDownloadFile(EnvironmentManager.GetCurrentEnvironmentSettings().KospiCodeDownloadUrl, baseDir, "kospi_code.zip");
            ZipUtil zipUtil = new ZipUtil();
            zipUtil.ZipUnPack(baseDir + "kospi_code.zip", baseDir, true);
            StockInfo.ImportKospiCodeToLiteDB(baseDir);
            baseDir = (string)null;
            zipUtil = (ZipUtil)null;
        }


    }
}
