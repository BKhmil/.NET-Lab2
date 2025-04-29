using System.Diagnostics;

namespace Lab2
{
    public partial class Form1 : Form
    {
        private int processes = 0;   // лічильник для активних процесів
        private int exitedCount = 0; // лічильник для завершених процесів

        public Form1()
        {
            InitializeComponent();
        }

        // метод, що викликається при кліку на кнопку, після чого вона стає неактивною
        // береться значення з елементу numericUpDown_counter, яке в свою чергу передається
        // далі методу Run()
        private void startProcesses_Click(object sender, EventArgs e)
        {
            button_start.Enabled = false;
            this.Run((int)numericUpDown_counter.Value);
        }

        // метод приймає число, яке відповідає кількості процесів, необхідних для запуску
        // далі на основі цього запускаються самі процеси (WINWORD.EXE)
        private void Run(int N)
        {
            // пародія на валідацію
            if (N <= 0)
            {
                MessageBox.Show("Incorrect input");
                button_start.Enabled = true;
                return;
            }

            this.exitedCount = 0;          // обнуляю лічильник завершених процесів
            this.textBox_notify.Text = ""; // і також очищую TextBox від старого повідомлення

            for (int i = 0; i < N; ++i)
            {
                Process process = new Process();
                process.StartInfo.FileName = @"C:\Program Files\Microsoft Office\root\Office16\WINWORD.EXE";

                // аргумент, який потрібний при запуску, для того щоб можна було декілька інстансів ворду запускати
                // знайшов інформацію про це в ресурсі нижче
                // https://support.microsoft.com/en-us/office/command-line-switches-for-microsoft-office-products-079164cd-4ef5-4178-b235-441737deb3a6
                process.StartInfo.Arguments = "/w";
                process.EnableRaisingEvents = true; // вмикаю можливість відпрацювання івенту Process.Exited() після завершенні процесу
                process.Exited += Process_Exited;
                process.Start();  // запуск
                ++this.processes; // інкрементація лічильнику запущених процесів
            }
        }

        // безпосередньо метод, що відпрацьовує при завершенні процесу
        private void Process_Exited(object? sender, EventArgs e)
        {
            // метод викликається з контексту іншого потоку, головного потоку процесу, який викликав Process.Exited(), тому тут Invoke() 
            this.Invoke(() =>
            {
                ++exitedCount; // інкрментація лічильника завершених процесів
                //textBox_notify.AppendText($" |" + exitedCount + "| " + processes);

                // якщо завершились всі процеси - знову роблю доступною кнопку, обнуляю кількість активних процесів
                // і виводжу повідомлення про те, що всі процеси завершились
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
