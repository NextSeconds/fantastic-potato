using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanManager.Scripts
{
    public class BlackPlayerInfo
    {
        public string name;
        public List<String> lastNameList = new List<string>();
        public string tag;
        public string remarks;
        private bool isContentComptele;

        private BlackPlayerInfo() { }
        public BlackPlayerInfo(string Name, string Tag, string Remarks)
        {
            this.name = Name;
            this.tag = Tag;
            this.remarks = Remarks;
            this.isContentComptele = true;
        }
        public BlackPlayerInfo(string Tag, string Remarks)
        {
            this.name = "";
            this.tag = Tag;
            this.remarks = Remarks;
            this.isContentComptele = false;
        }

        //检查玩家信息是否完整
        public bool CheckPlayerContent()
        {
            if (!this.isContentComptele)
            {
                PlayerInfo playerInfo = HttpController.GetPlayerInfo(this.tag, out int reason);
                if (playerInfo == null)
                {
                    this.isContentComptele = false;
                }
                else
                {
                    this.name = playerInfo.name;
                    this.isContentComptele = true;
                }
            }
            return isContentComptele;
        }

        //更新玩家的信息（目前只更新名字，同时保存曾用名）
        public bool UpdatePlayerInfo()
        {
            if (!isContentComptele)
            {
                return CheckPlayerContent();
            }
            else
            {
                bool isUpdated = false;
                PlayerInfo playerInfo = HttpController.GetPlayerInfo(this.tag, out int reason);
                if (playerInfo != null)
                {
                    this.lastNameList.Insert(0, this.name);
                    name = playerInfo.name;
                }
                return isUpdated;
            }
        }
    }
}
