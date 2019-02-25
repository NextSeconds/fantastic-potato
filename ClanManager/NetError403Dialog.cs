using System;
using ClanManager.Scripts;
using System.Windows.Forms;

namespace ClanManager
{
    public partial class NetError403Dialog : Form
    {
        private const string url = "https://developer.clashofclans.com/#/login";

        public NetError403Dialog()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void NetError403Dialog_Load(object sender, EventArgs e)
        {
            ipTextBox.Text = HttpController.GetIP();
            linkTextLabel.Text = url;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(url);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            string token = tokenBox.Text;
            if (string.IsNullOrEmpty(token))
            {
                MessageBox.Show("你还未输入令牌");
                return;
            }
            ModelController.Instance.SetPrivateKey(token);
            if (!ModelController.Instance.TestPrivateKeyAvailable())
            {
                MessageBox.Show("你输入的令牌无效");
                return;
            }
            ModelController.Instance.CloseNetErrorDialog();
        }

        protected override void WndProc(ref Message msg)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (msg.Msg == WM_SYSCOMMAND && ((int)msg.WParam == SC_CLOSE))
            {
                // 点击winform右上关闭按钮 
                // 加入想要的逻辑处理
                System.Environment.Exit(0);
                //加入return阻止窗体关闭
            }
            base.WndProc(ref msg);
        }
    }
}
