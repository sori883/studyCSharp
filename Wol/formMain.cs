using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wol
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void ToolEdit_Click(object sender, EventArgs e)
        {

        }

        private void ToolOption_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// バージョン表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolVersion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("バージョン 1.0.0 \r\n https://sori883.com", "バージョン情報",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BtnWake_Click(object sender, EventArgs e)
        {

        }

        private void BtnDown_Click(object sender, EventArgs e)
        {

        }
    }
}
