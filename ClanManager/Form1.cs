using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClanManager.Scripts;

namespace ClanManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reg.EventDispatcher.AddEventListener<AppEvent<ClanInfo>>("GetClanInfo", InitView);
            ModelController.Instance.Init();
        }
        public void InitView(AppEvent<ClanInfo> evt)
        {
            //Init GridView1
            List<Members> members = evt.data.memberList;
            dataGridView1.Columns.Add("clanRank", "序号");
            dataGridView1.Columns.Add("tag", "标签");
            dataGridView1.Columns.Add("name", "名称");
            dataGridView1.Columns.Add("role", "职位");
            dataGridView1.Columns.Add("expLevel", "等级");
            dataGridView1.Columns.Add("trophies", "奖杯");
            dataGridView1.Columns.Add("versusTrophies", "夜奖杯");
            dataGridView1.Columns.Add("donations", "捐兵");
            dataGridView1.Columns.Add("donationsReceived", "收兵");

            for (int i = 0; i < members.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = members[i].clanRank;
                dataGridView1.Rows[i].Cells[1].Value = members[i].tag;
                dataGridView1.Rows[i].Cells[2].Value = members[i].name;
                dataGridView1.Rows[i].Cells[3].Value = members[i].GetRoleText();
                dataGridView1.Rows[i].Cells[4].Value = members[i].expLevel;
                dataGridView1.Rows[i].Cells[5].Value = members[i].trophies;
                dataGridView1.Rows[i].Cells[6].Value = members[i].versusTrophies;
                dataGridView1.Rows[i].Cells[7].Value = members[i].donations;
                dataGridView1.Rows[i].Cells[8].Value = members[i].donationsReceived;
            }
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersWidth= 4;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Reg.EventDispatcher.RemoveEventListener<AppEvent<ClanInfo>>("GetClanInfo", InitView);
        }
    }
}
