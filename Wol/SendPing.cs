using System.Collections;
using System.Net.NetworkInformation;

namespace Wol
{
    /// <summary>
    /// 進捗確認のためのping送信クラス
    /// </summary>
    class SendPing
    {
        //pingを送るip
        private ArrayList ips = new ArrayList();
        //pingが通るなり通らないなりした回数
        private int value = 0;

        public SendPing()
        {
            //ipを取得
            XmlReader xmlTarget = new XmlReader("../../Target.xml");
            ips = xmlTarget.GetContent("ip");
        }

        /// <summary>
        /// 起動処理時のping送信処理
        /// </summary>
        /// <returns>pingが通った数</returns>
        public int UpPing()
        {
            value = 0;

            Ping ping = new Ping();
            PingReply pingReply;

            //pingの数だけ回す
            for (int i = 0; i < ips.Count; i++)
            {
                //500秒でタイムアウトするpingを送信
                pingReply = ping.Send((string)ips[i], 500);

                if (pingReply.Status == IPStatus.Success)
                {
                    //pingが通ったらプログレスバーを進めるための値を増やす
                    value += 1;
                }
            }
            ping.Dispose();
            return value;
        }

        /// <summary>
        /// シャットダウン処理時のping送信処理
        /// </summary>
        /// <returns></returns>
        public int DownPing()
        {
            value = 0;

            Ping ping = new Ping();
            PingReply pingReply;

            for (int i = 0; i < ips.Count; i++)
            {
                //400秒でタイムアウトするpingを送信
                pingReply = ping.Send((string)ips[i], 400);

                if (pingReply.Status != IPStatus.Success)
                {
                    //pingが通らなかったらプログレスバーを進めるための値を増やす
                    value += 1;
                }

            }
            ping.Dispose();
            return value;
        }
    }
}
