using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadTestApplication
{
    public partial class appMain : Form
    {
        private bool threadRunning;

        // Threads
        private Thread coreThread;
        private Thread[] threads;

        // Performance counter to measure CPU usage and Memory usage
        private System.Diagnostics.PerformanceCounter cpuCounter;
        private System.Diagnostics.PerformanceCounter ramCounter;

        // Delegates
        delegate void SetControlEnableCallback(Control control, bool boolean);
        delegate void SetTextCallback(Control control, string message);
        delegate void SetLogCallback(string message);

        // Available memory
        private float nFreeMemory;
        private float FreeMemory
        {
            get { return nFreeMemory; }
            set
            {
                nFreeMemory = value;
                this.lblAvailableMemory.Text = nFreeMemory + "MB Available";
            }
        }

        private int nCPUUsage;
        private int CPUUsage
        {
            get { return nCPUUsage; }
            set
            {
                nCPUUsage = value;
                this.lblCPUusage.Text = "CPU Usage " + nCPUUsage + "%";
            }
        }

        public appMain()
        {
            InitializeComponent();
            // Create a new instance of thread
            this.threads = new Thread[100];
        }

        private void appMain_Load(object sender, EventArgs e)
        {
            InitializeComponents();
        }

        private void appMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.Yes != MessageBox.Show(
                "Recent changes have not been saved.\r\nClose the application anyway?",
                "Close Application?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2))
            {
                e.Cancel = true;
            }
            else
            {
                if (this.threadRunning)
                    this.StopThread();
            }
        }

        private void InitializeComponents()
        {
            this.cpuCounter = new System.Diagnostics.PerformanceCounter();
            this.ramCounter = new System.Diagnostics.PerformanceCounter("Memory", "Available MBytes");

            this.cpuCounter.CategoryName = "Processor";
            this.cpuCounter.CounterName = "% Processor Time";
            this.cpuCounter.InstanceName = "_Total";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            FreeMemory = this.ramCounter.NextValue();
            CPUUsage = (int)this.cpuCounter.NextValue();
            this.lblCPUusage.Left = (this.lblAvailableMemory.Left + this.lblAvailableMemory.Width);
        }

        private void SetEnable(Control control, bool boolean)
        {
            if (control.InvokeRequired)
            {
                SetControlEnableCallback d = new SetControlEnableCallback(SetEnable);
                this.Invoke(d, new object[] { control, boolean });
            }
            else control.Enabled = boolean;
        }

        private void SetText(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { control, text });
            }
            else control.Text = text;
        }

        private void Log(string message)
        {
            if (this.txtLogConsole.InvokeRequired)
            {
                SetLogCallback d = new SetLogCallback(Log);
                this.Invoke(d, new object[] { message });
            }
            else
            {
                txtLogConsole.AppendText(Environment.NewLine + message);
                alignTextToBottom();
                scrollToBottom();
            }
        }

        private void cmdRun_Click(object sender, EventArgs e)
        {
            if (!threadRunning) {
                StartThread();
                this.cmdRun.Text = "Stop";
            }
            else
            {
                StopThread();
                this.cmdRun.Text = "Run";
            }
        }

        #region Threading
        private void StartThread()
        {
            // Make thread count text box and running button are disabled.
            this.txtThreadCount.Enabled = false;

            if (coreThread == null || coreThread.ThreadState != ThreadState.Suspended)
            {
                coreThread = new Thread(new ThreadStart(RunCoreThread));
                coreThread.Start();
            }

            // Update running threads
            RunThreads();
        }

        private void StopThread()
        {
            int threadCount = int.Parse(this.txtThreadCount.Text);

            threadRunning = false;
            Thread.Sleep(500);
            Log("The Core thread has been stopped.");
            try
            {
                if (coreThread.ThreadState == ThreadState.Suspended)
                {
                    coreThread.Resume();
                }
                coreThread.Abort();
            }
            catch (Exception) { }
            Monitor.Enter(this.listThreads);
            for (int i = 0; i < threadCount; i++)
            {
                try
                {
                    Thread thread = this.threads[i];
                    ListViewItem item = this.listThreads.Items[int.Parse(thread.Name)];
                    item.SubItems[1].Text = "Stop";
                    item.SubItems[1].ForeColor = Color.Red;
                    item.ImageIndex = 3;
                    item.UseItemStyleForSubItems = false;
                    if (thread != null && thread.IsAlive)
                    {
                        if (thread.ThreadState == ThreadState.Suspended)
                        {
                            thread.Resume();
                        }
                        thread.Abort();
                    }
                }
                catch (Exception) { }
            }
            Monitor.Exit(this.listThreads);

            this.txtThreadCount.Enabled = true;
        }

        private void RunCoreThread()
        {
            Log("The Core thread is running.");
            threadRunning = true;
            try
            {
                // Hi !
            }
            catch(Exception e)
            {
                return;
            }
        }

        private void RunThreads()
        {
            int threadCount = int.Parse(this.txtThreadCount.Text);
            Monitor.Enter(this.listThreads);
            try
            {
                // Create Threads
                for (int i = 0; i < threadCount; i++)
                {
                    if (threads[i] == null || threads[i].ThreadState != ThreadState.Suspended)
                    {
                        threads[i] = new Thread(new ThreadStart(ThreadRunningCallback));
                        threads[i].Name = String.Format("{0}", i.ToString());
                        Log("Thread[" + threads[i].Name + "] is ready for running.");
                        if (i == this.listThreads.Items.Count)
                        {
                            ListViewItem item = this.listThreads.Items.Add((i + 1).ToString(), 0);
                            string[] subItems = { "Ready" };
                            item.SubItems.AddRange(subItems);
                        }
                    }
                    else if (threads[i].ThreadState == ThreadState.Suspended)
                    {
                        ListViewItem item = this.listThreads.Items[i];
                        item.ImageIndex = 1;
                        item.SubItems[1].Text = "Resume";
                        threads[i].Resume();
                    }
                }
                // Start threads
                for (int i = 0; i < threadCount; i++)
                {
                    if (threads[i].ThreadState != ThreadState.Suspended)
                    {
                        ListViewItem item = this.listThreads.Items[i];
                        item.ImageIndex = 1;
                        item.SubItems[1].Text = "Running";
                        item.SubItems[1].ForeColor = Color.Green;
                        item.UseItemStyleForSubItems = false;
                        threads[i].Start();
                        Log("Thread[" + threads[i].Name + "] has been started.");
                    }
                }
            }
            catch (Exception) { }
            Monitor.Exit(this.listThreads);
        }

        int min = 0;
        int max = 100;

        private void ThreadRunningCallback()
        {
            int threadCount = int.Parse(this.txtThreadCount.Text);
            while (threadRunning && int.Parse(Thread.CurrentThread.Name) < threadCount)
            {
                // Running code
                Thread.Sleep(1 * 1000);
            }

            Monitor.Enter(this.listThreads);
            try
            {
                ListViewItem item = this.listThreads.Items[int.Parse(Thread.CurrentThread.Name)];
                if (threadRunning == false)
                {
                    item.SubItems[1].Text = "Stop";
                }
                item.ImageIndex = 0;
            }
            catch (Exception) { }
            Monitor.Exit(this.listThreads);
        }
        #endregion
        #region Log Console
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

        private void txtLogConsole_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLogConsole.AppendText(Environment.NewLine + txtLogConsole.Text);
                alignTextToBottom();
                scrollToBottom();
            }
        }
        #endregion

        private void lincCopyright_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "mailto:seungmunj@gmail.com?subject=Hi! Seung-mun :D&body=Hi there!\r\n";
            proc.Start();
        }

    }
}
