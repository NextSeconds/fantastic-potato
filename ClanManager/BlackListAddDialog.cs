using System;
using System.Windows.Forms;
using ClanManager.Scripts;

namespace ClanManager
{
    public partial class BlackListAddDialog : Form
    {
        public BlackListAddDialog()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void singleAddButton_Click(object sender, EventArgs e)
        {
            string tag = singleAddTagTextBox.Text;
            string remarks = singleAddRemarksTextBox.Text;
            if (BlackList.Instance.SingleAdd(tag, remarks))
            {
                singleAddTagTextBox.Text = "";
                singleAddRemarksTextBox.Text = "";
            }
        }

        private void batchAddButton_Click(object sender, EventArgs e)
        {
            string tagContent = batchAddTagsTextBox.Text;
            string remarks = batchAddRemarksTextBox.Text;
            tagContent = tagContent.Replace(" ", "");
            tagContent = tagContent.Replace("\r", "");
            string[] tagList = tagContent.Split('\n');

            BlackList.Instance.BatchAdd(tagList, remarks);

            batchAddTagsTextBox.Text = "";
            batchAddRemarksTextBox.Text = "";
        }
    }
}
