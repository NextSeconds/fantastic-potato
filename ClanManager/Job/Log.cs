using System;
using System.Windows.Forms;
namespace ClanManager.Job
{
    public class Log
    {
        public static void Information(string msg) {
            MessageBox.Show(msg);
        }
        public static void Error(string msg) { }
        public static void Error(Exception ex,string msg) { }
        public static void Warning(string msg) { }
    }
}