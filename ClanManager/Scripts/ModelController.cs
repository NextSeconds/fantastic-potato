using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClanManager.Scripts
{
    public class ModelController:Singleton<ModelController>
    {
        private string MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private const string ClanInfoDirectory = "ClanInfo";
        private ClanInfo clanInfo = null;
        public ClanInfo GetClanInfo(string clanTag = "#G8VVVRQY")
        {
            clanTag = clanTag.Replace("#", "%23");
            if (clanInfo != null)
            {
                MessageBox.Show("已使用旧数据");
                return clanInfo;
            }
            //ModelController.Instance.SaveClanInfo(clanInfo);
            //return clanInfo;//终止
            string result;
            string url = "https://api.clashofclans.com/v1/clans/" + clanTag;
            clanInfo = HttpController.GetResponse<ClanInfo>(url, out result);
            if (clanInfo == null)
            {
                MessageBox.Show("api连接失败\n原因：" + result);
            }
            else
            {
                MessageBox.Show("连接api成功");
            }
            return clanInfo;
        }
        public void Init()
        {
            clanInfo = GetClanInfo();
            if (clanInfo == null)
            {
                MessageBox.Show("创建GridView失败");
                return;
            }
            Reg.EventDispatcher.DispatchEventWith("GetClanInfo",clanInfo);
        }
        //File
        public void SaveClanInfo(ClanInfo clanInfo)
        {
            string clanInfoPath = MyDocumentsPath + @"\" +  ClanInfoDirectory;
            if (!Directory.Exists(clanInfoPath))
            {
                Directory.CreateDirectory(clanInfoPath);
            }
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
        }

        private void Test()
        {
            Reg.EventDispatcher.AddEventListener<AppEvent>("adad", hah);
            Reg.EventDispatcher.DispatchEvent("adad");
            Reg.EventDispatcher.RemoveEventListener<AppEvent>("adad", hah);
        }

        private void hah(AppEvent evt = null)
        {
            MessageBox.Show("事件成功");
        }

    }
}
