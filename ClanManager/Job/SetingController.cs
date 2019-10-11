using MimeKit;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ClanManager.Job
{
    /// <summary>
    /// 设置
    /// </summary>
    public class SetingController
    {
        static string filePath = "File/Mail.txt";
        static string refreshIntervalPath = "File/RefreshInterval.json";

        static MailEntity mailData = null;
        /// <summary>
        /// 保存Mail信息
        /// </summary>
        /// <param name="mailEntity"></param>
        /// <returns></returns>
        
        public bool SaveMailInfo(MailEntity mailEntity)
        {
            mailData = mailEntity;
            //await System.IO.File.WriteAllTextAsync(filePath, JsonConvert.SerializeObject(mailEntity));
            return true;
        }

        /// <summary>
        /// 保存刷新间隔
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        
        public bool SaveRefreshInterval(RefreshIntervalEntity entity)
        {
            //await System.IO.File.WriteAllTextAsync(refreshIntervalPath, JsonConvert.SerializeObject(entity));
            return true;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        
        public RefreshIntervalEntity GetRefreshInterval()
        {
            return JsonConvert.DeserializeObject<RefreshIntervalEntity>("5");
        }

        /// <summary>
        /// 获取eMail信息
        /// </summary>
        /// <returns></returns>

        public async Task<MailEntity> GetMailInfo()
        {
            if (mailData == null)
            {
                var mail = await Task<string>.Run(() =>
                 {
                     Thread.Sleep(1);
                     return "";
                 });
                mailData = new MailEntity();
                mailData.MailFrom = "clanmanager@163.com"; //默认发件邮箱
                mailData.MailPwd = "pgfdhy0415";//默认邮箱密码
                mailData.MailHost = "smtp.163.com";//163 SMTP服务器
                mailData.MailTo = "707578743@qq.com";//默认接邮件
    }
            return mailData;
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        
        public async Task<bool> SendMail(SendMailModel model)
        {
            try
            {
                if (model.MailInfo == null)
                    model.MailInfo = await GetMailInfo();
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(model.MailInfo.MailFrom, model.MailInfo.MailFrom));
                foreach (var mailTo in model.MailInfo.MailTo.Replace("；", ";").Replace("，", ";").Replace(",", ";").Split(';'))
                {
                    message.To.Add(new MailboxAddress(mailTo, mailTo));
                }
                message.Subject = string.Format(model.Title);
                message.Body = new TextPart("html")
                {
                    Text = model.Content
                };
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect(model.MailInfo.MailHost, 465, true);
                    client.Authenticate(model.MailInfo.MailFrom, model.MailInfo.MailPwd);
                    client.Send(message);
                    client.Disconnect(true);
                }
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
