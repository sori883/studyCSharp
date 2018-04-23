using System.Collections;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Wol
{
    class SendPing
    {
        ArrayList ips = new ArrayList();
        int value = 0;

        public SendPing()
        {
            XmlReader xmlTarget = new XmlReader("../../Target.xml");
            ips = xmlTarget.GetContent("ip");
        }

        public int UpPing()
        {

            Ping ping = new Ping();
            for (int i = 0; i < ips.Count; i++)
            {
                PingReply pingReply = ping.Send(ips[i].ToString(), 200);

                if (pingReply.Status == IPStatus.Success)
                {
                    value += 1;
                }

            }

            ping.Dispose();
            return value;
        }

        public int DownPing()
        {

            Ping ping = new Ping();
            for (int i = 0; i < ips.Count; i++)
            {
                PingReply pingReply = ping.Send(ips[i].ToString(), 200);

                if (pingReply.Status != IPStatus.Success)
                {
                    value += 1;
                }

            }
            ping.Dispose();
            return value;
        }
    }
}
