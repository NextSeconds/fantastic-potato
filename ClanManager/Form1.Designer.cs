namespace ClanManager
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainDataView = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询部落信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.玩家信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.我的部落标签设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.黑名单管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clanLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.clanInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clanInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mainDataView
            // 
            this.mainDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataView.Location = new System.Drawing.Point(12, 61);
            this.mainDataView.Name = "mainDataView";
            this.mainDataView.RowTemplate.Height = 23;
            this.mainDataView.Size = new System.Drawing.Size(676, 603);
            this.mainDataView.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询ToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1298, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询部落信息ToolStripMenuItem,
            this.玩家信息ToolStripMenuItem});
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.查询ToolStripMenuItem.Text = "查询";
            // 
            // 查询部落信息ToolStripMenuItem
            // 
            this.查询部落信息ToolStripMenuItem.Name = "查询部落信息ToolStripMenuItem";
            this.查询部落信息ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.查询部落信息ToolStripMenuItem.Text = "部落信息";
            // 
            // 玩家信息ToolStripMenuItem
            // 
            this.玩家信息ToolStripMenuItem.Name = "玩家信息ToolStripMenuItem";
            this.玩家信息ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.玩家信息ToolStripMenuItem.Text = "玩家信息";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.我的部落标签设置ToolStripMenuItem,
            this.黑名单管理ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "管理";
            // 
            // 我的部落标签设置ToolStripMenuItem
            // 
            this.我的部落标签设置ToolStripMenuItem.Name = "我的部落标签设置ToolStripMenuItem";
            this.我的部落标签设置ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.我的部落标签设置ToolStripMenuItem.Text = "我的部落标签";
            // 
            // 黑名单管理ToolStripMenuItem
            // 
            this.黑名单管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem});
            this.黑名单管理ToolStripMenuItem.Name = "黑名单管理ToolStripMenuItem";
            this.黑名单管理ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.黑名单管理ToolStripMenuItem.Text = "黑名单";
            this.黑名单管理ToolStripMenuItem.Click += new System.EventHandler(this.黑名单管理ToolStripMenuItem_Click);
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.添加ToolStripMenuItem.Text = "添加";
            this.添加ToolStripMenuItem.Click += new System.EventHandler(this.添加ToolStripMenuItem_Click);
            // 
            // clanLabel
            // 
            this.clanLabel.AutoSize = true;
            this.clanLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clanLabel.Location = new System.Drawing.Point(12, 32);
            this.clanLabel.Name = "clanLabel";
            this.clanLabel.Size = new System.Drawing.Size(232, 16);
            this.clanLabel.TabIndex = 2;
            this.clanLabel.Text = "部落名称：一群萌萌哒的小猪崽";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 667);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1298, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(0, 490);
            this.textBox1.MaximumSize = new System.Drawing.Size(688, 200);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(688, 177);
            this.textBox1.TabIndex = 5;
            this.textBox1.Visible = false;
            // 
            // clanInfoBindingSource
            // 
            this.clanInfoBindingSource.DataSource = typeof(ClanManager.Scripts.ClanInfo);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 689);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.clanLabel);
            this.Controls.Add(this.mainDataView);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "部落管理助手 - ClanManager - by Moon(部落：一群萌萌哒的小猪崽)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clanInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mainDataView;
        private System.Windows.Forms.BindingSource clanInfoBindingSource;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询部落信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 玩家信息ToolStripMenuItem;
        private System.Windows.Forms.Label clanLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 我的部落标签设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 黑名单管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
    }
}

