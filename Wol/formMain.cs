using System;
using System.Windows.Forms;

namespace Wol
{
    /// <summary>
    /// メインフォームを形成するクラス
    /// </summary>
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 編集クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolEdit_Click(object sender, EventArgs e)
        {
            FormEdit edit = new FormEdit();
            edit.ShowDialog();
        }

        /// <summary>
        /// オプションクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolOption_Click(object sender, EventArgs e)
        {
            FormOption option = new FormOption();
            option.ShowDialog();
        }

        /// <summary>
        /// バージョン表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolVersion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("バージョン 1.0.0 \r\n https://sori883.com", "バージョン情報",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        /// <summary>
        /// 起動ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnWake_Click(object sender, EventArgs e)
        {
            new MagicPacket();
        }

        /// <summary>
        /// シャットダウンボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDown_Click(object sender, EventArgs e)
        {
            new Down();
        }
    }
}
