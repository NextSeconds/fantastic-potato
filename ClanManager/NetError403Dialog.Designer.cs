namespace ClanManager
{
    partial class NetError403Dialog
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
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tokenBox = new System.Windows.Forms.TextBox();
            this.linkTextLabel = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ipTextBox
            // 
            this.ipTextBox.BackColor = System.Drawing.Color.White;
            this.ipTextBox.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ipTextBox.Location = new System.Drawing.Point(153, 172);
            this.ipTextBox.Multiline = true;
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.ReadOnly = true;
            this.ipTextBox.Size = new System.Drawing.Size(265, 33);
            this.ipTextBox.TabIndex = 0;
            this.ipTextBox.Text = "111.111.111.111";
            this.ipTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(28, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(529, 220);
            this.label1.TabIndex = 1;
            this.label1.Text = "进入这个页面的原因是因为你未拥有令牌或者令牌已经失效\r\n\r\n你现在需要一个有效的令牌，才可以使用本软件。\r\n\r\n获得令牌的方式：（下面两种方式任选其一即可）\r\n\r" +
    "\n1、将这段数字发送给作者，作者看到后会提供令牌给你：\r\n\r\n\r\n2、在coc官网注册并登录后自己生成令牌：\r\n\r\n";
            // 
            // tokenBox
            // 
            this.tokenBox.Location = new System.Drawing.Point(32, 326);
            this.tokenBox.Multiline = true;
            this.tokenBox.Name = "tokenBox";
            this.tokenBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tokenBox.Size = new System.Drawing.Size(410, 103);
            this.tokenBox.TabIndex = 3;
            // 
            // linkTextLabel
            // 
            this.linkTextLabel.AutoSize = true;
            this.linkTextLabel.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkTextLabel.Location = new System.Drawing.Point(84, 239);
            this.linkTextLabel.Name = "linkTextLabel";
            this.linkTextLabel.Size = new System.Drawing.Size(429, 20);
            this.linkTextLabel.TabIndex = 4;
            this.linkTextLabel.TabStop = true;
            this.linkTextLabel.Text = "https://developer.clashofclans.com/#/login";
            this.linkTextLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(29, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(344, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "请将获得的令牌输入到下方后，点击右方按钮。";
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.SystemColors.Info;
            this.startButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startButton.ForeColor = System.Drawing.Color.Red;
            this.startButton.Location = new System.Drawing.Point(482, 326);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 103);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "我已获\r\n\r\n得令牌";
            this.startButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // NetError403Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 452);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkTextLabel);
            this.Controls.Add(this.tokenBox);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NetError403Dialog";
            this.Text = "获取可用的令牌";
            this.Load += new System.EventHandler(this.NetError403Dialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tokenBox;
        private System.Windows.Forms.LinkLabel linkTextLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button startButton;
    }
}