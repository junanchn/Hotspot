using System.Diagnostics;
using System.Net.NetworkInformation;
using Windows.Networking.Connectivity;
using Windows.Networking.NetworkOperators;

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
            PingReply reply1 = pingSender.Send("202.97.224.68", 1000);
            if (!(reply1 != null && reply1.Status == IPStatus.Success))
            {
                PingReply reply2 = pingSender.Send("202.38.193.65", 1000);
                if (reply2 != null && reply2.Status == IPStatus.Success)
                {
                    var ps = new List<Process>();
                    ps.AddRange(Process.GetProcessesByName("DrMain"));
                    ps.AddRange(Process.GetProcessesByName("DrClient"));
                    ps.AddRange(Process.GetProcessesByName("DrUpdate"));
                    foreach (var p in ps)
                        p.Kill();
                    foreach (var p in ps)
                        p.WaitForExit(1000);
                    Process.Start("C:\\Drcom\\DrUpdateClient\\DrMain.exe");
                }
            }
        }

        private void networkCheckBoxAutoReconnect_CheckedChanged(object sender, EventArgs e)
        {
            if (networkCheckBoxAutoReconnect.Checked)
            {
                timer2_Tick(sender, e);
            }
            timer2.Enabled = networkCheckBoxAutoReconnect.Checked;
        }
    }
}