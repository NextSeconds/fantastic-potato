using System;
using ClanManager.Scripts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClanManager
{
    /*     View层，单独实现了组合模式
         * Model层和View层，实现了观察者模式
         * View层和Controller层，实现了策略模式*/

    //Controller 从视图读取数据，用户输入等指令，并向模型发送数据。
    //Model 处理业务逻辑，负责存取数据。
    //View 依照数据层，更新视图。 
    static class Program
    {
        /// <summary>
        /// Main 
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
            Application.Run(new EmailManage());
        }
    }
}
