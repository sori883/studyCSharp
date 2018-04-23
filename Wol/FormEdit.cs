using System.Collections;
using System.Windows.Forms;

namespace Wol
{
    public partial class FormEdit : Form
    {
        //初期化時に取得した各種値
        ArrayList names = new ArrayList();
        ArrayList ips = new ArrayList();
        ArrayList macs = new ArrayList();

        //保存時に取得した各種値
        ArrayList getNames = new ArrayList();
        ArrayList getIps = new ArrayList();
        ArrayList getMacs = new ArrayList();


        public FormEdit()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// 初期設定
        /// </summary>
        private void Init()
        {
            //行初期値
            DataView.RowCount = 30;

            //表の設定値読み取り
            XmlReader xmlReader = new XmlReader("../../Target.xml");
            names = xmlReader.GetContent("name");
            ips = xmlReader.GetContent("ip");
            macs = xmlReader.GetContent("mac");

            //取得した設定値を表に設定
            for (int i = 0; i < names.Count; i++)
            {
                DataView[0, i].Value = names[i];
                DataView[1, i].Value = ips[i];
                DataView[2, i].Value = macs[i];
            }

        }


        /// <summary>
        /// 保存ボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("設定を保存しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                GetGridItem();
                YesIsSaveData();
            }
        }


        /// <summary>
        /// キャンセルボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            GetGridItem();

            if (ComparisonItem())
            {
                DialogResult result = MessageBox.Show("設定が変更されています。\n保存しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    YesIsSaveData();
                }
            }
            else
            {
                this.Hide();
            }
        }


        private void GetGridItem()
        {
            getNames = new ArrayList();
            getIps = new ArrayList();
            getMacs = new ArrayList();

            for (int i = 0; DataView[0, i].Value != null; i++)
            {
                getNames.Add(DataView[0, i].Value.ToString());
            }

            for (int i = 0; DataView[1, i].Value != null; i++)
            {
                getIps.Add(DataView[1, i].Value.ToString());
            }

            for (int i = 0; DataView[2, i].Value != null; i++)
            {
                getMacs.Add(DataView[2, i].Value.ToString());
            }
        }

        private bool ComparisonItem()
        {
            bool result = false;

            if ((names.Count != getNames.Count) || (ips.Count != getIps.Count) || (macs.Count != getMacs.Count))
            {
                result = true;
            }
            else
            {
                for (int i = 0; i < getNames.Count; i++)
                {
                    if (!names[i].ToString().Equals(getNames[i].ToString()))
                    {
                        result = true;
                        break;
                    }

                    if (!ips[i].ToString().Equals(getIps[i].ToString()))
                    {
                        result = true;
                        break;
                    }

                    if (!macs[i].ToString().Equals(getMacs[i].ToString()))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// ダイアログのYES押下時に行うDATAGRIDの値を保存する処理
        /// </summary>
        private void YesIsSaveData()
        {

            bool valiIp = true;
            bool valiMac = true;
            bool valiCount = true;


            Validate validate = new Validate();
            valiIp = validate.IpCheck(getIps);
            valiMac = validate.MacCheck(getMacs);

            if (!((getIps.Count == getMacs.Count) && (getNames.Count == getIps.Count)))
            {
                valiCount = false;
            }

            if (valiIp && valiMac && valiCount)
            {
                XmlWriter xmlWriter = new XmlWriter();
                xmlWriter.CreateEdit("../../Target.xml", getNames, getIps, getMacs);
                MessageBox.Show("設定を保存しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            else
            {
                MessageBox.Show("入力値が正しくありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
