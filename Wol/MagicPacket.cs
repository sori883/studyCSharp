using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Wol
{
    /// <summary>
    /// MACからマジックパケットを取得し、送信する。
    /// </summary>
    class MagicPacket
    {
        //ブロードキャストアドレス
        private const String BROADCAST = "255.255.255.255";
        //ブロードキャストアドレス
        private const int PORT = 2304;

        //マックアドレス
        ArrayList macs = new ArrayList();

        //PC情報が登録されているか
        bool isPc = true;
        
        /// <summary>
        /// isPcを外に渡す処理
        /// </summary>
        /// <returns>isPc</returns>
        public bool GetIsPc()
        {
            return isPc;
        }

        public MagicPacket()
        {
            //macを取得する
            XmlReader xmlReader = new XmlReader("../../Target.xml");
            macs = xmlReader.GetContent("mac");

            if (macs.Count != 0)
            {
                //変換したMAC
                byte[] phy;
                //マジックパケット
                byte[] packet;

                //変換から送信処理理繰り返し
                for (int i = 0; i < macs.Count; i++)
                {
                    phy = ParseMac((String)macs[i]);
                    packet = CreateMagicPacket(phy);
                    SendMagicPacket(packet);
                }
            }
            else
            {
                //pc情報がない判定にする
                isPc = false;
            }
        }

        /// <summary>
        /// 文字列を分解して、MACのバイト列に変換して返します。
        /// </summary>
        /// <param name="mac">String型のMAC</param>
        /// <returns>byte型のMAC</returns>
        private byte[] ParseMac(String mac)
        {
            byte[] phy = new byte[6];
            string[] remove = mac.Split("-: ".ToCharArray());

            for (int i = 0; i < phy.Length; i++)
            {
                phy[i] = Convert.ToByte(remove[i], 16);
            }
            return phy;
        }

        /// <summary>
        /// MACよりマジックパケットを作成する
        /// </summary>
        /// <param name="phy">分解したMAC</param>
        /// <returns>マジックパケット</returns>
        private byte[] CreateMagicPacket(byte[] phy)
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            for (int i = 0; i < 6; i++)
            {
                writer.Write((byte)0xff);
            }

            for (int i = 0; i < 16; i++)
            {
                writer.Write(phy);
            }

            byte[] packet = new byte[stream.Position];
            Array.Copy(stream.ToArray(), packet, packet.Length);

            return packet;
        }

        /// <summary>
        /// マジックパケットを送信する
        /// </summary>
        /// <param name="packet">マジックパケット</param>
        private void SendMagicPacket(byte[] packet)
        {
            UdpClient client = new UdpClient();
            client.EnableBroadcast = true;
            client.Send(packet, packet.Length, new IPEndPoint(IPAddress.Parse(BROADCAST) , PORT));
        }
    }
}
