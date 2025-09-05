namespace InvestSupTool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _ButtonEnvironmentSetting = new Button();
            SuspendLayout();
            // 
            // _ButtonEnvironmentSetting
            // 
            _ButtonEnvironmentSetting.Location = new Point(697, 12);
            _ButtonEnvironmentSetting.Name = "_ButtonEnvironmentSetting";
            _ButtonEnvironmentSetting.Size = new Size(91, 41);
            _ButtonEnvironmentSetting.TabIndex = 0;
            _ButtonEnvironmentSetting.Text = "환경설정";
            _ButtonEnvironmentSetting.UseVisualStyleBackColor = true;
            _ButtonEnvironmentSetting.Click += _ButtonEnvironmentSetting_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(_ButtonEnvironmentSetting);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button _ButtonEnvironmentSetting;
    }
}
