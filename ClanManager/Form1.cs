using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClanManager.Scripts;

namespace ClanManager
{
    public partial class MainForm : Form
    {
        public static MainForm mainForm;

        public MainForm()
        {
            InitializeComponent();
            mainForm = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reg.EventDispatcher.AddEventListener<AppEvent<string>>(EventName.VIEW_MAINFORM_TEXTBOX_SHOWTIP, ShowTip);
            Reg.EventDispatcher.AddEventListener<AppEvent<ClanInfo>>(EventName.VIEW_MAINFORM_INIT_CLAN_DATAGRIDVIEW, InitClanDataGridView);

            FileController.Instance.Init();
            ModelController.Instance.Init();
            BlackList.Instance.Init();
        }
        public void InitClanDataGridView(AppEvent<ClanInfo> evt)
        {
            string clanInfoText = string.Format("部落名称：{0}    成员数：{1}", evt.data.name, evt.data.members);
            clanLabel.Text = clanInfoText;
            List<Members> members = evt.data.memberList;
            mainDataView.Columns.Add("clanRank", "序号");
            mainDataView.Columns.Add("tag", "标签");
            mainDataView.Columns.Add("name", "名称");
            mainDataView.Columns.Add("role", "职位");
            mainDataView.Columns.Add("expLevel", "等级");
            mainDataView.Columns.Add("trophies", "奖杯");
            mainDataView.Columns.Add("versusTrophies", "夜奖杯");
            mainDataView.Columns.Add("donations", "捐兵");
            mainDataView.Columns.Add("donationsReceived", "收兵");

            for (int i = 0; i < members.Count; i++)
            {
                mainDataView.Rows.Add();
                mainDataView.Rows[i].Cells[0].Value = members[i].clanRank;
                mainDataView.Rows[i].Cells[1].Value = members[i].tag;
                mainDataView.Rows[i].Cells[2].Value = members[i].name;
                mainDataView.Rows[i].Cells[3].Value = members[i].GetRoleText();
                mainDataView.Rows[i].Cells[4].Value = members[i].expLevel;
                mainDataView.Rows[i].Cells[5].Value = members[i].trophies;
                mainDataView.Rows[i].Cells[6].Value = members[i].versusTrophies;
                mainDataView.Rows[i].Cells[7].Value = members[i].donations;
                mainDataView.Rows[i].Cells[8].Value = members[i].donationsReceived;
            }
            mainDataView.AllowUserToAddRows = false;
            mainDataView.RowHeadersWidth= 4;
            mainDataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void ShowTip(AppEvent<string> evt)
        {
            string content = evt.data;
            textBox1.AppendText(content + "\n");
            textBox1.ScrollToCaret();
            toolStripStatusLabel1.Text = content;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Reg.EventDispatcher.RemoveEventListener<AppEvent<string>>(EventName.VIEW_MAINFORM_TEXTBOX_SHOWTIP, ShowTip);
            Reg.EventDispatcher.RemoveEventListener<AppEvent<ClanInfo>>(EventName.VIEW_MAINFORM_INIT_CLAN_DATAGRIDVIEW, InitClanDataGridView);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = !textBox1.Visible;
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewController.Instance.ShowBlackListAddDialog();
        }

        private void 黑名单管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewController.Instance.ShowBlackListForm();
        }

        private void 邮件服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewController.Instance.ShowEmailDialog();
        }
    }
}
