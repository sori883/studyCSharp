using System;
using System.Collections;
using System.Xml;

namespace Wol
{
    /// <summary>
    /// XMLから各種設定を読み込むクラス
    /// </summary>
    class XmlReader
    {
        XmlDocument doc = new XmlDocument();


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="xmlUrl>読み込むXMLのパス</param>
        public XmlReader(String xmlUrl)
        {
            //ファイルから読み込む
            doc.Load(xmlUrl);
        }

        /// <summary>
        /// XMLから内容を取得する
        /// </summary>
        /// <param name="nodeName">内容を取得する要素の名前</param>
        /// <returns>取得した内容</returns>
        public ArrayList GetContent(String nodeName)
        {
            //XMLから取得した結果を格納する
            ArrayList result = new ArrayList();

            //root要素を取得
            XmlElement root = doc.DocumentElement;
            //内容を取得する要素
            XmlNodeList node = root.GetElementsByTagName(nodeName);

            //指定したタグが存在するか
            if (node.Count > 0)
            {
                for (int i = 0; i < node.Count; i++)
                {
                    result.Add(node.Item(i).InnerText);
                }
            }

            //結果返却
            return result;

        }
    }
}
