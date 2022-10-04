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
            if (button1.Text == "�����ȵ�")
            {
                switch (tetheringManager.TetheringOperationalState)
                {
                    case TetheringOperationalState.On:
                        button1.Text = "�ر��ȵ�";
                        break;
                    case TetheringOperationalState.Off:
                        button1.Text = "���ڵȴ�";
                        var result = await tetheringManager.StartTetheringAsync();
                        if (result.Status == TetheringOperationStatus.Success)
                            button1.Text = "�ر��ȵ�";
                        break;
                    case TetheringOperationalState.InTransition:
                        button1.Text = "���ڵȴ�";
                        break;
                    case TetheringOperationalState.Unknown:
                        button1.Text = "δ֪";
                        break;
                    default:
                        break;
                }
            }
            else if (button1.Text == "�ر��ȵ�")
            {
                switch (tetheringManager.TetheringOperationalState)
                {
                    case TetheringOperationalState.On:
                        button1.Text = "���ڵȴ�";
                        var result = await tetheringManager.StopTetheringAsync();
                        if (result.Status == TetheringOperationStatus.Success)
                            button1.Text = "�����ȵ�";
                        break;
                    case TetheringOperationalState.Off:
                        button1.Text = "�����ȵ�";
                        break;
                    case TetheringOperationalState.InTransition:
                        button1.Text = "���ڵȴ�";
                        break;
                    case TetheringOperationalState.Unknown:
                        button1.Text = "δ֪";
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
                        button1.Text = "�ر��ȵ�";
                        break;
                    case TetheringOperationalState.Off:
                        button1.Text = "�����ȵ�";
                        break;
                    case TetheringOperationalState.InTransition:
                        button1.Text = "���ڵȴ�";
                        break;
                    case TetheringOperationalState.Unknown:
                        button1.Text = "δ֪";
                        break;
                    default:
                        break;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.Text = "�����ȵ�";
            button1_Click(sender, e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
            timer1.Enabled = checkBox1.Checked;
        }
    }
}