using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanManager.Scripts
{
    public class BlackList
    {
        public List<BlackPlayerInfo> blackPlayerList;

        public void Init()
        {
            GetBlackContentList();
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

            List<string> memberTagList = ModelController.Instance.memberTagList;
            for (int i = 0; i < blackPlayerList.Count; i++)
            {
                if (memberTagList.Contains(blackPlayerList[i].tag))
                {
                    if (blackPlayerList[i].UpdatePlayerInfo())
                    {
                        isUpdated = true;
                    }
                }
            }
            if (isUpdated)
            {
                Save();
            }
        }

        public void Add(string tag, string remarks)
        {
            BlackPlayerInfo playerInfo = new BlackPlayerInfo(tag, remarks);
            playerInfo.CheckPlayerContent();
            blackPlayerList.Add(playerInfo);
            playerInfo = null;
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
            Save();
        }

        public void Change(string tag,string remarks)
        {
            Save();
        }

        public void Find(string tag)
        {
            Save();
        }

        public void GetBlackContentList()
        {
            blackPlayerList = (List<BlackPlayerInfo>)JsonConvert.DeserializeObject(FileController.Instance.GetBlackListContent());
        }

        public void Save()
        {
            FileController.Instance.SaveBlackListContent(JsonConvert.SerializeObject(blackPlayerList));
        }
    }
}
