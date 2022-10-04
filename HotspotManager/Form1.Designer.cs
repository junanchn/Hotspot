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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.hotspotTabPage = new System.Windows.Forms.TabPage();
            this.hotspotButtonConnect = new System.Windows.Forms.Button();
            this.hotspotCheckBoxAutoReconnect = new System.Windows.Forms.CheckBox();
            this.networkTabPage = new System.Windows.Forms.TabPage();
            this.networkCheckBoxAutoReconnect = new System.Windows.Forms.CheckBox();
            this.hotspotTabPage.SuspendLayout();
            this.networkTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 12000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.hotspotTabPage);
            this.tabControl.Controls.Add(this.networkTabPage);
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
            this.hotspotButtonConnect.Name = "hotspotButtonConnect0";
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
            this.hotspotCheckBoxAutoReconnect.Size = new System.Drawing.Size(120, 24);
            this.hotspotCheckBoxAutoReconnect.TabIndex = 11;
            this.hotspotCheckBoxAutoReconnect.Text = "保持热点开启";
            this.hotspotCheckBoxAutoReconnect.UseVisualStyleBackColor = true;
            this.hotspotCheckBoxAutoReconnect.CheckedChanged += new System.EventHandler(this.hotspotCheckBoxAutoReconnect_CheckedChanged);
            // 
            // networkTabPage
            // 
            this.networkTabPage.Controls.Add(this.networkCheckBoxAutoReconnect);
            this.networkTabPage.Name = "hotspotTabPage";
            this.networkTabPage.TabIndex = 2;
            this.networkTabPage.Text = "校园网";
            this.networkTabPage.UseVisualStyleBackColor = true;
            // 
            // networkCheckBoxAutoReconnect
            // 
            this.networkCheckBoxAutoReconnect.Location = new System.Drawing.Point(16, 16);
            this.networkCheckBoxAutoReconnect.Name = "networkCheckBoxAutoReconnect";
            this.networkCheckBoxAutoReconnect.Size = new System.Drawing.Size(120, 24);
            this.networkCheckBoxAutoReconnect.TabIndex = 20;
            this.networkCheckBoxAutoReconnect.Text = "自动重新拨号";
            this.networkCheckBoxAutoReconnect.UseVisualStyleBackColor = true;
            this.networkCheckBoxAutoReconnect.CheckedChanged += new System.EventHandler(this.networkCheckBoxAutoReconnect_CheckedChanged);
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
            this.tabControl.ResumeLayout(false);
            this.hotspotTabPage.ResumeLayout(false);
            this.hotspotTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private TabControl tabControl;
        private TabPage hotspotTabPage;
        private Button hotspotButtonConnect;
        private CheckBox hotspotCheckBoxAutoReconnect;
        private TabPage networkTabPage;
        private CheckBox networkCheckBoxAutoReconnect;
    }
}