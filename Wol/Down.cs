
using System;
using System.Collections;
using System.Diagnostics;

namespace Wol
{
    /// <summary>
    /// 一括でシャットダウンを行う
    /// </summary>
    class Down
    {
        //シャットダウン先を決めるIP
        ArrayList ips = new ArrayList();

        public Down()
        {
            //シャットダウンを行うPCのipを設定ファイルから取得
            XmlReader xmlReader = new XmlReader("../../Target.xml");
            ips = xmlReader.GetContent("mac");

            //シャットダウン処理
            Shutdown();
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
                    psi.Arguments = "-s -t 5 -c \"5秒後にシャットダウンします。\" -m " + ips[i];
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
