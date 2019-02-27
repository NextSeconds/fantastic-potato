using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClanManager.Scripts
{
    public class ViewController : Singleton<ViewController>
    {
        private Form netError403Dialog;
        private Form blackListAddDialog;

        public void ShowNetErrorDialog()
        {
            netError403Dialog = new NetError403Dialog();
            netError403Dialog.ShowDialog();
        }
        public void ShowBlackListAddDialog()
        {
            blackListAddDialog = new BlackListAddDialog();
            blackListAddDialog.ShowDialog();
        }

        public void CloseNetErrorDialog()
        {
            netError403Dialog.Close();
            netError403Dialog = null;
        }

        public void CloseBlackListAddDialog()
        {
            blackListAddDialog.Close();
            blackListAddDialog = null;
        }
    }
}
