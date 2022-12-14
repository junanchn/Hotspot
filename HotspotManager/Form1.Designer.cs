namespace HotspotManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.hotspotTabPage = new System.Windows.Forms.TabPage();
            this.hotspotButtonConnect = new System.Windows.Forms.Button();
            this.hotspotCheckBoxAutoReconnect = new System.Windows.Forms.CheckBox();
            this.networkTabPage = new System.Windows.Forms.TabPage();
            this.networkCheckBoxAutoReconnect = new System.Windows.Forms.CheckBox();
            this.networkCheckBoxUndergraduate = new System.Windows.Forms.CheckBox();
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.generalCheckBoxAutoStartUp = new System.Windows.Forms.CheckBox();
            this.generalCheckBoxMinimizeToTray = new System.Windows.Forms.CheckBox();
            this.generalCheckBoxTrayWhenStarted = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.hotspotTabPage.SuspendLayout();
            this.networkTabPage.SuspendLayout();
            this.generalTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Hotspot";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.hotspotTabPage);
            this.tabControl.Controls.Add(this.networkTabPage);
            this.tabControl.Controls.Add(this.generalTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.TabIndex = 0;
            // 
            // hotspotTabPage
            // 
            this.hotspotTabPage.Controls.Add(this.hotspotButtonConnect);
            this.hotspotTabPage.Controls.Add(this.hotspotCheckBoxAutoReconnect);
            this.hotspotTabPage.Name = "hotspotTabPage";
            this.hotspotTabPage.TabIndex = 1;
            this.hotspotTabPage.Text = "热点";
            this.hotspotTabPage.UseVisualStyleBackColor = true;
            // 
            // hotspotButtonConnect
            // 
            this.hotspotButtonConnect.Location = new System.Drawing.Point(16, 16);
            this.hotspotButtonConnect.Name = "hotspotButtonConnect";
            this.hotspotButtonConnect.Size = new System.Drawing.Size(96, 64);
            this.hotspotButtonConnect.TabIndex = 10;
            this.hotspotButtonConnect.Text = "开启热点";
            this.hotspotButtonConnect.UseVisualStyleBackColor = true;
            this.hotspotButtonConnect.Click += new System.EventHandler(this.hotspotButtonConnect_Click);
            // 
            // hotspotCheckBoxAutoReconnect
            // 
            this.hotspotCheckBoxAutoReconnect.Location = new System.Drawing.Point(16, 96);
            this.hotspotCheckBoxAutoReconnect.Name = "hotspotCheckBoxAutoReconnect";
            this.hotspotCheckBoxAutoReconnect.Size = new System.Drawing.Size(240, 24);
            this.hotspotCheckBoxAutoReconnect.TabIndex = 11;
            this.hotspotCheckBoxAutoReconnect.Text = "关闭后自动重开";
            this.hotspotCheckBoxAutoReconnect.UseVisualStyleBackColor = true;
            this.hotspotCheckBoxAutoReconnect.CheckedChanged += new System.EventHandler(this.hotspotCheckBoxAutoReconnect_CheckedChanged);
            // 
            // networkTabPage
            // 
            this.networkTabPage.Controls.Add(this.networkCheckBoxAutoReconnect);
            this.networkTabPage.Controls.Add(this.networkCheckBoxUndergraduate);
            this.networkTabPage.Name = "networkTabPage";
            this.networkTabPage.TabIndex = 2;
            this.networkTabPage.Text = "校园网";
            this.networkTabPage.UseVisualStyleBackColor = true;
            // 
            // networkCheckBoxAutoReconnect
            // 
            this.networkCheckBoxAutoReconnect.Location = new System.Drawing.Point(16, 16);
            this.networkCheckBoxAutoReconnect.Name = "networkCheckBoxAutoReconnect";
            this.networkCheckBoxAutoReconnect.Size = new System.Drawing.Size(240, 24);
            this.networkCheckBoxAutoReconnect.TabIndex = 20;
            this.networkCheckBoxAutoReconnect.Text = "掉线后自动重拨";
            this.networkCheckBoxAutoReconnect.UseVisualStyleBackColor = true;
            this.networkCheckBoxAutoReconnect.CheckedChanged += new System.EventHandler(this.networkCheckBoxAutoReconnect_CheckedChanged);
            // 
            // networkCheckBoxUndergraduate
            // 
            this.networkCheckBoxUndergraduate.Location = new System.Drawing.Point(16, 48);
            this.networkCheckBoxUndergraduate.Name = "networkCheckBoxUndergraduate";
            this.networkCheckBoxUndergraduate.Size = new System.Drawing.Size(240, 24);
            this.networkCheckBoxUndergraduate.TabIndex = 21;
            this.networkCheckBoxUndergraduate.Text = "周一至周五 0:00 至 6:00 不重拨";
            this.networkCheckBoxUndergraduate.UseVisualStyleBackColor = true;
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.generalCheckBoxAutoStartUp);
            this.generalTabPage.Controls.Add(this.generalCheckBoxMinimizeToTray);
            this.generalTabPage.Controls.Add(this.generalCheckBoxTrayWhenStarted);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.TabIndex = 3;
            this.generalTabPage.Text = "常规";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // generalCheckBoxAutoStartUp
            // 
            this.generalCheckBoxAutoStartUp.Location = new System.Drawing.Point(16, 16);
            this.generalCheckBoxAutoStartUp.Name = "generalCheckBoxAutoStartUp";
            this.generalCheckBoxAutoStartUp.Size = new System.Drawing.Size(240, 24);
            this.generalCheckBoxAutoStartUp.TabIndex = 30;
            this.generalCheckBoxAutoStartUp.Text = "开机自动启动";
            this.generalCheckBoxAutoStartUp.UseVisualStyleBackColor = true;
            this.generalCheckBoxAutoStartUp.CheckedChanged += new System.EventHandler(this.generalCheckBoxAutoStartUp_CheckedChanged);
            // 
            // generalCheckBoxMinimizeToTray
            // 
            this.generalCheckBoxMinimizeToTray.Location = new System.Drawing.Point(16, 48);
            this.generalCheckBoxMinimizeToTray.Name = "generalCheckBoxMinimizeToTray";
            this.generalCheckBoxMinimizeToTray.Size = new System.Drawing.Size(240, 24);
            this.generalCheckBoxMinimizeToTray.TabIndex = 31;
            this.generalCheckBoxMinimizeToTray.Text = "最小化到托盘，而不是任务栏";
            this.generalCheckBoxMinimizeToTray.UseVisualStyleBackColor = true;
            // 
            // generalCheckBoxTrayWhenStarted
            // 
            this.generalCheckBoxTrayWhenStarted.Location = new System.Drawing.Point(16, 80);
            this.generalCheckBoxTrayWhenStarted.Name = "generalCheckBoxTrayWhenStarted";
            this.generalCheckBoxTrayWhenStarted.Size = new System.Drawing.Size(240, 24);
            this.generalCheckBoxTrayWhenStarted.TabIndex = 32;
            this.generalCheckBoxTrayWhenStarted.Text = "启动时最小化到托盘";
            this.generalCheckBoxTrayWhenStarted.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 480);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.Text = "HotspotManager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.hotspotTabPage.ResumeLayout(false);
            this.networkTabPage.ResumeLayout(false);
            this.generalTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private NotifyIcon notifyIcon;
        private TabControl tabControl;
        private TabPage hotspotTabPage;
        private Button hotspotButtonConnect;
        private CheckBox hotspotCheckBoxAutoReconnect;
        private TabPage networkTabPage;
        private CheckBox networkCheckBoxAutoReconnect;
        private CheckBox networkCheckBoxUndergraduate;
        private TabPage generalTabPage;
        private CheckBox generalCheckBoxAutoStartUp;
        private CheckBox generalCheckBoxMinimizeToTray;
        private CheckBox generalCheckBoxTrayWhenStarted;
    }
}