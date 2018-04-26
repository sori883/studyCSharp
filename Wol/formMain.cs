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
            DialogResult result = MessageBox.Show("起動しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                new MagicPacket();
                //プログレスバーで進捗状況を表示
                ProgressBar progress = new ProgressBar();
                progress.UpTimer();
                progress.ShowDialog();
                //処理終了後にダイアログで通知
                MessageBox.Show("起動処理を実行しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// シャットダウンボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDown_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("シャットダウンしますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                new Down();
                //プログレスバーで進捗状況を表示
                ProgressBar progress = new ProgressBar();
                progress.DownTimer();
                progress.ShowDialog();
                //処理終了後にダイアログで通知
                MessageBox.Show("シャットダウン処理を実行しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
