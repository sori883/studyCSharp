
using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

namespace Wol
{
    /// <summary>v
    /// 一括でシャットダウンを行う
    /// </summary>
    class Down
    {
        //シャットダウン先を決めるIP
        ArrayList ips = new ArrayList();
        ArrayList option = new ArrayList();

        public Down()
        {
            //シャットダウンを行うPCのipを取得
            XmlReader xmlTarget = new XmlReader("../../Target.xml");
            ips = xmlTarget.GetContent("ip");

            //シャットダウンまでの時間を取得
            XmlReader xmlOption = new XmlReader("../../AppSettings.xml");
            option = xmlOption.GetContent("DownTime");


            //シャットダウン処理
            if (ips.Count != 0)
            {
                //シャットダウン処理
                Shutdown();
            }
            else
            {
                //PC情報が登録されていない場合
                MessageBox.Show("編集からPC情報を登録してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        /// <summary>
        /// シャットダウンコマンドを実行する
        /// </summary>
        public void Shutdown()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                psi.FileName = "shutdown.exe";

                for(int i = 0; i < ips.Count; i++)
                {
                    psi.Arguments = "-s -t 5 -c \" " + option[0] + "秒後にシャットダウンします。\" -m " + ips[i];
                    Process p = Process.Start(psi);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
    }
}
