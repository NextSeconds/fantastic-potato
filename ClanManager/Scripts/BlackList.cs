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
        private List<BlackPlayerInfo> blackPlayerList;

        public void Init()
        {
            blackPlayerList = GetBlackContentList();
            if (blackPlayerList.Count == 0)
            {
                TipController.Instance.ShowTip("黑名单为空");
                return;
            }
            else
            {
                TipController.Instance.ShowTip("黑名单读取成功");
            }
            bool isUpdated = false;

            for (int i = 0; i < blackPlayerList.Count; i++)
            {
                if (!blackPlayerList[i].isContentComptele)
                {
                    if (blackPlayerList[i].CompletionPlayerContent())
                    {
                        TipController.Instance.ShowTip(string.Format("补齐了{0}的名字：{1}", blackPlayerList[i].tag, blackPlayerList[i].name));
                        isUpdated = true;
                    }
                    else
                    {
                        TipController.Instance.ShowTip(blackPlayerList[i].tag + "的信息补齐失败");
                        break;
                    }
                }
            }
            isUpdated = CheckMember();
            
            if (isUpdated)
            {
                Save();
            }

            UpdateBlackListView();
        }

        public void UpdateBlackListView()
        {
            Reg.EventDispatcher.DispatchEventWith<List<BlackPlayerInfo>>(EventName.VIEW_BLACKLISTFORM_UPDATE_WIN_DATAGRIDVIEW, blackPlayerList);
        }

        public bool CheckMember()
        {
            bool isUpdated = false;
            List<string> memberTagList = ModelController.Instance.memberTagList;
            for (int i = 0; i < blackPlayerList.Count; i++)
            {
                if (memberTagList.Contains(blackPlayerList[i].tag))
                {
                    if (blackPlayerList[i].CheckPlayerName())
                    {
                        isUpdated = true;
                    }
                    TipController.Instance.ShowTip(string.Format("{0}{1}又进了你的部落，他曾经因为[{2}]被踢出了部落，赶快上线去踢掉他", blackPlayerList[i].name, blackPlayerList[i].tag, blackPlayerList[i].remarks));
                    if (blackPlayerList[i].lastNameList.Count > 0)
                    {
                        string lastNameStr = string.Empty;
                        for (int j = 0; j < blackPlayerList[i].lastNameList.Count; j++)
                        {
                            string Separator = (j == blackPlayerList[i].lastNameList.Count - 1)? "  。 ":"  ， ";
                            lastNameStr += blackPlayerList[i].lastNameList[j] + Separator;
                        }
                        TipController.Instance.ShowTip(blackPlayerList[i].name + "曾经用过的名字有：" + lastNameStr);
                    }
                }
            }
            return isUpdated;
        }

        public bool SingleAdd(string tag, string remarks)
        {
            bool shouldCleanBoxText = true;
            BlackPlayerInfo playerInfo = new BlackPlayerInfo(tag, remarks);
            for (int i = 0; i < blackPlayerList.Count; i++)
            {
                if (blackPlayerList[i].tag == tag)
                {
                    TipController.Instance.ShowBox("标签为 " + tag + " 的玩家已经存在于黑名单内了");
                    return shouldCleanBoxText;
                }
            }
            if (playerInfo.CompletionPlayerContent())
            {
                blackPlayerList.Add(playerInfo);
                playerInfo = null;
                UpdateBlackListView();
                Save();
            }
            else
            {
                TipController.Instance.ShowBox("标签 " + tag + " 检查未通过，如日志中没有提示网络问题，则该标签无效");
                shouldCleanBoxText = false;
            }
            return shouldCleanBoxText;
        }

        public void BatchAdd(string[] tagList, string remarks)
        {
            List<string> blackPlayerTagList = new List<string>();
            BlackPlayerInfo playerInfo;

            for (int j = 0; j < blackPlayerList.Count; j++)
            {
                blackPlayerTagList.Add(blackPlayerList[j].tag);
            }
            int winNum = 0;
            int loseNum = 0;
            for (int i = 0; i < tagList.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(tagList[i]))
                {
                    break;
                }
                if (blackPlayerTagList.Contains(tagList[i]))
                {
                    TipController.Instance.ShowBox("标签为 " + tagList[i] + " 的已经存在于黑名单内了");
                    loseNum++;
                    break;
                }
                playerInfo = new BlackPlayerInfo(tagList[i], remarks);
                if (playerInfo.CompletionPlayerContent())
                {
                    blackPlayerList.Add(playerInfo);
                    winNum++;
                    TipController.Instance.ShowTip("标签为 " + tagList[i] + " 的玩家添加到黑名单成功");
                }
                else
                {
                    loseNum++;
                    TipController.Instance.ShowTip("标签为 " + tagList[i] + " 的玩家添加到黑名单失败");
                }
                playerInfo = null;
            }
            blackPlayerTagList = null;
            UpdateBlackListView();
            Save();
            if (loseNum == 0)
            {
                TipController.Instance.ShowBox(string.Format("你输入了{0}个玩家信息，全部添加成功！", winNum + loseNum));
            }
            else if (winNum == 0)
            {
                TipController.Instance.ShowBox(string.Format("你输入了{0}个玩家信息，全部添加失败！", winNum + loseNum));
            }
            else
            {
                TipController.Instance.ShowBox(string.Format("你输入了{0}个玩家信息，\n添加成功{1}个，失败{2}个", winNum + loseNum, winNum, loseNum));
            }
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
            UpdateBlackListView();
            Save();
        }

        public void Change(string tag,string remarks)
        {

            UpdateBlackListView();
            Save();
        }

        public void Find(string tag)
        {
        }

        public List<BlackPlayerInfo> GetBlackContentList()
        {
            List<BlackPlayerInfo> list = JsonConvert.DeserializeObject<List<BlackPlayerInfo>>(FileController.Instance.GetBlackListContent());
            return list == null ? new List<BlackPlayerInfo>() : list;
        }

        public void Save()
        {
            FileController.Instance.SaveBlackListContent(JsonConvert.SerializeObject(blackPlayerList));
        }
    }
}
