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

        private async void button1_Click(object sender, EventArgs e)
        {
            var connectionProfile = NetworkInformation.GetInternetConnectionProfile();
            var tetheringManager = NetworkOperatorTetheringManager.CreateFromConnectionProfile(connectionProfile);
            if (button1.Text == "开启热点")
            {
                switch (tetheringManager.TetheringOperationalState)
                {
                    case TetheringOperationalState.On:
                        button1.Text = "关闭热点";
                        break;
                    case TetheringOperationalState.Off:
                        button1.Text = "正在等待";
                        var result = await tetheringManager.StartTetheringAsync();
                        if (result.Status == TetheringOperationStatus.Success)
                            button1.Text = "关闭热点";
                        break;
                    case TetheringOperationalState.InTransition:
                        button1.Text = "正在等待";
                        break;
                    case TetheringOperationalState.Unknown:
                        button1.Text = "未知";
                        break;
                    default:
                        break;
                }
            }
            else if (button1.Text == "关闭热点")
            {
                switch (tetheringManager.TetheringOperationalState)
                {
                    case TetheringOperationalState.On:
                        button1.Text = "正在等待";
                        var result = await tetheringManager.StopTetheringAsync();
                        if (result.Status == TetheringOperationStatus.Success)
                            button1.Text = "开启热点";
                        break;
                    case TetheringOperationalState.Off:
                        button1.Text = "开启热点";
                        break;
                    case TetheringOperationalState.InTransition:
                        button1.Text = "正在等待";
                        break;
                    case TetheringOperationalState.Unknown:
                        button1.Text = "未知";
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
                        button1.Text = "关闭热点";
                        break;
                    case TetheringOperationalState.Off:
                        button1.Text = "开启热点";
                        break;
                    case TetheringOperationalState.InTransition:
                        button1.Text = "正在等待";
                        break;
                    case TetheringOperationalState.Unknown:
                        button1.Text = "未知";
                        break;
                    default:
                        break;
                }
            }
        }
    }
}