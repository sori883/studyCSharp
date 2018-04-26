using System.Collections;
using System.Windows.Forms;

namespace Wol
{
    /// <summary>
    /// PC情報を登録するフォームを形成するクラス
    /// </summary>
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
            //gridvieの値を取得
            GetGridItem();

            //フォーム表示時とキャンセルボタン押下時の値が違っていたら
            if (ComparisonItem())
            {
                //設定が変更されてるよダイアログを表示
                DialogResult result = MessageBox.Show("設定が変更されています。\n保存しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //保存する場合としない場合
                if (result == DialogResult.Yes)
                {
                    YesIsSaveData();
                    this.Hide();
                }
                else
                {
                    this.Hide();
                }
            }
            else
            {
                //値に変化がなかった時
                this.Hide();
            }
        }


        /// <summary>
        /// gridviewの値を取得する
        /// </summary>
        private void GetGridItem()
        {
            //gridviewから取得した値を保存
            getNames = new ArrayList();
            getIps = new ArrayList();
            getMacs = new ArrayList();

            //forで回して値を取得
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

        /// <summary>
        /// フォーム表示時とキャンセルボタン押下時にgridviewの値に差異があるか
        /// </summary>
        /// <returns>差異があった場合true、差異がない場合はfalse</returns>
        private bool ComparisonItem()
        {
            //falseの場合差異なし
            bool result = false;

            //各列の行数は同じかどうか
            if ((names.Count != getNames.Count) || (ips.Count != getIps.Count) || (macs.Count != getMacs.Count))
            {
                //違かった差異あり
                result = true;
            }
            else
            {
                //各列の行数が同じだった場合、フォーム表示時に取得した値とキャンセルボタン押下時の値を列ごとに比較する
                for (int i = 0; i < getNames.Count; i++)
                {
                    if (!names[i].ToString().Equals(getNames[i].ToString()))
                    {
                        //差異があったらtureにしてループを抜ける
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
            //バリデータの結果を格納 true = 正常
            bool valiIp = true;
            bool valiMac = true;
            bool valiCount = true;

            //バリデートクラスでIPとMACをバリデート（端末名はなし）
            Validate validate = new Validate();
            valiIp = validate.IpCheck(getIps);
            valiMac = validate.MacCheck(getMacs);

            //端末名・IP・MACの数が全て等しいか判断
            if (!((getIps.Count == getMacs.Count) && (getNames.Count == getIps.Count)))
            {
                valiCount = false;
            }

            //バリデートを全てクリアした場合
            if (valiIp && valiMac && valiCount)
            {
                //gridviewの値を保存
                XmlWriter xmlWriter = new XmlWriter();
                xmlWriter.CreateEdit("../../Target.xml", getNames, getIps, getMacs);
                MessageBox.Show("設定を保存しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            else
            {
                //バリデートに引っかかった場合
                MessageBox.Show("入力値が正しくありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
