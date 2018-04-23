using System;
using System.Windows.Forms;
using TM = System.Timers;

namespace Wol
{
    public partial class ProgressBar : Form
    {
        int cnt = 0;
        int pingCnt = 0;
        SendPing ping;
        TM.Timer timer;

        public ProgressBar()
        {
            InitializeComponent();
            Init();
            UpTimer();
        }


        public void UpTimer()
        {
            timer = new TM.Timer();
            timer.Elapsed += new TM.ElapsedEventHandler(Up);
            timer.Interval = 5000;
            timer.Enabled = true;
        }

        public void Up(object sender, EventArgs e)
        {

            if (cnt != pingCnt)
            {
                pingCnt = ping.UpPing();
                CntUp(pingCnt);
            }
            else
            {
                this.Invoke((MethodInvoker)delegate {
                    this.Hide();
                });
            }
            
        }

        public void DownTimer()
        {
            timer = new TM.Timer();
            timer.Elapsed += new TM.ElapsedEventHandler(Down);
            timer.Interval = 5000;
            timer.Enabled = true;
        }

        public void Down(object sender, EventArgs e)
        {

            if (cnt != pingCnt)
            {
                pingCnt = ping.DownPing();
                CntUp(pingCnt);
            }
            else
            {
                this.Invoke((MethodInvoker)delegate {
                    this.Hide();
                });
            }

        }


        private void CntUp(int pingCnt)
        {
            this.Invoke((MethodInvoker)delegate {
                Bar.Value = pingCnt;
            });
        }

        private void Init()
        {
            ping = new SendPing();

            XmlReader xmlTarget = new XmlReader("../../Target.xml");
            cnt = xmlTarget.GetContent("ip").Count;

            Bar.Maximum = cnt;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void ProgressBar_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Close();
        }
    }
}
