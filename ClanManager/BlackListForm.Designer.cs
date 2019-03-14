namespace ClanManager
{
    partial class BlackListForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.currentPageText = new System.Windows.Forms.TextBox();
            this.lastPageButton = new System.Windows.Forms.Button();
            this.nextPageButton = new System.Windows.Forms.Button();
            this.previousPageButton = new System.Windows.Forms.Button();
            this.homePageButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.blackListDataGridView = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blackListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkButton);
            this.panel1.Controls.Add(this.currentPageText);
            this.panel1.Controls.Add(this.lastPageButton);
            this.panel1.Controls.Add(this.nextPageButton);
            this.panel1.Controls.Add(this.previousPageButton);
            this.panel1.Controls.Add(this.homePageButton);
            this.panel1.Controls.Add(this.infoLabel);
            this.panel1.Location = new System.Drawing.Point(-1, 498);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 38);
            this.panel1.TabIndex = 7;
            // 
            // currentPageText
            // 
            this.currentPageText.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentPageText.Location = new System.Drawing.Point(457, 8);
            this.currentPageText.Name = "currentPageText";
            this.currentPageText.ReadOnly = true;
            this.currentPageText.Size = new System.Drawing.Size(47, 21);
            this.currentPageText.TabIndex = 5;
            this.currentPageText.Text = "1";
            this.currentPageText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lastPageButton
            // 
            this.lastPageButton.Location = new System.Drawing.Point(567, 7);
            this.lastPageButton.Name = "lastPageButton";
            this.lastPageButton.Size = new System.Drawing.Size(44, 23);
            this.lastPageButton.TabIndex = 4;
            this.lastPageButton.Text = "尾页";
            this.lastPageButton.UseVisualStyleBackColor = true;
            this.lastPageButton.Click += new System.EventHandler(this.lastPageButton_Click);
            // 
            // nextPageButton
            // 
            this.nextPageButton.Location = new System.Drawing.Point(510, 7);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(51, 23);
            this.nextPageButton.TabIndex = 3;
            this.nextPageButton.Text = "下一页";
            this.nextPageButton.UseVisualStyleBackColor = true;
            this.nextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // previousPageButton
            // 
            this.previousPageButton.Location = new System.Drawing.Point(399, 7);
            this.previousPageButton.Name = "previousPageButton";
            this.previousPageButton.Size = new System.Drawing.Size(51, 23);
            this.previousPageButton.TabIndex = 2;
            this.previousPageButton.Text = "上一页";
            this.previousPageButton.UseVisualStyleBackColor = true;
            this.previousPageButton.Click += new System.EventHandler(this.previousPageButton_Click);
            // 
            // homePageButton
            // 
            this.homePageButton.Location = new System.Drawing.Point(350, 7);
            this.homePageButton.Name = "homePageButton";
            this.homePageButton.Size = new System.Drawing.Size(44, 23);
            this.homePageButton.TabIndex = 1;
            this.homePageButton.Text = "首页";
            this.homePageButton.UseVisualStyleBackColor = true;
            this.homePageButton.Click += new System.EventHandler(this.homePageButton_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(126, 12);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(197, 12);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "共 0 条纪录，每页 50 条，共 0 页";
            // 
            // blackListDataGridView
            // 
            this.blackListDataGridView.AllowUserToAddRows = false;
            this.blackListDataGridView.AllowUserToResizeRows = false;
            this.blackListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.blackListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.tag,
            this.remarks,
            this.lastNameList});
            this.blackListDataGridView.Location = new System.Drawing.Point(12, 12);
            this.blackListDataGridView.Name = "blackListDataGridView";
            this.blackListDataGridView.ReadOnly = true;
            this.blackListDataGridView.RowHeadersVisible = false;
            this.blackListDataGridView.RowHeadersWidth = 34;
            this.blackListDataGridView.RowTemplate.Height = 23;
            this.blackListDataGridView.Size = new System.Drawing.Size(624, 486);
            this.blackListDataGridView.TabIndex = 8;
            // 
            // name
            // 
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 170;
            // 
            // tag
            // 
            this.tag.HeaderText = "标签";
            this.tag.Name = "tag";
            this.tag.ReadOnly = true;
            // 
            // remarks
            // 
            this.remarks.HeaderText = "备注";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            this.remarks.Width = 200;
            // 
            // lastNameList
            // 
            this.lastNameList.HeaderText = "曾用名";
            this.lastNameList.Name = "lastNameList";
            this.lastNameList.ReadOnly = true;
            this.lastNameList.Width = 150;
            // 
            // checkButton
            // 
            this.checkButton.ForeColor = System.Drawing.Color.Crimson;
            this.checkButton.Location = new System.Drawing.Point(13, 7);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(89, 23);
            this.checkButton.TabIndex = 6;
            this.checkButton.Text = "检查部落人员";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // BlackListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 535);
            this.Controls.Add(this.blackListDataGridView);
            this.Controls.Add(this.panel1);
            this.Name = "BlackListForm";
            this.Text = "黑名单管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BlackListForm_FormClosing);
            this.Load += new System.EventHandler(this.BlackListForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blackListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox currentPageText;
        private System.Windows.Forms.Button lastPageButton;
        private System.Windows.Forms.Button nextPageButton;
        private System.Windows.Forms.Button previousPageButton;
        private System.Windows.Forms.Button homePageButton;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.DataGridView blackListDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameList;
        private System.Windows.Forms.Button checkButton;
    }
}