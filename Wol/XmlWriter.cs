using System.Collections;
using System.Xml;

namespace Wol
{
    /// <summary>
    /// XMLに各種設定を書き込むクラス
    /// </summary>
    class XmlWriter
    {
        XmlDocument doc;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="xmlUrl>書き込むXMLのパス</param>
        public XmlWriter()
        {
            doc = new XmlDocument();
        }

        /// <summary>
        /// オプション設定保存用
        /// </summary>
        /// <param name="url">オプションXMLのパス</param>
        /// <param name="downTime">保存するシャットダウンまでの時間</param>
        public void CreateOption(string url, int downTime)
        {
            //XMLの内容を全て削除
            DeleteContent(url, "option");

            doc.Load(url);
            XmlElement root = doc.DocumentElement;



            XmlElement elemOption = doc.CreateElement("option");
            XmlElement elemDownTime = doc.CreateElement("DownTime");


            elemDownTime.InnerText = downTime.ToString();

            root.AppendChild(elemOption);
            elemOption.AppendChild(elemDownTime);

            doc.Save(url);
        }


        /// <summary>
        /// 編集保存用
        /// </summary>
        /// <param name="url">編集XMLのパス</param>
        /// <param name="names">端末名</param>
        /// <param name="ips">端末のIP</param>
        /// <param name="macs">端末のMAC</param>
        public void CreateEdit(string url, ArrayList names, ArrayList ips, ArrayList macs)
        {

            //XMLの内容を全て削除
            DeleteContent(url, "pc");

            doc.Load(url);
            XmlElement root = doc.DocumentElement;

            XmlElement elemPc = doc.CreateElement("pc");
            XmlElement elemName = doc.CreateElement("name");
            XmlElement elemIp = doc.CreateElement("ip");
            XmlElement elemMac = doc.CreateElement("mac");

            for (int i = 0; i < names.Count; i++)
            {
                elemName.InnerText = (string)names[i];
                elemIp.InnerText = (string)ips[i];
                elemMac.InnerText = (string)macs[i];

                root.AppendChild(elemPc);
                elemPc.AppendChild(elemName);
                elemPc.AppendChild(elemIp);
                elemPc.AppendChild(elemMac);
            }

            doc.Save(url);
        }

        /// <summary>
        /// XMLの内容を一旦削除する
        /// </summary>
        /// <param name="url">削除するXMLのパス</param>
        /// <param name="deleteNode">削除するrootnode</param>
        public void DeleteContent(string url, string deleteNode)
        {
            doc.Load(url);
            XmlElement root = doc.DocumentElement;

            root = doc.DocumentElement;
            XmlNodeList node = root.GetElementsByTagName(deleteNode);

            if (node.Count > 0)
            {
                for (int i = 0; i < node.Count; i++)
                {
                    root.RemoveChild(node.Item(i));
                }
            }

            doc.Save(url);
        }
    }
}
