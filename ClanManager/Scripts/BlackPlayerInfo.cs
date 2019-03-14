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
        public bool isContentComptele;

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

        //补齐玩家信息
        public bool CompletionPlayerContent()
        {
            PlayerInfo playerInfo = HttpController.GetPlayerInfo(this.tag, out int reason);
            if (playerInfo == null)
            {
                this.isContentComptele = false;
                TipController.Instance.ShowTip(string.Format("补齐玩家标签为{0}的信息时出现错误：{1}({2})", tag, HttpController.GetReason(reason), reason));
            }
            else
            {
                this.name = playerInfo.name;
                this.isContentComptele = true;
            }
            return isContentComptele;
        }
        /// <summary>
        /// 查看玩家名字是否改变
        /// </summary>
        /// <returns>改变了并更新了就返回true,否则就返回false</returns>
        public bool CheckPlayerName()
        {
            bool isChanged = false;
            PlayerInfo playerInfo = HttpController.GetPlayerInfo(this.tag, out int reason);
            if (playerInfo != null)
            {
                if (playerInfo.name != this.name)
                {
                    isChanged = true;
                    this.lastNameList.Add(this.name);
                    this.name = playerInfo.name;
                }
            }
            return isChanged;
        }
    }
}
