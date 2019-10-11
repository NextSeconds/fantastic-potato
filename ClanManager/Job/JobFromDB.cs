using Quartz;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace ClanManager.Job
{
    [DisallowConcurrentExecution]
    [PersistJobDataAfterExecution]
    public class JobFromDB : IJob
    {
        private SchedulerCenter scheduler = SchedulerCenter.Instance;

        public async Task Execute(IJobExecutionContext context)
        {
            DataTable dt = DBHelper.Query("select * from Job").Tables[0];
            if (dt.Rows.Count == 1)
            {
                string switch_Flag = dt.Rows[0]["Switch_Flag"].ToString();
                //更新当前开关状态
                if (switch_Flag == "1")
                {
                    //更新总控开关状态
                    string status = dt.Rows[0]["Status"].ToString();
                    bool statusResult = status == "1" ? await scheduler.StartScheduleAsync() : await scheduler.StopScheduleAsync();
                    DBHelper.ExecuteSql("update Job set Switch_Flag ='0' where Switch_Flag='1'");//重置更新开关标记
                    //更新任务开关状态
                    DataTable jobDT = DBHelper.Query("select JobName,JobGroup,Status,Switch_Flag from Job_Info").Tables[0];
                    for (int i = 0; i < jobDT.Rows.Count; i++)
                    {
                        string job_Switch_Flag = jobDT.Rows[i]["Switch_Flag"].ToString();

                        if (job_Switch_Flag == "1")
                        {
                            string job_Status = dt.Rows[i]["Status"].ToString();
                            string job_JobName = dt.Rows[i]["JobName"].ToString();
                            string job_JobGroup = dt.Rows[i]["JobGroup"].ToString();
                            switch (job_Status)
                            {
                                case "1": await scheduler.ResumeJobAsync(job_JobGroup, job_JobName); break;
                                case "0": await scheduler.StopOrDelScheduleJobAsync(job_JobGroup, job_JobName); break;
                                case "-1": await scheduler.StopOrDelScheduleJobAsync(job_JobGroup, job_JobName, true); break;
                            }
                        }
                    }
                    DBHelper.ExecuteSql("update Job_Info set Switch_Flag ='0' where Switch_Flag='1'");
                    //删除数据库中需要删除的任务数据
                    //DBHelper.ExecuteSql("delete Job_Info where Status='-1'");
                }
                string update_Flag = dt.Rows[0]["Update_Flag"].ToString();
                if (update_Flag == "1")
                {
                    //布置任务
                    DataTable jobDT = DBHelper.Query("select * from Job_Info").Tables[0];//先拿取数据
                    DBHelper.ExecuteSql("update Job set Update_Flag ='0' where Update_Flag='1'");//重置标记
                    for (int i = 0; i < jobDT.Rows.Count; i++)
                    {
                        string job_Update_Flag = jobDT.Rows[i]["Update_Flag"].ToString();
                        if (job_Update_Flag == "1")
                        {
                            string jobName = jobDT.Rows[i]["JobName"].ToString();
                            string jobGroup = jobDT.Rows[i]["JobGroup"].ToString();
                            DateTime beginTime = Convert.ToDateTime(jobDT.Rows[i]["BeginTime"].ToString());
                            DateTime endTime = Convert.ToDateTime(jobDT.Rows[i]["EndTime"].ToString());
                            string cron = jobDT.Rows[i]["Cron"].ToString();
                            string runTimes = jobDT.Rows[i]["RunTimes"].ToString();
                            string intervalSecond = jobDT.Rows[i]["IntervalSecond"].ToString();
                            TriggerTypeEnum triggerType = (TriggerTypeEnum)Enum.Parse(typeof(TriggerTypeEnum), jobDT.Rows[i]["TriggerType"].ToString());
                            String requestUrl = jobDT.Rows[i]["RequestUrl"].ToString();
                            String requestParameters = jobDT.Rows[i]["RequestParameters"].ToString();
                            string headers = jobDT.Rows[i]["Headers"].ToString();
                            RequestTypeEnum requestType = (RequestTypeEnum)Enum.Parse(typeof(RequestTypeEnum), jobDT.Rows[i]["RequestType"].ToString());
                            string description = jobDT.Rows[i]["Description"].ToString();
                            MailMessageEnum mailMessage = (MailMessageEnum)Enum.Parse(typeof(MailMessageEnum), jobDT.Rows[i]["MailMessage"].ToString());

                            //如果存在需要先删除停止任务
                            if (await scheduler.CheckExistsJobAsync(jobGroup, jobName))
                            {
                                await scheduler.StopOrDelScheduleJobAsync(jobGroup, jobName, true);
                            }

                            //按照配置添加任务
                            ScheduleEntity entity = new ScheduleEntity();
                            entity.JobName = jobName;
                            entity.JobGroup = jobGroup;
                            entity.BeginTime = beginTime;
                            entity.EndTime = endTime;
                            if (string.IsNullOrWhiteSpace(cron))
                            {
                                entity.Cron = cron;
                            }
                            if (string.IsNullOrWhiteSpace(runTimes))
                            {
                                entity.RunTimes = int.Parse(runTimes);
                            }
                            if (string.IsNullOrWhiteSpace(intervalSecond))
                            {
                                entity.IntervalSecond = int.Parse(intervalSecond);
                            }
                            entity.TriggerType = triggerType;
                            entity.RequestUrl = requestUrl;
                            entity.RequestParameters = requestParameters;
                            entity.Headers = headers;
                            entity.RequestType = requestType;
                            entity.Description = description;
                            entity.MailMessage = mailMessage;
                            BaseResult result = await scheduler.AddScheduleJobAsync(entity);
                        }
                    }
                }
            }
        }

        public async void AddSchedule()
        {
            ScheduleEntity entity = new ScheduleEntity();
            entity.JobName = "TEST";
            entity.JobGroup = "TEST";
            entity.Cron = "0/10 * * * * ?";
            entity.EndTime = DateTime.Now.AddYears(1);
            entity.TriggerType = TriggerTypeEnum.Cron;
            entity.RequestUrl = "http://10.33.215.101:443/ClanServices.asmx/JOBTEST";
            entity.RequestParameters = "";
            entity.Headers = "";
            entity.RequestType = RequestTypeEnum.Post;
            entity.Description = "TESTJOB";
            entity.MailMessage = MailMessageEnum.All;
            BaseResult result = await scheduler.AddScheduleJobAsync(entity);
        }

        public async void GetAllJobBriefInfoAsync()
        {
            string str = "";
            List<JobBriefInfoEntity> jobList = await scheduler.GetAllJobBriefInfoAsync();
            for (int i = 0; i < jobList.Count; i++)
            {
                List<JobBriefInfo> info = jobList[i].JobInfoList;
                str += "组名:" + jobList[i].GroupName + "\\n";
                for (int k = 0; k < info.Count; k++)
                {
                    str += " 任务名称:" + info[k].Name;
                    str += " 下次执行时间:" + info[k].NextFireTime;
                    str += " 上次执行时间:" + info[k].PreviousFireTime;
                    str += " 上次错误内容:" + info[k].LastErrMsg;
                    str += " 任务状态:" + info[k].TriggerState;
                    str += " 显示状态:" + info[k].DisplayState;
                    str += "\\n";
                }
                str += "---------------------------------\\n";
            }
            MessageBox.Show(str);
        }
    }
}
