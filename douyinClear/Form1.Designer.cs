namespace douyinClear
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtSource = new douyinClear.TextBoxEx();
            this.btnGetUrl = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.txtGetUrl = new System.Windows.Forms.TextBox();
            this.labMessage = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(26, 27);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.PlaceHolderStr = "请输入抖音分享链接地址";
            this.txtSource.Size = new System.Drawing.Size(481, 59);
            this.txtSource.TabIndex = 1;
            // 
            // btnGetUrl
            // 
            this.btnGetUrl.Location = new System.Drawing.Point(26, 104);
            this.btnGetUrl.Name = "btnGetUrl";
            this.btnGetUrl.Size = new System.Drawing.Size(102, 23);
            this.btnGetUrl.TabIndex = 2;
            this.btnGetUrl.Text = "生成去水印地址";
            this.btnGetUrl.UseVisualStyleBackColor = true;
            this.btnGetUrl.Click += new System.EventHandler(this.btnGetUrl_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(156, 104);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 3;
            this.btnDownload.Text = "下载视频";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // txtGetUrl
            // 
            this.txtGetUrl.Location = new System.Drawing.Point(26, 143);
            this.txtGetUrl.Multiline = true;
            this.txtGetUrl.Name = "txtGetUrl";
            this.txtGetUrl.Size = new System.Drawing.Size(481, 68);
            this.txtGetUrl.TabIndex = 4;
            this.txtGetUrl.Visible = false;
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.Location = new System.Drawing.Point(165, 225);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(0, 12);
            this.labMessage.TabIndex = 5;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(26, 220);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.Text = "复制地址";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Visible = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 255);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.txtGetUrl);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnGetUrl);
            this.Controls.Add(this.txtSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "抖音去水印工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBoxEx txtSource;
        private System.Windows.Forms.Button btnGetUrl;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.TextBox txtGetUrl;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Button btnCopy;
    }
}

