using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanManager.Scripts
{
    public class EventName
    {
        public const string VIEW_MAINFORM_INIT_CLAN_DATAGRIDVIEW = "view_mainform_init_clan_datagridview";
        public const string VIEW_MAINFORM_TEXTBOX_SHOWTIP = "view_mainform_textbox_showtip";

        public const string VIEW_BLACKLISTFORM_UPDATE_WIN_DATAGRIDVIEW = "view_blacklistform_update_win_datagridview";


        /// <summary>
        /// 示例
        /// </summary>
        private void Test()
        {
            ClanInfo clanInfo = null; 
            Reg.EventDispatcher.AddEventListener<AppEvent<ClanInfo>>(EventName.VIEW_MAINFORM_INIT_CLAN_DATAGRIDVIEW, InitClanDataGridView);
            Reg.EventDispatcher.DispatchEventWith(EventName.VIEW_MAINFORM_INIT_CLAN_DATAGRIDVIEW, clanInfo);
            Reg.EventDispatcher.RemoveEventListener<AppEvent<ClanInfo>>(EventName.VIEW_MAINFORM_INIT_CLAN_DATAGRIDVIEW, InitClanDataGridView);

            Reg.EventDispatcher.AddEventListener<AppEvent>("adad", hah);
            Reg.EventDispatcher.DispatchEvent("adad");
            Reg.EventDispatcher.RemoveEventListener<AppEvent>("adad", hah);
        }

        private void hah(AppEvent evt = null)
        {
        }

        public void InitClanDataGridView(AppEvent<ClanInfo> evt)
        {
        }
    }
}
