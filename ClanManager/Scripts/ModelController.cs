using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClanManager.Scripts
{
    public class ModelController : Singleton<ModelController>
    {
        public ClanInfo clanInfo = null;
        public List<String> memberTagList = new List<string>();
        private string myClanTag = "#G8VVVRQY";
        private string PRIVATE_KEY;
        Form netError403Dialog;

        private const string PIG_CLAN_TAG = "#G8VVVRQY";

        public void Init()
        {
            //检测令牌是否可用
            if (!TestPrivateKeyAvailable())
            {
                ShowNetErrorDialog();
            }

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
                TipController.Instance.ShowTip(string.Format("api连接失败：{0}({1})", HttpController.GetReason(result), result));
            }
            else
            {
                TipController.Instance.ShowTip("连接api成功");
            }
            return clanInfo;
        }

        public string GetPrivateKey()
        {
            if (string.IsNullOrEmpty(PRIVATE_KEY))
            {
                PRIVATE_KEY = FileController.Instance.GetPrivateKey();
            }
            return PRIVATE_KEY;
        }

        public void SetPrivateKey(string token)
        {
            PRIVATE_KEY = token;
            FileController.Instance.SavePrivateKey(token);
        }

        public bool TestPrivateKeyAvailable()
        {
            bool isAvailable = true;
            int result;
            string testUrl = "https://api.clashofclans.com/v1/clans/" + PIG_CLAN_TAG;
            HttpController.GetResponse<ClanInfo>(testUrl, out result);
            if (result == 403)
            {
                isAvailable = false;
            }
            return isAvailable;
        }

        private void ShowNetErrorDialog()
        {
            netError403Dialog = new NetError403Dialog();
            netError403Dialog.ShowDialog();
        }

        public void CloseNetErrorDialog()
        {
            netError403Dialog.Close();
            netError403Dialog = null;
        }
    }
}
