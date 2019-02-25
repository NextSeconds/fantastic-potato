using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClanManager.Scripts
{
    public class TipController : Singleton<TipController>
    {
        public void ShowBox(string content)
        {
            MessageBox.Show(content);
        }

        public void ShowTip(string content)
        {
            content = DateTime.Now + " : " + content;
            Reg.EventDispatcher.DispatchEventWith(EventName.VIEW_MAINFORM_TEXTBOX_SHOWTIP, content);
        }
    }
}
