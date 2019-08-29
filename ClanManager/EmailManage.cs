using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using ClanManager.Scripts;

namespace ClanManager
{
    public partial class EmailManage : Form
    {
        public EmailManage()
        {
            InitializeComponent();
        }

        private void EmailManage_Load(object sender, EventArgs e)
        {
            this.lbTime.Text = "";
            this.lbTime.ForeColor = Color.Green;
            InitTimer();
            timer.Stop();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Start();
            this.lbTime.ForeColor = Color.Green;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.lbTime.ForeColor = Color.Blue;
        }

        //定义Timer类
        System.Timers.Timer timer;
        //定义委托
        public delegate void SetControlValue();
        /// <summary>
        /// 初始化Timer控件
        /// </summary>
        private void InitTimer()
        {
            //设置定时间隔(毫秒为单位)
            int interval = 1000;
            timer = new System.Timers.Timer(interval);
            //设置执行一次（false）还是一直执行(true)
            timer.AutoReset = true;
            //设置是否执行System.Timers.Timer.Elapsed事件
            timer.Enabled = true;
            //绑定Elapsed事件
            timer.Elapsed += new System.Timers.ElapsedEventHandler(TimerUp);
        }

        /// <summary>
        /// Timer类执行定时到点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerUp(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                this.Invoke(new SetControlValue(UpdateForm));
                this.Invoke(new SetControlValue(SendEmail));
            }
            catch (Exception ex)
            {
                MessageBox.Show("执行定时到点事件失败:" + ex.Message);
            }
        }

        private void UpdateForm()
        {
            this.lbTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void SendEmail()
        {
            DateTime currentTime = DateTime.Now;
            if (currentTime.Hour >= 8 && currentTime.Hour <= 20 && currentTime.Minute == 0 && currentTime.Second == 0)
            {
                try
                {
                    string clanTagSql = "select distinct ClanTag from sys_users where ClanTag is not null and emailaddress is not null and email_flag='1' and ClanTag in (select clantag from clan_block)";
                    DataTable clanTagDT = DBHelper.Query(clanTagSql).Tables[0];
                    for (int h = 0; h < clanTagDT.Rows.Count; h++)
                    {
                        string clanTag = clanTagDT.Rows[h][0].ToString();
                        List<Members> membersList = new List<Members>();
                        membersList = HttpController.GetClanMembersInfo(clanTag);
                        List<string> tagList = new List<string>();
                        for (int i = 0; i < membersList.Count; i++)
                        {
                            tagList.Add(membersList[i].tag);
                        }
                        string blockTag = "";
                        DataTable dt = DBHelper.Query("select personTag from clan_block where clantag='" + clanTag + "'").Tables[0];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string tag = dt.Rows[i][0].ToString();
                            if (tagList.IndexOf(tag) != -1)
                            {
                                blockTag += "'" + tag + "'";
                            }
                        }
                        if (blockTag != "")
                        {
                            blockTag.Replace("''", "','");
                            string content = EmailHelper.GetMailBodyFromDataTable(DBHelper.Query("select personTag as 人员标签,personName as 人员昵称,reason as 拉黑原因,opeDate as 拉黑时间 from clan_block where clantag='" + clanTag + "' and personTag in (" + blockTag + ")").Tables[0], "你们部落又出现了黑名单人员快去踢掉他们把！");
                            List<string> emailList = new List<string>();
                            DataTable emailDT = DBHelper.Query("select distinct emailaddress from sys_users where emailaddress is not null and email_flag='1' and clantag='" + clanTag + "'").Tables[0];
                            for (int i = 0; i < emailDT.Rows.Count; i++)
                            {
                                emailList.Add(emailDT.Rows[i][0].ToString());
                            }
                            EmailHelper.SendMailSSL("讨厌的人又出现了！", content, emailList);
                        }
                    }
                }
                catch
                {

                }
            }
        }
    }
}
