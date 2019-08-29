using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ClanManager.Scripts
{
    public class EmailHelper
    {
        private const string CM_ADDRESS = "clanmanager@163.com";//默认发件邮箱
        private const string CM_NAME = "ClanManager";//默认发件人姓名
        private const string CM_PW = "pgfdhy0415";//默认邮箱密码
        private const string CM_HOST = "smtp.163.com";//163 SMTP服务器

        /// <summary>
        /// 发送普通邮件，使用SSL协议加密
        /// </summary>
        /// <param name="mailTitle">邮件标题</param>
        /// <param name="mailContent">邮件内容</param>
        /// <param name="mailAddress">收件人地址集合</param>
        public static void SendMailSSL(string mailTitle, string mailContent, List<string> mailAddress)
        {
            MailMessage msg = new MailMessage();
            //添加收件人
            foreach (string address in mailAddress)
            {
                msg.To.Add(address);
            }
            //设置发件邮箱地址，发件人姓名，以及邮件编码
            msg.From = new MailAddress(CM_ADDRESS, CM_NAME, System.Text.Encoding.UTF8);
            //设置邮件标题
            msg.Subject = mailTitle;
            //设置邮件标题编码 
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            //设置邮件内容
            msg.Body = mailContent;
            //设置邮件内容编码
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            //指定是否是HTML邮件 
            msg.IsBodyHtml = true;
            //设置邮件优先级 
            msg.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();
            //设置邮箱账号密码
            client.Credentials = new NetworkCredential(CM_ADDRESS, CM_PW);
            //设置邮箱服务器使用的SSL协议端口 -可能个别要见服务器要求设置SSL协议端口
            //client.Port = 465;
            //设置smtp服务器
            client.Host = CM_HOST;
            //使用ssl加密 
            client.EnableSsl = true;
            object userState = msg;
            try
            {
                //异步发送
                client.SendAsync(msg, userState);
                //同步发送
                //client.Send(msg);
                //JScript.Alert("邮件发送成功！");
            }
            catch (SmtpException ex)
            {
                int i = 0;
            }
        }

        //多表格邮件内容
        public static string GetMailBodyFromDataTable(DataTable data, string title = "以下内容为系统自动发送，请勿直接回复，谢谢。")
        {
            string MailBody = "";
            if (title != "")
                MailBody += "<p style=\"font-size: 10pt\">" + title + "</p>";


            MailBody += "<div align=\"center\">";
            MailBody += "<table cellspacing=\"1\" cellpadding=\"3\" border=\"0\" bgcolor=\"000000\" style=\"font-size: 10pt;line-height: 15px;\">";


            MailBody += "<tr>";
            for (int hcol = 0; hcol < data.Columns.Count; hcol++)
            {
                MailBody += "<td bgcolor=\"edff70\">&nbsp;&nbsp;&nbsp;";
                MailBody += data.Columns[hcol].ColumnName;
                MailBody += "&nbsp;&nbsp;&nbsp;</td>";
            }
            MailBody += "</tr>";


            for (int row = 0; row < data.Rows.Count; row++)
            {
                MailBody += "<tr>";
                for (int col = 0; col < data.Columns.Count; col++)
                {
                    MailBody += "<td bgcolor=\"ffffff\">&nbsp;&nbsp;&nbsp;";
                    MailBody += data.Rows[row][col].ToString();
                    MailBody += "&nbsp;&nbsp;&nbsp;</td>";
                }
                MailBody += "</tr>";
            }
            MailBody += "</table><br>";
            MailBody += "</div>";
            return MailBody;
        }
    }
}
