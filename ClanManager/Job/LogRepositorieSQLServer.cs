﻿using Newtonsoft.Json.Linq;
using Quartz.Impl.AdoJobStore.Common;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClanManager.Job
{
    public class LogRepositorieSQLServer : ILogRepositorie
    {
        private IDbProvider DBProvider { get; }

        public LogRepositorieSQLServer(IDbProvider dbProvider)
        {
            DBProvider = dbProvider;
        }

        public async Task<bool> RemoveErrLogAsync(string jobGroup, string jobName)
        {
            try
            {
                /*using (var connection = new SqlConnection(DBProvider.ConnectionString))
                {
                    string sql = $@"SELECT
	                                JOB_DATA
                                FROM
	                                QRTZ_JOB_DETAILS
                                WHERE
	                                JOB_NAME = :jobName
                                AND JOB_GROUP = :jobGroup";

                    var byteArray = await connection.ExecuteScalarAsync<byte[]>(sql, new { jobName, jobGroup });
                    var jsonStr = Encoding.UTF8.GetString(byteArray);
                    JObject source = JObject.Parse(jsonStr);
                    source.Remove("Exception");//移除异常日志 
                    var modifySql = $@"UPDATE QRTZ_JOB_DETAILS
                                    SET JOB_DATA = :jobData
                                    WHERE
	                                    JOB_NAME = :jobName
                                    AND JOB_GROUP = :jobGroup";
                    await connection.ExecuteAsync(modifySql, new { jobName, jobGroup, jobData = Encoding.UTF8.GetBytes(source.ToString()) });
                }*/
                string mail = await Task<string>.Run(() =>
                {
                    Thread.Sleep(1);
                    return "";
                });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}

