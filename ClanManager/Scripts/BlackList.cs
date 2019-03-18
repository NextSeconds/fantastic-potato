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
            List<BlackPlayerInfo> inClanBlackMemberslist = CheckMember();
            if (inClanBlackMemberslist.Count > 0)
            {
                for (int i = 0; i < inClanBlackMemberslist.Count; i++)
                {
                    if (inClanBlackMemberslist[i].CheckPlayerName())
                    {
                        isUpdated = true;
                    }
                }
                ShowTipBlackMembersInClan(inClanBlackMemberslist);
            }

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

        /// <summary>
        /// 检查黑名单的人员是否有在当前部落中的
        /// </summary>
        /// <returns>返回人员的列表</returns>
        public List<BlackPlayerInfo> CheckMember()
        {
            List<BlackPlayerInfo> inClanBlackMembers = new List<BlackPlayerInfo>();
            List<string> memberTagList = ModelController.Instance.memberTagList;
            for (int i = 0; i < blackPlayerList.Count; i++)
            {
                if (memberTagList.Contains(blackPlayerList[i].tag))
                {
                    inClanBlackMembers.Add(blackPlayerList[i]);
                }
            }
            return inClanBlackMembers;
        }

        public void ShowTipBlackMembersInClan(List<BlackPlayerInfo> inClanBlackMemberslist)
        {
            for (int i = 0; i < inClanBlackMemberslist.Count; i++)
            {
                string tipStr = string.Format("{0}{1}又进了你的部落，他曾经因为[{2}]被踢出了部落，", inClanBlackMemberslist[i].name, inClanBlackMemberslist[i].tag, inClanBlackMemberslist[i].remarks);
                if (inClanBlackMemberslist[i].lastNameList.Count > 0)
                {
                    string lastNameStr = string.Empty;
                    for (int j = 0; j < inClanBlackMemberslist[i].lastNameList.Count; j++)
                    {
                        string Separator = (j == inClanBlackMemberslist[i].lastNameList.Count - 1) ? "  。 " : "  ， ";
                        lastNameStr += inClanBlackMemberslist[i].lastNameList[j] + Separator;
                    }
                    tipStr += string.Format("曾经用过的名字有：{0} 赶快上线去踢掉他", lastNameStr);
                }
                TipController.Instance.ShowTip(tipStr);
            }
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
            int repeatNum = 0;
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
            string tipStr = string.Format("你输入了{0}个玩家信息，重复了{1}个\n", winNum + loseNum + repeatNum,repeatNum);
            tipStr += string.Format("添加成功{0}个，失败{1}个", winNum, loseNum);
            TipController.Instance.ShowBox(tipStr);
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
