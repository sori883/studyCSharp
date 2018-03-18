
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wol
{
    class Down
    {
        //シャットダウン先を決めるIP
        ArrayList ips = new ArrayList();

        public Down()
        {
            //ipを取得する処理
        }

        public void Shutdown()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.CreateNoWindow = true;
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
