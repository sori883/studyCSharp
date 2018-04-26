using System;
using System.Windows.Forms;
using TM = System.Timers;

namespace Wol
{
    /// <summary>
    /// 進捗状況確認用のプログレスバーを形成するクラス
    /// </summary>
    public partial class ProgressBar : Form
    {
        //プログレスバーの最大サイズ
        int cnt = 0;
        //プログレスバーの進捗
        int pingCnt = 0;
        //pingのインスタンス変数
        SendPing ping;  
        //タイマーのインスタンス変数
        TM.Timer timer;

        public ProgressBar()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// OKボタン押下時フォームを閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// 起動処理実行時の進捗確認
        /// </summary>
        public void UpTimer()
        {
            timer = new TM.Timer();
            timer.Elapsed += new TM.ElapsedEventHandler(Up);
            timer.Interval = 10000;
            timer.Enabled = true;
        }


        /// <summary>
        /// pingを10秒毎に送信して通ったらプログレスバーを進める
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Up(object sender, EventArgs e)
        {

            if (cnt != pingCnt)
            {
                pingCnt = ping.UpPing();
                CntUp();
            }
            else
            {
                StopTimer();
            }
            
        }

        /// <summary>
        /// シャットダウン処理実行時の進捗確認
        /// </summary>
        public void DownTimer()
        {
            timer = new TM.Timer();
            timer.Elapsed += new TM.ElapsedEventHandler(Down);
            timer.Interval = 30000;
            timer.Enabled = true;
        }

        /// <summary>
        /// pingを送信して通らなかったら進捗を進める
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Down(object sender, EventArgs e)
        {

            if (cnt != pingCnt)
            {
                pingCnt = ping.DownPing();
                CntUp();
            }
            else
            {
                StopTimer();
            }
        }


        /// <summary>
        /// 画面を閉じてタイマーのリソースを開放する
        /// </summary>
        private void StopTimer()
        {
            this.Invoke((MethodInvoker)delegate 
            {
                this.Hide();
            });
            timer.Stop();
            timer.Close();
        }

        /// <summary>
        /// 進捗に合わせてプログレスバーの値を変更する
        /// </summary>
        private void CntUp()
        {
            this.Invoke((MethodInvoker)delegate
            {
                Bar.Value = pingCnt;
            });
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        private void Init()
        {
            ping = new SendPing();

            //ipを取得して、取得したipの数をプログレスバーのマックス値に設定する
            XmlReader xmlTarget = new XmlReader("../../Target.xml");
            cnt = xmlTarget.GetContent("ip").Count;

            Bar.Maximum = cnt;
        }

        /// <summary>
        /// プログレスバーのクロージングイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressBar_FormClosing(object sender, FormClosingEventArgs e)
        {
            //フォームが閉じる時にタイマーのリソースを開放する
            timer.Stop();
            timer.Close();
        }
    }
}
