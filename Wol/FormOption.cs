using System;
using System.Windows.Forms;

namespace Wol
{
    /// <summary>
    /// アプリの設定を行うフォーム
    /// </summary>
    public partial class FormOption : Form
    {
        //XML書き込みクラス
        XmlReader xmlReader;
        //XML読み込みクラス
        XmlWriter xmlWriter;
        //フォーム読み込み時のシャットダウンタイム
        int initDownTime = 0;

        public FormOption()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// 保存ボタンクリック時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("設定を保存しますか？","確認",MessageBoxButtons.YesNo,MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                xmlWriter.CreateOption("../../AppSettings.xml", (int)DoDownTime.Value);
                MessageBox.Show("設定を保存しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
        }

        /// <summary>
        /// キャンセルボタンクリック時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (initDownTime != (int)DoDownTime.Value)
            {
                DialogResult result = MessageBox.Show("設定が変更されています。\n保存しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    xmlWriter.CreateOption("../../AppSettings.xml", (int)DoDownTime.Value);
                    MessageBox.Show("設定を保存しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.Hide();
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        private void Init()
        {
            //設定XML読み込み
            xmlReader = new XmlReader("../../AppSettings.xml");
            //設定XMLからシャットダウンタイムを取得
            initDownTime =  Int32.Parse((String)xmlReader.GetContent("DownTime")[0]);
            //シャットダウンタイムの設定値表示
            DoDownTime.Value = initDownTime;
            //書き込みインスタンス化
            xmlWriter = new XmlWriter();
        }
    }
}
