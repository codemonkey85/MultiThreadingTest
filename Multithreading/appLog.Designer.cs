namespace ThreadTestApplication
{
    partial class appLog
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
            this.txtLogConsole = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtLogConsole
            // 
            this.txtLogConsole.BackColor = System.Drawing.Color.Black;
            this.txtLogConsole.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLogConsole.ForeColor = System.Drawing.Color.Lime;
            this.txtLogConsole.Location = new System.Drawing.Point(0, 0);
            this.txtLogConsole.Multiline = true;
            this.txtLogConsole.Name = "txtLogConsole";
            this.txtLogConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogConsole.Size = new System.Drawing.Size(284, 211);
            this.txtLogConsole.TabIndex = 0;
            // 
            // appLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 211);
            this.Controls.Add(this.txtLogConsole);
            this.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "appLog";
            this.Text = "Log";
            this.Load += new System.EventHandler(this.appLog_Load);
            this.Resize += new System.EventHandler(this.appLog_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogConsole;
    }
}