using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using valorant_instalock.Classes;
using Timer = System.Timers.Timer;

namespace valorant_instalock
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Agent.SelectedAgent = Agent.GetAgentCoordinatesByName("brimstone");
        }

        Timer recognitionTimer = new Timer() { Interval = 300 };
        Timer valorantTimer = new Timer() { Interval = 5000 };

        public string MakeFirstCharUppercase(string input)
        => input.First().ToString().ToUpper() + String.Join("", input.Skip(1));

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            recognitionTimer.Elapsed += RecognitionTimer_Elapsed;
            valorantTimer.Elapsed += ValorantTimer_Elapsed;
            string[] agents = Agent.getAgents();
            foreach (string agent in agents)
            {
                lb_Agents.Items.Add(MakeFirstCharUppercase(agent));
            }
            lbl_SelectedAgent.Text = MakeFirstCharUppercase(Agent.GetAgentNameByCoordinates(Agent.SelectedAgent.X, Agent.SelectedAgent.Y));
        }

        private void ValorantTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Process.GetProcessesByName("VALORANT-Win64-Shipping").Length <= 0)
            {
                StopVoid(false);
            }
        }

        private void RecognitionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var coords = ImageRecognition.GetCoordinates(Properties.Resources.lockImage);
            if (coords != null)
            {
                StopVoid(true);
                MouseController.MoveAndLeftClick(Agent.SelectedAgent.X, Agent.SelectedAgent.Y);
                Thread.Sleep(10);
                for (int i = 0; i < 5; i++)
                {
                    MouseController.LeftClick();
                }
                MouseController.MoveAndLeftClick(coords.X, coords.Y);
                Thread.Sleep(10);
                for (int i = 0; i < 5; i++)
                {
                    MouseController.LeftClick();
                }
            }
        }

        private void lb_Agents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Agent.SelectedAgent = Agent.GetAgentCoordinatesByName(lb_Agents.SelectedItem.ToString().ToLower());
            lbl_SelectedAgent.Text = MakeFirstCharUppercase(Agent.GetAgentNameByCoordinates(Agent.SelectedAgent.X, Agent.SelectedAgent.Y));
        }

        private void btn_Start_Click(object sender, RoutedEventArgs e)
        {
            if (Process.GetProcessesByName("VALORANT-Win64-Shipping").Length > 0)
            {
                valorantTimer.Start();
                btn_Start.IsEnabled = false;
                btn_Stop.IsEnabled = true;
                lbl_Status.Text = "Watching the screen...";
                lbl_Status.Foreground = Brushes.ForestGreen;
                recognitionTimer.Start();
            }
            else MessageBox.Show("Please run Valorant before starting...");
        }

        private void StopVoid(bool isSuccessful)
        {
            valorantTimer.Stop();
            recognitionTimer.Stop();
            this.Dispatcher.Invoke(() =>
            {
                btn_Start.IsEnabled = true;
                btn_Stop.IsEnabled = false;
                if (!isSuccessful)
                {
                    lbl_Status.Text = "Stopped!";
                    lbl_Status.Foreground = Brushes.Red;
                }
                else
                {
                    lbl_Status.Text = "Selected and stopped...";
                    lbl_Status.Foreground = Brushes.CornflowerBlue;
                }
            });
        }

        private void btn_Stop_Click(object sender, RoutedEventArgs e)
        => StopVoid(false);
    }
}
