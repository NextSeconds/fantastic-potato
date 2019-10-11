using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ClanManager.Scripts;
using ClanManager.Job;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.AdoJobStore.Common;
using System.Configuration;
using Quartz.Impl.AdoJobStore;
using System.Threading.Tasks;

namespace ClanManager
{
    public partial class EmailManage : Form
    {
        private SchedulerCenter scheduler = SchedulerCenter.Instance;
        public EmailManage()
        {
            InitializeComponent();
        }

        private void EmailManage_Load(object sender, EventArgs e)
        {
            //从数据库初始化任务数据
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            scheduler.Setting(new DbProvider("SqlServer", connectionString), typeof(SqlServerDelegate).AssemblyQualifiedName);

            StartJobController();
        }

        private async void StartJobController()
        {
            //1.通过工厂获取一个调度器的实例
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler _scheduler = await factory.GetScheduler();
            await _scheduler.Start();

            //创建任务对象
            IJobDetail job = JobBuilder.Create<JobFromDB>()
                .WithIdentity("JobBase", "GroupBase")
                .Build();

            //创建触发器
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("TriggerBase", "GroupBase")
                .StartNow()
                .WithCronSchedule("0/10 * * * * ?")//每10秒执行
                .Build();

            //将任务加入到任务池
            await _scheduler.ScheduleJob(job, trigger);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartSchedule();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopSchedule();
        }

        private void AddTestBtn_Click(object sender, EventArgs e)
        {
        }

        private void ShowJobInfo_Click(object sender, EventArgs e)
        {
            GetAllJobBriefInfoAsync();
        }

        private void EmailManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopSchedule();
        }

        public async void StartSchedule()
        {
            await scheduler.StartScheduleAsync();
        }
        public async void StopSchedule()
        {
            await scheduler.ShutdownScheduleAsync();
        }

        public async void GetAllJobBriefInfoAsync()
        {
            string str = "";
            List<JobBriefInfoEntity> jobList = await scheduler.GetAllJobBriefInfoAsync();
            for (int i = 0; i < jobList.Count; i++)
            {
                List<JobBriefInfo> info = jobList[i].JobInfoList;
                str += "组名:" + jobList[i].GroupName + "\n\r";
                for (int k = 0; k < info.Count; k++)
                {
                    str += " 任务名称:" + info[k].Name + "\n\r";
                    str += " 下次执行时间:" + info[k].NextFireTime + "\n\r";
                    str += " 上次执行时间:" + info[k].PreviousFireTime + "\n\r";
                    str += " 上次错误内容:" + info[k].LastErrMsg + "\n\r";
                    str += " 任务状态:" + info[k].TriggerState + "\n\r";
                    str += " 显示状态:" + info[k].DisplayState + "\n\r";
                    str += "\n\r";
                }
                str += "---------------------------------\n\r";
            }
            MessageBox.Show(str);
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
