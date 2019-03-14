namespace ClanManager
{
    partial class OfflineDialog
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
            this.offlineButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // offlineButton
            // 
            this.offlineButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.offlineButton.Location = new System.Drawing.Point(53, 127);
            this.offlineButton.Name = "offlineButton";
            this.offlineButton.Size = new System.Drawing.Size(140, 56);
            this.offlineButton.TabIndex = 0;
            this.offlineButton.Text = "离线模式";
            this.offlineButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.MaximumSize = new System.Drawing.Size(475, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 87);
            this.label1.TabIndex = 1;
            this.label1.Text = "  你的网络好像有些问题，你可以选择进入离线模式，或者检查网络后重新打开软件。";
            // 
            // quitButton
            // 
            this.quitButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.quitButton.Location = new System.Drawing.Point(272, 127);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(140, 56);
            this.quitButton.TabIndex = 2;
            this.quitButton.Text = "退出软件";
            this.quitButton.UseVisualStyleBackColor = true;
            // 
            // OfflineDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 204);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.offlineButton);
            this.Name = "OfflineDialog";
            this.Text = "OfflineDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button offlineButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button quitButton;
    }
}