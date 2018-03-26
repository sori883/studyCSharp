using System.Xml;

namespace Wol
{
    /// <summary>
    /// XMLに各種設定を書き込むクラス
    /// </summary>
    class XmlWriter
    {
        XmlDocument doc = new XmlDocument();


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="xmlUrl>書き込むXMLのパス</param>
        public XmlWriter(string xmlUrl)
        {
            doc.Load(xmlUrl);
            SetContent();
            doc.Save(xmlUrl);
        }

        
        public void SetContent()
        {
            XmlElement root = doc.DocumentElement;
        }
    }
}
