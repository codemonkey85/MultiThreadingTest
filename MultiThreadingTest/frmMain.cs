using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MultiThreadingTest
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private delegate void StartDelegate();
        private void Start()
        {
            if (InvokeRequired)
            {
                StartDelegate start = new StartDelegate(Start);
                Invoke(start, null);
            }
            else
            {
                tProgress.Start();
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            Start();
        }
        private delegate void StopDelegate();
        private void Stop()
        {
            if (InvokeRequired)
            {
                StopDelegate stop = new StopDelegate(Stop);
                Invoke(stop, null);
            }
            else
            {
                tProgress.Stop();
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }
        private delegate void tProgressTickDelegate();
        private void tProgressTick()
        {
            if (InvokeRequired)
            {
                tProgressTickDelegate tick = new tProgressTickDelegate(tProgressTick);
                Invoke(tick, null);
            }
            else
            {
                if (pbProgress.Value == pbProgress.Maximum)
                {
                    pbProgress.Value = pbProgress.Minimum;
                }
                else
                {
                    pbProgress.Value++;
                }
            }
        }
        private void tProgress_Tick(object sender, EventArgs e)
        {
            tProgressTick();
        }
    }
}
