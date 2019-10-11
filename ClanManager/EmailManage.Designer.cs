namespace ClanManager
{
    partial class EmailManage
    {
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
            this.btnStart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.AddTestBtn = new System.Windows.Forms.Button();
            this.ShowJobInfo = new System.Windows.Forms.Button();
            this.tipBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(256, 48);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始执行任务";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(256, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "停止";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // AddTestBtn
            // 
            this.AddTestBtn.Location = new System.Drawing.Point(12, 120);
            this.AddTestBtn.Name = "AddTestBtn";
            this.AddTestBtn.Size = new System.Drawing.Size(256, 48);
            this.AddTestBtn.TabIndex = 3;
            this.AddTestBtn.Text = "添加测试调度任务";
            this.AddTestBtn.UseVisualStyleBackColor = true;
            this.AddTestBtn.Click += new System.EventHandler(this.AddTestBtn_Click);
            // 
            // ShowJobInfo
            // 
            this.ShowJobInfo.Location = new System.Drawing.Point(12, 174);
            this.ShowJobInfo.Name = "ShowJobInfo";
            this.ShowJobInfo.Size = new System.Drawing.Size(256, 48);
            this.ShowJobInfo.TabIndex = 4;
            this.ShowJobInfo.Text = "查看调度信息";
            this.ShowJobInfo.UseVisualStyleBackColor = true;
            this.ShowJobInfo.Click += new System.EventHandler(this.ShowJobInfo_Click);
            // 
            // tipBox
            // 
            this.tipBox.Location = new System.Drawing.Point(12, 228);
            this.tipBox.Multiline = true;
            this.tipBox.Name = "tipBox";
            this.tipBox.Size = new System.Drawing.Size(256, 252);
            this.tipBox.TabIndex = 5;
            // 
            // EmailManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 492);
            this.Controls.Add(this.tipBox);
            this.Controls.Add(this.ShowJobInfo);
            this.Controls.Add(this.AddTestBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStart);
            this.Name = "EmailManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "任务调度";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmailManage_FormClosing);
            this.Load += new System.EventHandler(this.EmailManage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button AddTestBtn;
        private System.Windows.Forms.Button ShowJobInfo;
        private System.Windows.Forms.TextBox tipBox;
    }
}