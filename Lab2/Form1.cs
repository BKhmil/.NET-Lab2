using System.Diagnostics;

namespace Lab2
{
    public partial class Form1 : Form
    {
        private int processes = 0;
        private int exitedCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void startProcesses_Click(object sender, EventArgs e)
        {
            button_start.Enabled = false;
            int value = (int)numericUpDown_counter.Value;
            this.Run(value);
        }

        private void Run(int N)
        {
            if (N <= 0)
            {
                MessageBox.Show("Incorrect input");
                button_start.Enabled = true;
                return;
            }

            this.exitedCount = 0;
            this.textBox_notify.Text = "";

            for (int i = 0; i < N; ++i)
            {
                Process process = new Process();
                process.StartInfo.FileName = @"C:\Program Files\Microsoft Office\root\Office16\WINWORD.EXE";
                // https://support.microsoft.com/en-us/office/command-line-switches-for-microsoft-office-products-079164cd-4ef5-4178-b235-441737deb3a6
                process.StartInfo.Arguments = "/w";
                process.EnableRaisingEvents = true;
                process.Exited += Process_Exited;
                process.Start();
                ++this.processes;
            }

        }

        private void Process_Exited(object? sender, EventArgs e)
        {
            this.Invoke(() =>
            {
                ++exitedCount;
                textBox_notify.AppendText($" |" + exitedCount + "| " + processes);

                if (exitedCount == processes)
                {
                    button_start.Enabled = true;
                    processes = 0;
                    textBox_notify.AppendText("All processes have exited");
                }
            });
        }
    }
}
