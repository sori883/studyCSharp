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
        //フォーム読み込み時のシャットダウンタイム
        int initDownTime = 0;

        public FormOption()
        {
            InitializeComponent();
            //初期化
            Init();
        }

        /// <summary>
        /// 保存ボタンクリック時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// キャンセルボタンクリック時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {

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
        }
    }
}
