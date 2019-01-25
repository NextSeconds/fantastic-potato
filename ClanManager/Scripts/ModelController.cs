using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClanManager.Scripts
{
    public class ModelController:Singleton<ModelController>
    {
        public ClanInfo clanInfo = null;
        public List<String> memberTagList = new List<string>();
        private const string myClanTag = "#G8VVVRQY";

        public void Init()
        {
            clanInfo = GetClanInfo(myClanTag);
            if (clanInfo == null)
            {
                TipController.Instance.ShowTip("创建GridView失败");
                return;
            }
            for (int i = 0; i < clanInfo.memberList.Count; i++)
            {
                memberTagList.Add(clanInfo.memberList[i].tag);
            }
            Reg.EventDispatcher.DispatchEventWith(EventName.VIEW_MAINFORM_INIT_CLAN_DATAGRIDVIEW, clanInfo);
        }

        public ClanInfo GetClanInfo(string clanTag)
        {
            clanTag = clanTag.Replace("#", "%23");
            if (clanInfo != null)
            {
                TipController.Instance.ShowTip("已使用旧数据");
                return clanInfo;
            }
            //ModelController.Instance.SaveClanInfo(clanInfo);
            //return clanInfo;//终止
            int result;
            string url = "https://api.clashofclans.com/v1/clans/" + clanTag;
            clanInfo = HttpController.GetResponse<ClanInfo>(url, out result);
            if (clanInfo == null)
            {
                TipController.Instance.ShowTip("api连接失败\n原因：" + result);
            }
            else
            {
                TipController.Instance.ShowTip("连接api成功");
            }
            return clanInfo;
        }
    }
}
