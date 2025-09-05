namespace InvestSupTool.ControlForm
{
    partial class FormEnvironmentSetting
    {
        private TabControl _TabPanel;
        private TabPage _TabSetting;
        private TabPage _TabApiTest;
        private Label label1;
        private Label label2;
        private TextBox _TextBoxAppKey;
        private Label label3;
        private TextBox _TextBoxAppSecret;
        private TextBox _TextBoxAccessToken;
        private TextBox _TextBoxUrl;
        private Label label4;
        private Label label5;
        private RichTextBox _TextBoxRequestBody;
        private Label label6;
        private RichTextBox _TextBoxResponseBody;
        private Label label7;
        private RichTextBox _TextBoxRequestHeader;
        private RichTextBox _TextBoxQueryParameter;
        private Label label8;
        private Button _ButtonAPICall;
        private Label label9;
        private TextBox _TextBoxDiscordToken;
        private Button _ButtonDiscordStop;
        private Button _ButtonDiscordStart;
        private TabPage _TabTest;
        private Button _ButtonKospiCodeDownload;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._TabPanel = new TabControl();
            this._TabSetting = new TabPage();
            this._ButtonDiscordStop = new Button();
            this._ButtonDiscordStart = new Button();
            this._TextBoxDiscordToken = new TextBox();
            this.label9 = new Label();
            this._TextBoxAccessToken = new TextBox();
            this.label3 = new Label();
            this._TextBoxAppSecret = new TextBox();
            this.label2 = new Label();
            this._TextBoxAppKey = new TextBox();
            this.label1 = new Label();
            this._TabApiTest = new TabPage();
            this._ButtonAPICall = new Button();
            this._TextBoxQueryParameter = new RichTextBox();
            this.label8 = new Label();
            this._TextBoxRequestHeader = new RichTextBox();
            this.label7 = new Label();
            this._TextBoxResponseBody = new RichTextBox();
            this.label6 = new Label();
            this._TextBoxRequestBody = new RichTextBox();
            this.label5 = new Label();
            this._TextBoxUrl = new TextBox();
            this.label4 = new Label();
            this._TabTest = new TabPage();
            this._ButtonKospiCodeDownload = new Button();
            this._TabPanel.SuspendLayout();
            this._TabSetting.SuspendLayout();
            this._TabApiTest.SuspendLayout();
            this._TabTest.SuspendLayout();
            this.SuspendLayout();
            this._TabPanel.Controls.Add((Control)this._TabSetting);
            this._TabPanel.Controls.Add((Control)this._TabApiTest);
            this._TabPanel.Controls.Add((Control)this._TabTest);
            this._TabPanel.Dock = DockStyle.Fill;
            this._TabPanel.Location = new Point(0, 0);
            this._TabPanel.Name = "_TabPanel";
            this._TabPanel.SelectedIndex = 0;
            this._TabPanel.Size = new Size(886, 521);
            this._TabPanel.TabIndex = 0;
            this._TabSetting.BackColor = Color.Gainsboro;
            this._TabSetting.Controls.Add((Control)this._ButtonDiscordStop);
            this._TabSetting.Controls.Add((Control)this._ButtonDiscordStart);
            this._TabSetting.Controls.Add((Control)this._TextBoxDiscordToken);
            this._TabSetting.Controls.Add((Control)this.label9);
            this._TabSetting.Controls.Add((Control)this._TextBoxAccessToken);
            this._TabSetting.Controls.Add((Control)this.label3);
            this._TabSetting.Controls.Add((Control)this._TextBoxAppSecret);
            this._TabSetting.Controls.Add((Control)this.label2);
            this._TabSetting.Controls.Add((Control)this._TextBoxAppKey);
            this._TabSetting.Controls.Add((Control)this.label1);
            this._TabSetting.Location = new Point(4, 24);
            this._TabSetting.Name = "_TabSetting";
            this._TabSetting.Padding = new Padding(3);
            this._TabSetting.Size = new Size(878, 493);
            this._TabSetting.TabIndex = 0;
            this._TabSetting.Text = "환경설정";
            this._ButtonDiscordStop.Location = new Point(559, 43);
            this._ButtonDiscordStop.Name = "_ButtonDiscordStop";
            this._ButtonDiscordStop.Size = new Size(122, 23);
            this._ButtonDiscordStop.TabIndex = 9;
            this._ButtonDiscordStop.Text = "디스코드봇 Stop";
            this._ButtonDiscordStop.UseVisualStyleBackColor = true;
            this._ButtonDiscordStop.Click += new EventHandler(this._ButtonDiscordStop_Click);
            this._ButtonDiscordStart.Location = new Point(431, 43);
            this._ButtonDiscordStart.Name = "_ButtonDiscordStart";
            this._ButtonDiscordStart.Size = new Size(122, 23);
            this._ButtonDiscordStart.TabIndex = 8;
            this._ButtonDiscordStart.Text = "디스코드봇 Start";
            this._ButtonDiscordStart.UseVisualStyleBackColor = true;
            this._ButtonDiscordStart.Click += new EventHandler(this._ButtonDiscordStart_Click);
            this._TextBoxDiscordToken.Enabled = false;
            this._TextBoxDiscordToken.Location = new Point(431, 9);
            this._TextBoxDiscordToken.Name = "_TextBoxDiscordToken";
            this._TextBoxDiscordToken.Size = new Size(209, 23);
            this._TextBoxDiscordToken.TabIndex = 7;
            this.label9.AutoSize = true;
            this.label9.Location = new Point(334, 13);
            this.label9.Name = "label9";
            this.label9.Size = new Size(91, 15);
            this.label9.TabIndex = 6;
            this.label9.Text = "Discord Token :";
            this._TextBoxAccessToken.Enabled = false;
            this._TextBoxAccessToken.Location = new Point(105, 69);
            this._TextBoxAccessToken.Name = "_TextBoxAccessToken";
            this._TextBoxAccessToken.Size = new Size(209, 23);
            this._TextBoxAccessToken.TabIndex = 5;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new Size(86, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Access Token :";
            this._TextBoxAppSecret.Enabled = false;
            this._TextBoxAppSecret.Location = new Point(105, 38);
            this._TextBoxAppSecret.Name = "_TextBoxAppSecret";
            this._TextBoxAppSecret.Size = new Size(209, 23);
            this._TextBoxAppSecret.TabIndex = 3;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(8, 43);
            this.label2.Name = "label2";
            this.label2.Size = new Size(73, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "APP Secret :";
            this._TextBoxAppKey.Enabled = false;
            this._TextBoxAppKey.Location = new Point(105, 9);
            this._TextBoxAppKey.Name = "_TextBoxAppKey";
            this._TextBoxAppKey.Size = new Size(209, 23);
            this._TextBoxAppKey.TabIndex = 1;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(59, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "APP Key :";
            this._TabApiTest.BackColor = Color.Gainsboro;
            this._TabApiTest.Controls.Add((Control)this._ButtonAPICall);
            this._TabApiTest.Controls.Add((Control)this._TextBoxQueryParameter);
            this._TabApiTest.Controls.Add((Control)this.label8);
            this._TabApiTest.Controls.Add((Control)this._TextBoxRequestHeader);
            this._TabApiTest.Controls.Add((Control)this.label7);
            this._TabApiTest.Controls.Add((Control)this._TextBoxResponseBody);
            this._TabApiTest.Controls.Add((Control)this.label6);
            this._TabApiTest.Controls.Add((Control)this._TextBoxRequestBody);
            this._TabApiTest.Controls.Add((Control)this.label5);
            this._TabApiTest.Controls.Add((Control)this._TextBoxUrl);
            this._TabApiTest.Controls.Add((Control)this.label4);
            this._TabApiTest.Location = new Point(4, 24);
            this._TabApiTest.Name = "_TabApiTest";
            this._TabApiTest.Padding = new Padding(3);
            this._TabApiTest.Size = new Size(878, 493);
            this._TabApiTest.TabIndex = 1;
            this._TabApiTest.Text = "API테스트";
            this._ButtonAPICall.BackColor = Color.White;
            this._ButtonAPICall.Location = new Point(429, 10);
            this._ButtonAPICall.Name = "_ButtonAPICall";
            this._ButtonAPICall.Size = new Size(94, 23);
            this._ButtonAPICall.TabIndex = 11;
            this._ButtonAPICall.Text = "API호출";
            this._ButtonAPICall.UseVisualStyleBackColor = false;
            this._ButtonAPICall.Click += new EventHandler(this._ButtonAPICall_Click);
            this._TextBoxQueryParameter.Location = new Point(98, 189);
            this._TextBoxQueryParameter.Name = "_TextBoxQueryParameter";
            this._TextBoxQueryParameter.Size = new Size(325, 128);
            this._TextBoxQueryParameter.TabIndex = 10;
            this._TextBoxQueryParameter.Text = "";
            this.label8.AutoSize = true;
            this.label8.Location = new Point(8, 192);
            this.label8.Name = "label8";
            this.label8.Size = new Size(80, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "QueryParam :";
            this._TextBoxRequestHeader.Location = new Point(529, 46);
            this._TextBoxRequestHeader.Name = "_TextBoxRequestHeader";
            this._TextBoxRequestHeader.Size = new Size(325, 128);
            this._TextBoxRequestHeader.TabIndex = 8;
            this._TextBoxRequestHeader.Text = "";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(429, 49);
            this.label7.Name = "label7";
            this.label7.Size = new Size(94, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "RequestHeader :";
            this._TextBoxResponseBody.Location = new Point(98, 348);
            this._TextBoxResponseBody.Name = "_TextBoxResponseBody";
            this._TextBoxResponseBody.Size = new Size(325, 128);
            this._TextBoxResponseBody.TabIndex = 6;
            this._TextBoxResponseBody.Text = "";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(8, 351);
            this.label6.Name = "label6";
            this.label6.Size = new Size(91, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "ResponseBody :";
            this._TextBoxRequestBody.Location = new Point(98, 46);
            this._TextBoxRequestBody.Name = "_TextBoxRequestBody";
            this._TextBoxRequestBody.Size = new Size(325, 128);
            this._TextBoxRequestBody.TabIndex = 4;
            this._TextBoxRequestBody.Text = "";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(8, 49);
            this.label5.Name = "label5";
            this.label5.Size = new Size(83, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "RequestBody :";
            this._TextBoxUrl.Location = new Point(98, 10);
            this._TextBoxUrl.Name = "_TextBoxUrl";
            this._TextBoxUrl.Size = new Size(325, 23);
            this._TextBoxUrl.TabIndex = 2;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(8, 13);
            this.label4.Name = "label4";
            this.label4.Size = new Size(29, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Url :";
            this._TabTest.BackColor = Color.WhiteSmoke;
            this._TabTest.Controls.Add((Control)this._ButtonKospiCodeDownload);
            this._TabTest.Location = new Point(4, 24);
            this._TabTest.Name = "_TabTest";
            this._TabTest.Padding = new Padding(3);
            this._TabTest.Size = new Size(878, 493);
            this._TabTest.TabIndex = 2;
            this._TabTest.Text = "기타테스트";
            this._ButtonKospiCodeDownload.Location = new Point(21, 17);
            this._ButtonKospiCodeDownload.Name = "_ButtonKospiCodeDownload";
            this._ButtonKospiCodeDownload.Size = new Size(98, 43);
            this._ButtonKospiCodeDownload.TabIndex = 0;
            this._ButtonKospiCodeDownload.Text = "코스피Download";
            this._ButtonKospiCodeDownload.UseVisualStyleBackColor = true;
            this._ButtonKospiCodeDownload.Click += new EventHandler(this._ButtonKospiCodeDownload_Click);
            this.AutoScaleDimensions = new SizeF(7f, 15f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(886, 521);
            this.Controls.Add((Control)this._TabPanel);
            this.Name = nameof(FormEnvironmentSetting);
            this.Text = "EnvironmentSetting";
            this._TabPanel.ResumeLayout(false);
            this._TabSetting.ResumeLayout(false);
            this._TabSetting.PerformLayout();
            this._TabApiTest.ResumeLayout(false);
            this._TabApiTest.PerformLayout();
            this._TabTest.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}