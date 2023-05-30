using Microsoft.VisualBasic.Devices;
using OpenHardwareMonitor.Hardware;
using System.Diagnostics;
using System.IO.Ports;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;

namespace PC_State_Display_Control_Panel
{
    public partial class Form1 : Form
    {
        static Boolean running = true;
        static float[] cpuTemp = new float[8];
        static float cpuUsage;
        static float gpuTemp;
        static float gpuUsage;

        static object[] buadRateSet = { 300, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 74880, 115200, 230400, 250000, 500000, 1000000, 2000000 };
        static int buadRate;
        static string portMain;
        static int coreNum = 0;
        Thread thread = new Thread(run);


        static OpenHardwareMonitor.Hardware.Computer c = new OpenHardwareMonitor.Hardware.Computer()
        {
            GPUEnabled = true,
            CPUEnabled = true,
        };
        static SerialPort port = new SerialPort();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = "PC State Display";
            notifyIcon1.BalloonTipText = "OK";
            notifyIcon1.Text = "PC State Display";
            notifyIcon1.Icon = SystemIcons.Application;
            contextMenuStrip1.Items.Add("Open", null, this.MenuOpen_Click);
            contextMenuStrip1.Items.Add("Exit", null, this.MenuExit_Click);
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Visible = true;
            portMain = Properties.Settings.Default.port;
            buadRate = Properties.Settings.Default.buad_rate;
            comboBox1.Items.AddRange(getPortName());
            comboBox2.Items.AddRange(buadRateSet);
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(Properties.Settings.Default.port);
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf((int)Properties.Settings.Default.buad_rate);
            checkBox1.Checked = Properties.Settings.Default.auto_start;
            checkBox2.Checked = Properties.Settings.Default.auto_run;

            if (Properties.Settings.Default.auto_run == true)
            {
                thread.Start();
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
        }
        void MenuExit_Click(object sender, EventArgs e)
        {
            running = false;
            Application.Exit();
        }
        void MenuOpen_Click(object sender, EventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
        }
        static void ReportSystemInfo()
        {
            foreach (var hardware in c.Hardware)
            {
                if (hardware.HardwareType == HardwareType.CPU)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                        if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("CPU Core #1"))
                        {
                            cpuTemp[1] = (float)Math.Round((decimal)sensor.Value.GetValueOrDefault());
                        }
                        else if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("CPU Core #2"))
                        {
                            cpuTemp[2] = (float)Math.Round((decimal)sensor.Value.GetValueOrDefault());
                        }
                        else if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("CPU Core #3"))
                        {
                            cpuTemp[3] = (float)Math.Round((decimal)sensor.Value.GetValueOrDefault());
                        }
                        else if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("CPU Core #4"))
                        {
                            cpuTemp[4] = (float)Math.Round((decimal)sensor.Value.GetValueOrDefault());
                        }
                        else if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("CPU Core #5"))
                        {
                            cpuTemp[5] = (float)Math.Round((decimal)sensor.Value.GetValueOrDefault());
                        }
                        else if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("CPU Core #6"))
                        {
                            cpuTemp[6] = (float)Math.Round((decimal)sensor.Value.GetValueOrDefault());
                        }
                        else if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("CPU Core #7"))
                        {
                            cpuTemp[7] = (float)Math.Round((decimal)sensor.Value.GetValueOrDefault());
                        }
                        else if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("CPU Core #0"))
                        {
                            cpuTemp[0] = (float)Math.Round((decimal)sensor.Value.GetValueOrDefault());
                        }
                        else if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("CPU Total"))
                        {
                            cpuUsage = (float)Math.Round((decimal)sensor.Value.GetValueOrDefault());
                        }

                }
                if (hardware.HardwareType == HardwareType.GpuAti || hardware.HardwareType == HardwareType.GpuNvidia)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                        if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("GPU Core"))
                        {
                            gpuTemp = sensor.Value.GetValueOrDefault();
                        }
                        else if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("GPU Core"))
                        {
                            gpuUsage = sensor.Value.GetValueOrDefault();
                        }

                }
            }
        }
        static void sendInfo()
        {
            String cpuTempText, cpuUsageText, gpuTempText, gpuUsageText;
            float cpuTempAvg = (cpuTemp[1] + cpuTemp[2] + cpuTemp[3] + cpuTemp[4] + cpuTemp[5] + cpuTemp[6] + cpuTemp[7] + cpuTemp[0]) / coreNum;
            int cpuTempX = (int)Math.Round((float)cpuTempAvg);
            cpuTempText = 1000 + cpuTempX + "";
            cpuUsageText = 1000 + cpuUsage + "";
            gpuTempText = 1000 + gpuTemp + "";
            gpuUsageText = 1000 + gpuUsage + "";
            port.Write(cpuTempText + cpuUsageText + gpuTempText + gpuUsageText);
        }

        static void checkCore()
        {
            coreNum = 0;
            ReportSystemInfo();
            for (int i = 0; i < 8; i++)
            {
                if (cpuTemp[i] != 0)
                {
                    coreNum++;
                }
            }
            if (coreNum == 0)
            {
                coreNum = 1;
            }
        }
        static String[] getPortName()
        {
            SerialPort detectPort = new SerialPort();
            string[] ports = SerialPort.GetPortNames();
            return ports;
        }

        static public void run()
        {
            c.Open();
            checkCore();
            while (running)
            {
                ReportSystemInfo();
                try
                {
                    sendInfo();
                }
                catch (Exception ex)
                {
                    try
                    {
                        port.BaudRate = buadRate;
                        port.PortName = portMain;
                        port.Open();
                    }
                    catch (Exception e)
                    {

                    }


                }
                Thread.Sleep(1000);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //apply button
        {
            portMain = Properties.Settings.Default.port;
            buadRate = Properties.Settings.Default.buad_rate;
            try
            {
                port.Close();
                port.BaudRate = buadRate;
                port.PortName = portMain;
                port.Open();
            }
            catch (Exception ex)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)  //OK button
        {

            Properties.Settings.Default.auto_start = checkBox1.Checked;
            Properties.Settings.Default.buad_rate = Convert.ToInt32(comboBox2.Text);
            Properties.Settings.Default.port = comboBox1.Text;
            Properties.Settings.Default.auto_run = checkBox2.Checked;
            portMain = Properties.Settings.Default.port;
            buadRate = Properties.Settings.Default.buad_rate;
            try
            {
                port.Close();
                port.BaudRate = Properties.Settings.Default.buad_rate;
                port.PortName = Properties.Settings.Default.port;
                port.Open();
            }
            catch (Exception ex)
            {

            }

            if (!thread.IsAlive)
            {
                thread.Start();
            }
            Properties.Settings.Default.Save();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e) //cancel button
        {
            this.Hide();
        }

        private void update_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(getPortName());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.auto_start = checkBox1.CheckState.Equals(CheckState.Checked);
        }
    }
}