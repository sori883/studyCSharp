using System.Collections;
using System.Net;
using System.Text.RegularExpressions;

namespace Wol
{
    /// <summary>
    /// バリデーション
    /// </summary>
    class Validate
    {
        /// <summary>
        /// IPアドレスの正当性をチェックする
        /// </summary>
        /// <param name="ips">表から取得したip</param>
        /// <returns>判定結果</returns>
        public bool IpCheck(ArrayList ips)
        {
            //評価値true=正常
            bool result = true;

                for (int i = 0; i < ips.Count; i++)
                {
                    if (!(IPAddress.TryParse(ips[i].ToString(), out IPAddress address)))
                    {
                        result = false;
                    }
                }

            return result;
        }

        /// <summary>
        /// MACアドレスの正当性をチェックする
        /// </summary>
        /// <param name="macs">表から取得したmac</param>
        /// <returns>判定結果</returns>
        public bool MacCheck(ArrayList macs)
        {
            //評価値true=正常
            bool result = true;

            for (int i = 0; i < macs.Count; i++)
            {
                if (!(Regex.IsMatch((string)macs[i], "^([0-9A-Fa-f]{2}[:-]){5}[0-9A-Fa-f]{2}$")))
                {
                    result = false;
                }
            }
            return result;
        }

    }
}
