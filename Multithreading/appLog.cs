using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadTestApplication
{
    public partial class appLog : Form
    {
        public appLog()
        {
            InitializeComponent();
        }

        private void appLog_Load(object sender, EventArgs e)
        {

        }

        private void appLog_Resize(object sender, EventArgs e)
        {
            this.txtLogConsole.Width = this.Width;
            this.txtLogConsole.Height = this.Height - 38;
        }

        private void alignTextToBottom()
        {
            int visibleLines = (int)(txtLogConsole.Height / txtLogConsole.Font.GetHeight()) - 1;
            if (visibleLines > txtLogConsole.Lines.Length)
            {
                int emptyLines = (visibleLines - txtLogConsole.Lines.Length);
                for (int i = 0; i < emptyLines; i++)
                {
                    txtLogConsole.Text = (Environment.NewLine + txtLogConsole.Text);
                }
            }
        }

        private void scrollToBottom()
        {
            txtLogConsole.SelectionStart = txtLogConsole.Text.Length;
            txtLogConsole.ScrollToCaret();
        }

        public string log
        {
            get { return txtLogConsole.Text;  }
            set {
                txtLogConsole.AppendText(Environment.NewLine + value);
                alignTextToBottom();
                scrollToBottom();
            }
        }
    }
}
