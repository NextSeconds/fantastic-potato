using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanManager.Scripts
{
    public class BlackList:Singleton<BlackList>
    {
        private List<BlackPlayerInfo> blackPlayerList = new List<BlackPlayerInfo>();

        public void Init()
        {
            blackPlayerList = GetBlackContentList();
            if (blackPlayerList == null)
            {
                TipController.Instance.ShowTip("黑名单为空");
                return;
            }
            bool isUpdated = false;

            for (int i = 0; i < blackPlayerList.Count; i++)
            {
                if (blackPlayerList[i].CheckPlayerContent())
                {
                    TipController.Instance.ShowTip("玩家信息补齐成功");
                    isUpdated = true;
                }
                else
                {
                    TipController.Instance.ShowTip("玩家信息补齐失败");
                    break;
                }
            }
            isUpdated = CheckMember();
            
            if (isUpdated)
            {
                Save();
            }

            Reg.EventDispatcher.DispatchEventWith<List<BlackPlayerInfo>>(EventName.VIEW_MAINFORM_INIT_BLACKLIST_DATAGRIDVIEW, blackPlayerList);
        }

        public bool CheckMember()
        {
            bool isUpdated = false;
            List<string> memberTagList = ModelController.Instance.memberTagList;
            for (int i = 0; i < blackPlayerList.Count; i++)
            {
                if (memberTagList.Contains(blackPlayerList[i].tag))
                {
                    if (blackPlayerList[i].UpdatePlayerInfo())
                    {
                        return true;
                    }
                }
            }
            return isUpdated;
        }

        public void Add(string tag, string remarks)
        {
            BlackPlayerInfo playerInfo = new BlackPlayerInfo(tag, remarks);
            playerInfo.CheckPlayerContent();
            blackPlayerList.Add(playerInfo);
            playerInfo = null;
            Reg.EventDispatcher.DispatchEventWith<List<BlackPlayerInfo>>(EventName.VIEW_MAINFORM_INIT_BLACKLIST_DATAGRIDVIEW, blackPlayerList);
            Save();
        }

        public void Delete(string tag)
        {
            bool isRemoved = false;
            for (int i = 0; i < blackPlayerList.Count; i++)
            {
                if (blackPlayerList[i].tag == tag)
                {
                    blackPlayerList.RemoveAt(i);
                    isRemoved = true;
                }
            }
            if (isRemoved)
            {
                TipController.Instance.ShowTip("成功删除");
            }
            else
            {
                TipController.Instance.ShowTip("未找到");
            }
            Reg.EventDispatcher.DispatchEventWith<List<BlackPlayerInfo>>(EventName.VIEW_MAINFORM_INIT_BLACKLIST_DATAGRIDVIEW, blackPlayerList);
            Save();
        }

        public void Change(string tag,string remarks)
        {

            Reg.EventDispatcher.DispatchEventWith<List<BlackPlayerInfo>>(EventName.VIEW_MAINFORM_INIT_BLACKLIST_DATAGRIDVIEW, blackPlayerList);
            Save();
        }

        public void Find(string tag)
        {
        }

        public List<BlackPlayerInfo> GetBlackContentList()
        {
            return (List<BlackPlayerInfo>)JsonConvert.DeserializeObject(FileController.Instance.GetBlackListContent());
        }

        public void Save()
        {
            FileController.Instance.SaveBlackListContent(JsonConvert.SerializeObject(blackPlayerList));
        }
    }
}
