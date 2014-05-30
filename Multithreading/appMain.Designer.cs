namespace ThreadTestApplication
{
    partial class appMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtThreadCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdRun = new System.Windows.Forms.Button();
            this.listThreads = new System.Windows.Forms.ListView();
            this.columnHeaderThreadID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderThreadAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblAvailableMemory = new System.Windows.Forms.Label();
            this.lblCPUusage = new System.Windows.Forms.Label();
            this.txtLogConsole = new System.Windows.Forms.TextBox();
            this.lincCopyright = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txtThreadCount
            // 
            this.txtThreadCount.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtThreadCount.Location = new System.Drawing.Point(93, 40);
            this.txtThreadCount.MaxLength = 2;
            this.txtThreadCount.Name = "txtThreadCount";
            this.txtThreadCount.Size = new System.Drawing.Size(26, 22);
            this.txtThreadCount.TabIndex = 0;
            this.txtThreadCount.Text = "5";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(10, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thread Count:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "MultiThread Test Application";
            // 
            // cmdRun
            // 
            this.cmdRun.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmdRun.Location = new System.Drawing.Point(123, 39);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(51, 26);
            this.cmdRun.TabIndex = 3;
            this.cmdRun.Text = "Run";
            this.cmdRun.UseVisualStyleBackColor = true;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // listThreads
            // 
            this.listThreads.BackColor = System.Drawing.Color.White;
            this.listThreads.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listThreads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderThreadID,
            this.columnHeaderThreadAction});
            this.listThreads.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listThreads.FullRowSelect = true;
            this.listThreads.GridLines = true;
            this.listThreads.HideSelection = false;
            this.listThreads.Location = new System.Drawing.Point(13, 70);
            this.listThreads.MultiSelect = false;
            this.listThreads.Name = "listThreads";
            this.listThreads.Size = new System.Drawing.Size(161, 212);
            this.listThreads.TabIndex = 4;
            this.listThreads.UseCompatibleStateImageBehavior = false;
            this.listThreads.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderThreadID
            // 
            this.columnHeaderThreadID.Text = "Thread ID";
            this.columnHeaderThreadID.Width = 89;
            // 
            // columnHeaderThreadAction
            // 
            this.columnHeaderThreadAction.Text = "Status";
            this.columnHeaderThreadAction.Width = 95;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblAvailableMemory
            // 
            this.lblAvailableMemory.AutoSize = true;
            this.lblAvailableMemory.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAvailableMemory.Location = new System.Drawing.Point(8, 293);
            this.lblAvailableMemory.Name = "lblAvailableMemory";
            this.lblAvailableMemory.Size = new System.Drawing.Size(79, 13);
            this.lblAvailableMemory.TabIndex = 5;
            this.lblAvailableMemory.Text = "0MB Available";
            // 
            // lblCPUusage
            // 
            this.lblCPUusage.AutoSize = true;
            this.lblCPUusage.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCPUusage.ForeColor = System.Drawing.Color.Black;
            this.lblCPUusage.Location = new System.Drawing.Point(120, 293);
            this.lblCPUusage.Name = "lblCPUusage";
            this.lblCPUusage.Size = new System.Drawing.Size(83, 13);
            this.lblCPUusage.TabIndex = 6;
            this.lblCPUusage.Text = "CPU Usage 0%";
            // 
            // txtLogConsole
            // 
            this.txtLogConsole.BackColor = System.Drawing.Color.White;
            this.txtLogConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogConsole.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLogConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtLogConsole.Location = new System.Drawing.Point(180, 40);
            this.txtLogConsole.Multiline = true;
            this.txtLogConsole.Name = "txtLogConsole";
            this.txtLogConsole.ReadOnly = true;
            this.txtLogConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogConsole.Size = new System.Drawing.Size(242, 243);
            this.txtLogConsole.TabIndex = 7;
            this.txtLogConsole.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLogConsole_KeyUp);
            // 
            // lincCopyright
            // 
            this.lincCopyright.AutoSize = true;
            this.lincCopyright.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lincCopyright.LinkColor = System.Drawing.Color.Blue;
            this.lincCopyright.Location = new System.Drawing.Point(285, 293);
            this.lincCopyright.Name = "lincCopyright";
            this.lincCopyright.Size = new System.Drawing.Size(126, 13);
            this.lincCopyright.TabIndex = 8;
            this.lincCopyright.TabStop = true;
            this.lincCopyright.Text = "seungmunj@gmail.com";
            this.lincCopyright.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lincCopyright_LinkClicked);
            // 
            // appMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 319);
            this.Controls.Add(this.lincCopyright);
            this.Controls.Add(this.txtLogConsole);
            this.Controls.Add(this.lblCPUusage);
            this.Controls.Add(this.lblAvailableMemory);
            this.Controls.Add(this.listThreads);
            this.Controls.Add(this.cmdRun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtThreadCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "appMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thread Test Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.appMain_FormClosing);
            this.Load += new System.EventHandler(this.appMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtThreadCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdRun;
        private System.Windows.Forms.ListView listThreads;
        private System.Windows.Forms.ColumnHeader columnHeaderThreadID;
        private System.Windows.Forms.ColumnHeader columnHeaderThreadAction;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblAvailableMemory;
        private System.Windows.Forms.Label lblCPUusage;
        private System.Windows.Forms.TextBox txtLogConsole;
        private System.Windows.Forms.LinkLabel lincCopyright;
    }
}

