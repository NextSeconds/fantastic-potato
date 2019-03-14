namespace ClanManager
{
    partial class BlackListAddDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.singleAddTagTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.singleAddButton = new System.Windows.Forms.Button();
            this.singleAddRemarksTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.batchAddButton = new System.Windows.Forms.Button();
            this.batchAddRemarksTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.batchAddTagsTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "玩家标签";
            // 
            // singleAddTagTextBox
            // 
            this.singleAddTagTextBox.Location = new System.Drawing.Point(126, 76);
            this.singleAddTagTextBox.Name = "singleAddTagTextBox";
            this.singleAddTagTextBox.Size = new System.Drawing.Size(132, 26);
            this.singleAddTagTextBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.singleAddButton);
            this.groupBox1.Controls.Add(this.singleAddRemarksTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.singleAddTagTextBox);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 133);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "单个添加";
            // 
            // singleAddButton
            // 
            this.singleAddButton.Location = new System.Drawing.Point(637, 76);
            this.singleAddButton.Name = "singleAddButton";
            this.singleAddButton.Size = new System.Drawing.Size(105, 26);
            this.singleAddButton.TabIndex = 4;
            this.singleAddButton.Text = "添加";
            this.singleAddButton.UseVisualStyleBackColor = true;
            this.singleAddButton.Click += new System.EventHandler(this.singleAddButton_Click);
            // 
            // singleAddRemarksTextBox
            // 
            this.singleAddRemarksTextBox.Location = new System.Drawing.Point(313, 76);
            this.singleAddRemarksTextBox.Name = "singleAddRemarksTextBox";
            this.singleAddRemarksTextBox.Size = new System.Drawing.Size(287, 26);
            this.singleAddRemarksTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "被拉黑的原因";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.batchAddButton);
            this.groupBox2.Controls.Add(this.batchAddRemarksTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.batchAddTagsTextBox);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 287);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "批量添加";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label6.Location = new System.Drawing.Point(106, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 48);
            this.label6.TabIndex = 6;
            this.label6.Text = "一个标签占一行\r\n\r\n请务必保证格式准确\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 80);
            this.label5.TabIndex = 5;
            this.label5.Text = "适用于多个玩家\r\n\r\n因同一个原因进\r\n\r\n入黑名单的情况\r\n";
            // 
            // batchAddButton
            // 
            this.batchAddButton.Location = new System.Drawing.Point(637, 86);
            this.batchAddButton.Name = "batchAddButton";
            this.batchAddButton.Size = new System.Drawing.Size(105, 178);
            this.batchAddButton.TabIndex = 4;
            this.batchAddButton.Text = "添加";
            this.batchAddButton.UseVisualStyleBackColor = true;
            this.batchAddButton.Click += new System.EventHandler(this.batchAddButton_Click);
            // 
            // batchAddRemarksTextBox
            // 
            this.batchAddRemarksTextBox.Location = new System.Drawing.Point(313, 40);
            this.batchAddRemarksTextBox.Name = "batchAddRemarksTextBox";
            this.batchAddRemarksTextBox.Size = new System.Drawing.Size(287, 26);
            this.batchAddRemarksTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "被拉黑的原因";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "玩家标签";
            // 
            // batchAddTagsTextBox
            // 
            this.batchAddTagsTextBox.Location = new System.Drawing.Point(281, 86);
            this.batchAddTagsTextBox.Multiline = true;
            this.batchAddTagsTextBox.Name = "batchAddTagsTextBox";
            this.batchAddTagsTextBox.Size = new System.Drawing.Size(319, 178);
            this.batchAddTagsTextBox.TabIndex = 1;
            // 
            // BlackListAddDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BlackListAddDialog";
            this.Text = "BlackListAddDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BlackListAddDialog_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox singleAddTagTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button singleAddButton;
        private System.Windows.Forms.TextBox singleAddRemarksTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button batchAddButton;
        private System.Windows.Forms.TextBox batchAddRemarksTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox batchAddTagsTextBox;
    }
}