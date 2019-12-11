using System;
using System.Windows.Forms;
namespace ClanManager.Job
{
    public class Log
    {
        public static void Information(string msg)
        {
            DBLog("Info", msg);
        }
        public static void Information(LogInfoModel loginfo)
        {
            DBLog("Info", loginfo);
        }
        public static void Error(string msg)
        {
            DBLog("Error", msg);
        }
        public static void Error(Exception ex, string msg)
        {
            DBLog("Error", msg +"："+ ex.Message );
        }
        public static void Error(Exception ex, LogInfoModel loginfo)
        {
            DBLog("Error", ex.Message, loginfo);
        }
        public static void Warning(string msg) {
            DBLog("Warning", msg);
        }
        public static void DBLog(string TYPE, string msg)
        {
            DBHelper.ExecuteSql(@"insert into Log(type,pos,msg,time,Origin)values('" + TYPE + "', '', '" + msg + "', GETDATE(), '1')");
        }

        public static void DBLog(string TYPE, LogInfoModel loginfo)
        {
            DBHelper.ExecuteSql(@"insert into Log(type,pos,msg,time,Origin,BeginTime,EndTime,Seconds,JobGroup,JobName,Url,RequestType,Parameters,Result,ErrorMsg)
            values('" + TYPE + "','','',GETDATE(),'1','" + loginfo.BeginTime + "','" + loginfo.EndTime + "','" +
            loginfo.Seconds + "','','" + loginfo.JobName + "','" + loginfo.Url + "','" + loginfo.RequestType + "','" +
            loginfo.Parameters + "','" + loginfo.Result + "','" + loginfo.ErrorMsg + "')");
        }
        public static void DBLog(string TYPE, string msg, LogInfoModel loginfo)
        {
            DBHelper.ExecuteSql(@"insert into Log(type,pos,msg,time,Origin,BeginTime,EndTime,Seconds,JobGroup,JobName,Url,RequestType,Parameters,Result,ErrorMsg)
            values('" + TYPE + "','','" + msg + "',GETDATE(),'1','" + loginfo.BeginTime + "','" + loginfo.EndTime + "','" +
            loginfo.Seconds + "','','" + loginfo.JobName + "','" + loginfo.Url + "','" + loginfo.RequestType + "','" +
            loginfo.Parameters + "','" + loginfo.Result + "','" + loginfo.ErrorMsg + "')");
        }
    }
}