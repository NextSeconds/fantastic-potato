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
        private bool isBlackViewInit = true;
        private int pageNum = 1;
        private int displayRowsNum = 20;
        public MainForm()
        {
            InitializeComponent();
            mainForm = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reg.EventDispatcher.AddEventListener<AppEvent<string>>(EventName.VIEW_MAINFORM_TEXTBOX_SHOWTIP, ShowTip);
            Reg.EventDispatcher.AddEventListener<AppEvent<ClanInfo>>(EventName.VIEW_MAINFORM_INIT_CLAN_DATAGRIDVIEW, InitClanDataGridView);
            Reg.EventDispatcher.AddEventListener<AppEvent<List<BlackPlayerInfo>>>(EventName.VIEW_MAINFORM_INIT_BLACKLIST_DATAGRIDVIEW, UpdateBlackListView);

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

        private void UpdateBlackListView(AppEvent<List<BlackPlayerInfo>> evt)
        {
            List<BlackPlayerInfo> blackList = evt.data;
            if (isBlackViewInit)
            {
                blackListView.Columns.Add("name", "名称");
                blackListView.Columns.Add("lastNameList", "曾用名");
                blackListView.Columns.Add("tag", "标签");
                blackListView.Columns.Add("remarks", "备注");
                this.isBlackViewInit = false;
            }
            if (blackListView.Rows.Count < displayRowsNum)
            {
                for (int i = blackListView.Rows.Count; i < displayRowsNum; i++)
                {
                    blackListView.Rows.Add();
                }
            }
            else if (blackListView.Rows.Count > displayRowsNum)
            {
                for (int i = blackListView.Rows.Count; i > displayRowsNum; i--)
                {
                    blackListView.Rows.RemoveAt(blackListView.Rows.Count - 1);
                }
            }
            for (int i = 0; i < displayRowsNum; i++)
            {
                int dataIndex = (pageNum - 1) * displayRowsNum + i;
                if (dataIndex >= blackList.Count)
                {
                    return;
                }
                blackListView.Rows[i].Cells[0].Value = blackList[dataIndex].name;
                string lastName = blackList[dataIndex].lastNameList.Count == 0 ? "" : blackList[dataIndex].lastNameList[blackList[dataIndex].lastNameList.Count - 1];
                blackListView.Rows[i].Cells[1].Value = lastName;
                blackListView.Rows[i].Cells[2].Value = blackList[dataIndex].tag;
                blackListView.Rows[i].Cells[3].Value = blackList[dataIndex].remarks;
            }
            blackListView.AllowUserToAddRows = false;
            blackListView.ReadOnly = true;
            blackListView.RowHeadersWidth = 4;
            blackListView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void ShowTip(AppEvent<string> evt)
        {
            string content = evt.data;
            textBox1.AppendText(content + "\n");
            toolStripStatusLabel1.Text = content;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Reg.EventDispatcher.RemoveEventListener<AppEvent<string>>(EventName.VIEW_MAINFORM_TEXTBOX_SHOWTIP, ShowTip);
            Reg.EventDispatcher.RemoveEventListener<AppEvent<ClanInfo>>(EventName.VIEW_MAINFORM_INIT_CLAN_DATAGRIDVIEW, InitClanDataGridView);
            Reg.EventDispatcher.RemoveEventListener<AppEvent<List<BlackPlayerInfo>>>(EventName.VIEW_MAINFORM_INIT_BLACKLIST_DATAGRIDVIEW, UpdateBlackListView);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = !textBox1.Visible;
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewController.Instance.ShowBlackListAddDialog();
        }
    }
}
