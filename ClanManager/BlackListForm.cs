using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClanManager.Scripts;

namespace ClanManager
{
    public partial class BlackListForm : Form
    {
        private int currentPageNum = 1;
        private int displayRowsNum = 20;
        private int allPageNum = 1;

        public BlackListForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void UpdateBlackListView(AppEvent<List<BlackPlayerInfo>> evt)
        {
            List<BlackPlayerInfo> blackList = evt.data;
            allPageNum = blackList.Count / displayRowsNum + 1;

            int currentPageRowsNum = currentPageNum < allPageNum ? displayRowsNum : blackList.Count % displayRowsNum;
            TipController.Instance.ShowTestTip("当前要打开第" + currentPageNum.ToString() + "页");

            TipController.Instance.ShowTestTip("准备打开的页面有" + currentPageRowsNum.ToString() + "行");
            if (blackListDataGridView.Rows.Count < currentPageRowsNum)
            {
                for (int i = blackListDataGridView.Rows.Count; i < currentPageRowsNum; i++)
                {
                    TipController.Instance.ShowTestTip("添加行");
                    blackListDataGridView.Rows.Add();
                }
            }
            else if (blackListDataGridView.Rows.Count > currentPageRowsNum)
            {
                for (int i = blackListDataGridView.Rows.Count - 1; i >= currentPageRowsNum; i--)
                {
                    TipController.Instance.ShowTestTip(string.Format("删除索引是{0}的行", i.ToString()));
                    blackListDataGridView.Rows.Remove(blackListDataGridView.Rows[i]);
                }
            }
            for (int i = 0; i < currentPageRowsNum; i++)
            {
                int dataIndex = (currentPageNum - 1) * displayRowsNum + i;
                if (dataIndex >= blackList.Count)
                {
                    break;
                }
                blackListDataGridView.Rows[i].Cells[0].Value = blackList[dataIndex].name;
                blackListDataGridView.Rows[i].Cells[1].Value = blackList[dataIndex].tag;
                blackListDataGridView.Rows[i].Cells[2].Value = blackList[dataIndex].remarks;
                string lastName = blackList[dataIndex].lastNameList.Count == 0 ? "" : blackList[dataIndex].lastNameList[blackList[dataIndex].lastNameList.Count - 1];
                blackListDataGridView.Rows[i].Cells[3].Value = lastName;
                TipController.Instance.ShowTestTip("当前数据索引为" + dataIndex.ToString());
                TipController.Instance.ShowTestTip(string.Format("更新数据{0}|{1}|{2}", blackList[dataIndex].name, blackList[dataIndex].tag, blackList[dataIndex].remarks));
            }

            currentPageText.Text = currentPageNum.ToString();
            infoLabel.Text = string.Format("共 {0} 条纪录，每页 {1} 条，共 {2} 页", blackList.Count, displayRowsNum, allPageNum);
        }

        private void BlackListForm_Load(object sender, EventArgs e)
        {
            Reg.EventDispatcher.AddEventListener<AppEvent<List<BlackPlayerInfo>>>(EventName.VIEW_BLACKLISTFORM_UPDATE_WIN_DATAGRIDVIEW, UpdateBlackListView);
            BlackList.Instance.UpdateBlackListView();
        }

        private void BlackListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Reg.EventDispatcher.RemoveEventListener<AppEvent<List<BlackPlayerInfo>>>(EventName.VIEW_BLACKLISTFORM_UPDATE_WIN_DATAGRIDVIEW, UpdateBlackListView);
        }

        private void homePageButton_Click(object sender, EventArgs e)
        {
            if (currentPageNum != 1)
            {
                currentPageNum = 1;
                BlackList.Instance.UpdateBlackListView();
            }
        }

        private void previousPageButton_Click(object sender, EventArgs e)
        {
            if (currentPageNum != 1)
            {
                currentPageNum -= 1;
                BlackList.Instance.UpdateBlackListView();
            }
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            if (currentPageNum != allPageNum)
            {
                currentPageNum += 1;
                BlackList.Instance.UpdateBlackListView();
            }
        }

        private void lastPageButton_Click(object sender, EventArgs e)
        {
            if (currentPageNum != allPageNum)
            {
                currentPageNum = allPageNum;
                BlackList.Instance.UpdateBlackListView();
            }
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            if (BlackList.Instance.CheckMember())
            {
                TipController.Instance.ShowBox("有黑名单人员在部落中");
            }
            else
            {
                TipController.Instance.ShowTip("检查完毕，部落中无黑名单人员。");
            }
        }
    }
}
