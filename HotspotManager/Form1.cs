using System.Configuration;
using System.Diagnostics;
using System.Net.NetworkInformation;
using Windows.Networking.Connectivity;
using Windows.Networking.NetworkOperators;
using Microsoft.Win32.TaskScheduler;

namespace HotspotManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void hotspotButtonConnect_Click(object sender, EventArgs e)
        {
            var connectionProfile = NetworkInformation.GetInternetConnectionProfile();
            var tetheringManager = NetworkOperatorTetheringManager.CreateFromConnectionProfile(connectionProfile);
            if (hotspotButtonConnect.Text == "开启热点")
            {
                switch (tetheringManager.TetheringOperationalState)
                {
                    case TetheringOperationalState.On:
                        hotspotButtonConnect.Text = "关闭热点";
                        break;
                    case TetheringOperationalState.Off:
                        hotspotButtonConnect.Text = "正在等待";
                        var result = await tetheringManager.StartTetheringAsync();
                        if (result.Status == TetheringOperationStatus.Success)
                            hotspotButtonConnect.Text = "关闭热点";
                        break;
                    case TetheringOperationalState.InTransition:
                        hotspotButtonConnect.Text = "正在等待";
                        break;
                    case TetheringOperationalState.Unknown:
                        hotspotButtonConnect.Text = "未知";
                        break;
                    default:
                        break;
                }
            }
            else if (hotspotButtonConnect.Text == "关闭热点")
            {
                switch (tetheringManager.TetheringOperationalState)
                {
                    case TetheringOperationalState.On:
                        hotspotButtonConnect.Text = "正在等待";
                        var result = await tetheringManager.StopTetheringAsync();
                        if (result.Status == TetheringOperationStatus.Success)
                            hotspotButtonConnect.Text = "开启热点";
                        break;
                    case TetheringOperationalState.Off:
                        hotspotButtonConnect.Text = "开启热点";
                        break;
                    case TetheringOperationalState.InTransition:
                        hotspotButtonConnect.Text = "正在等待";
                        break;
                    case TetheringOperationalState.Unknown:
                        hotspotButtonConnect.Text = "未知";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (tetheringManager.TetheringOperationalState)
                {
                    case TetheringOperationalState.On:
                        hotspotButtonConnect.Text = "关闭热点";
                        break;
                    case TetheringOperationalState.Off:
                        hotspotButtonConnect.Text = "开启热点";
                        break;
                    case TetheringOperationalState.InTransition:
                        hotspotButtonConnect.Text = "正在等待";
                        break;
                    case TetheringOperationalState.Unknown:
                        hotspotButtonConnect.Text = "未知";
                        break;
                    default:
                        break;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            hotspotButtonConnect.Text = "开启热点";
            hotspotButtonConnect_Click(sender, e);
        }

        private void hotspotCheckBoxAutoReconnect_CheckedChanged(object sender, EventArgs e)
        {
            if (hotspotCheckBoxAutoReconnect.Checked)
            {
                timer1_Tick(sender, e);
            }
            timer1.Enabled = hotspotCheckBoxAutoReconnect.Checked;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (networkCheckBoxUndergraduate.Checked)
            {
                switch (DateTime.Now.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Wednesday:
                    case DayOfWeek.Thursday:
                    case DayOfWeek.Friday:
                        if(DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 6)
                            return;
                        break;
                }
            }
            var pingSender = new Ping();
            var ping = (string ip) =>
            {
                var reply = pingSender.Send(ip, 1000);
                return reply != null && reply.Status == IPStatus.Success;
            };
            if (!ping("222.201.130.30") && !ping("222.201.130.33") && ping("202.38.193.65"))
            {
                if (Process.GetProcessesByName("DrMain").Length == 0)
                {
                    Process.Start("C:\\Drcom\\DrUpdateClient\\DrMain.exe");
                }
                WindowUtility.ClickProcessButton("DrClient", "注销");
                WindowUtility.ClickProcessButton("DrClient", "登录");
            }
            WindowUtility.ClickProcessButton("DrClient", "确定");
        }

        private void networkCheckBoxAutoReconnect_CheckedChanged(object sender, EventArgs e)
        {
            if (networkCheckBoxAutoReconnect.Checked)
            {
                timer2_Tick(sender, e);
            }
            timer2.Enabled = networkCheckBoxAutoReconnect.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                hotspotCheckBoxAutoReconnect.Checked = appSettings["hotspotCheckBoxAutoReconnect"] == "True";
                networkCheckBoxAutoReconnect.Checked = appSettings["networkCheckBoxAutoReconnect"] == "True";
                networkCheckBoxUndergraduate.Checked = appSettings["networkCheckBoxUndergraduate"] == "True";
                generalCheckBoxAutoStartUp.Checked = appSettings["generalCheckBoxAutoStartUp"] == "True";
                generalCheckBoxMinimizeToTray.Checked = appSettings["generalCheckBoxMinimizeToTray"] == "True";
                generalCheckBoxTrayWhenStarted.Checked = appSettings["generalCheckBoxTrayWhenStarted"] == "True";
            }
            catch (ConfigurationErrorsException)
            {
                Debug.WriteLine("Error reading app settings");
            }
            if (generalCheckBoxTrayWhenStarted.Checked)
            {
                Visible = false;
                ShowInTaskbar = false;
                notifyIcon.Visible = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Dictionary<string, string> settings = new Dictionary<string, string>();
                settings.Add("hotspotCheckBoxAutoReconnect", hotspotCheckBoxAutoReconnect.Checked.ToString());
                settings.Add("networkCheckBoxAutoReconnect", networkCheckBoxAutoReconnect.Checked.ToString());
                settings.Add("networkCheckBoxUndergraduate", networkCheckBoxUndergraduate.Checked.ToString());
                settings.Add("generalCheckBoxAutoStartUp", generalCheckBoxAutoStartUp.Checked.ToString());
                settings.Add("generalCheckBoxMinimizeToTray", generalCheckBoxMinimizeToTray.Checked.ToString());
                settings.Add("generalCheckBoxTrayWhenStarted", generalCheckBoxTrayWhenStarted.Checked.ToString());

                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                foreach (var pair in settings)
                {
                    if (config.AppSettings.Settings[pair.Key] == null)
                    {
                        config.AppSettings.Settings.Add(pair.Key, pair.Value);
                    }
                    else
                    {
                        config.AppSettings.Settings[pair.Key].Value = pair.Value;
                    }
                }
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Debug.WriteLine("Error writing app settings");
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                if (generalCheckBoxMinimizeToTray.Checked)
                {
                    Visible = false;
                    ShowInTaskbar = false;
                    notifyIcon.Visible = true;
                }
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            notifyIcon.Visible = false;
            Visible = true;
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        private void generalCheckBoxAutoStartUp_CheckedChanged(object sender, EventArgs e)
        {
            TaskService ts = new TaskService();

            if (generalCheckBoxAutoStartUp.Checked)
            {
                if (ts.FindTask("Hotspot", false) != null)
                    return;
                TaskDefinition td = ts.NewTask();
                td.Triggers.Add(new LogonTrigger());
                td.Actions.Add(new ExecAction(Application.ExecutablePath));
                ts.RootFolder.RegisterTaskDefinition("Hotspot", td);
            }
            else
            {
                ts.RootFolder.DeleteTask("Hotspot", false);
            }
        }
    }
}