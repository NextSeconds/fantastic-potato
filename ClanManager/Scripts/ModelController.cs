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
        public static bool isOfflineMode = false;

        private string myClanTag = "#G8VVVRQY";
        private string privateKey = string.Empty;

        public ClanInfo clanInfo = null;
        public List<String> memberTagList = new List<string>();

        private const string PIG_CLAN_TAG = "%23G8VVVRQY";

        public string PrivateKey
        {
            get
            {
                if (string.IsNullOrEmpty(privateKey))
                {
                    privateKey = FileController.Instance.GetPrivateKey();
                }
                return privateKey;
            }
            set
            {
                this.privateKey = value;
                FileController.Instance.SavePrivateKey(value);
            }
        }

        public void Init()
        {
            //检测令牌是否可用
            if (!TestPrivateKeyAvailable())
            {
                ViewController.Instance.ShowNetErrorDialog();
            }

            clanInfo = HttpController.GetClanInfo(myClanTag);
            if (clanInfo == null)
            {
                return;
            }
            for (int i = 0; i < clanInfo.memberList.Count; i++)
            {
                memberTagList.Add(clanInfo.memberList[i].tag);
            }
            Reg.EventDispatcher.DispatchEventWith(EventName.VIEW_MAINFORM_INIT_CLAN_DATAGRIDVIEW, clanInfo);
        }

        public bool TestPrivateKeyAvailable()
        {
            bool isAvailable = true;
            int result;
            try
            {
                string testUrl = HttpController.CLAN_URL + PIG_CLAN_TAG;
                HttpController.GetResponse<ClanInfo>(testUrl, out result);
                if (result == 403)
                {
                    isAvailable = false;
                }
            }
            catch 
            {
                isAvailable = false;
            }
            return isAvailable;
        }
    }
}
