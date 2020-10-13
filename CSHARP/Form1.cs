using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ClickCounter
{
    public partial class ClickCounterView : Form
    {
        //Problem mit der Checkbox, wegen dem fistStart und weil es das als Änderung nimmt, wenn es beim Loaden ändert
        public bool firstStart = true;
        public string path_doc = "";

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public ClickCounterView()
        {
            InitializeComponent();
        }

        private void btnStopLogger_Click(object sender, EventArgs e)
        {
            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = "cmd.exe";
            p.WindowStyle = ProcessWindowStyle.Hidden;
            p.Arguments = @"/c taskkill /F /T /IM ClickCounter_Log.exe";
            Process.Start(p);

            MessageBox.Show("Stopped the logger!", "Stopped...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblStatus.Text = "Current status: not running...";
        }

        private void btnStartLogger_Click(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("ClickCounter_Log").Length > 0)
            {
                MessageBox.Show("The clickcounter already counts your clicks!", "Already working...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ProcessStartInfo p = new ProcessStartInfo();
                p.FileName = "cmd.exe";
                p.WindowStyle = ProcessWindowStyle.Hidden;
                p.Arguments = @"/c ClickCounter_Log.exe";
                Process.Start(p);
                MessageBox.Show("Started the logger!", "Started...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblStatus.Text = "Current status: running...";
            }
        }

        private void ClickCounterView_Load(object sender, EventArgs e)
        {
            //Color things...
            BackColor = Color.FromArgb(16, 30, 60);
            lblClose.Text = "\u2716";
            lblMinimize.Text = "\u23bd";
            lblMinimize.ForeColor = Color.FromArgb(204, 0, 0);
            panel1.BackColor = Color.FromArgb(68, 71, 78);
            lblClose.ForeColor = Color.FromArgb(204, 0, 0);
            ForeColor = Color.White;
            btnRefresh.BackColor = Color.FromArgb(68, 71, 78);
            btnStartLogger.BackColor = Color.FromArgb(68, 71, 78);
            btnStopLogger.BackColor = Color.FromArgb(68, 71, 78);
            btnResetClicks.BackColor = Color.FromArgb(68, 71, 78);

            try
            {
                btnRefresh.Image = Image.FromFile("img/btnRefresh_icon.png");
                btnRefresh.ImageAlign = ContentAlignment.MiddleRight;
                btnRefresh.TextAlign = ContentAlignment.MiddleLeft;

                Icon = new System.Drawing.Icon(@"img\icon.ico");

                string doc_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string path = doc_path + "\\ClickCounter";
                path_doc = doc_path;

                if (!System.IO.File.Exists(path + "\\settings.txt"))  //Datei settings.txt wurde noch nicht erstellt
                {
                    if (!Directory.Exists(path))  //Der Ordner CounterClicks existiert nicht
                    {
                        Directory.CreateDirectory(path);   //Erstellen CounterClicks Ordner
                    }
                    
                    StreamWriter sw = new StreamWriter(path + "\\settings.txt");  //Erster Start --> Autostart auf false setzen
                    sw.WriteLine("false");
                    sw.Close();
                    cbAutostart.Checked = false;
                }
                else  //Die Datei und der Ordner existieren schon --> nicht der erste Start
                {
                    StreamReader sr = new StreamReader(path + "\\settings.txt");
                    if (sr.ReadLine().Equals("true"))  //Autostart = true
                        cbAutostart.Checked = true;
                    else  //Autostart = false
                    {
                        cbAutostart.Checked = false;
                    }
                    sr.Close();
                }

                if(!System.IO.File.Exists(path + "\\click_stats.txt")) //Datei existiert noch nicht
                {
                    StreamWriter sw = new StreamWriter(path + "\\click_stats.txt");
                    //Weil erster Start, alle Werte auf 0
                    sw.WriteLine("0");
                    sw.WriteLine("0");
                    sw.Close();
                }

                string[] lines = System.IO.File.ReadAllLines(doc_path + "\\ClickCounter\\click_stats.txt");
                tbRight.Text = lines[0];
                tbLeft.Text = lines[1];
                lblStatus.Text = "Current status: running...";


                //Überprüfen, ob der Prozess schon gestartet wurde
                if (Process.GetProcessesByName("ClickCounter_Log").Length > 0)
                {
                    lblStatus.Text = "Current status: running...";
                }
                else
                {
                    lblStatus.Text = "Current status: not running...";
                }

            }
            catch(Exception)
            {
                MessageBox.Show("Something went wrong while reading data!");
            }

            firstStart = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string doc_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string[] lines = System.IO.File.ReadAllLines(doc_path + "\\ClickCounter\\click_stats.txt");
            tbRight.Text = lines[0];
            tbLeft.Text = lines[1];
            lblStatus.Text = "Current status: running...";

            if (Process.GetProcessesByName("ClickCounter_Log").Length > 0)
            {
                lblStatus.Text = "Current status: running...";
            }
            else
            {
                lblStatus.Text = "Current status: not running...";
            }
        }

        private void cbAutostart_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string doc_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string path = doc_path + "\\ClickCounter";
                StreamReader sr = new StreamReader(path + "\\settings.txt");
                string line = sr.ReadLine();
                sr.Close();
                if (line.Equals("false") && !firstStart)  //Der User möchte es beim Starten mitstarten lassen
                {
                    StreamWriter sw = new StreamWriter(path + "\\settings.txt");
                    sw.WriteLine("true");
                    sw.Close();

                    string source = Path.GetFullPath("ClickCounter_Log.exe");
                    string text = "ClickCounter";
                    string destination_path = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

                    //Verknüpfung erstellen
                    WshShell shell = new WshShell();
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(destination_path + "\\ClickCounterRun.lnk");

                    shortcut.Description = "ClickCounterRun";   // The description of the shortcut
                    shortcut.TargetPath = source;                 // The path of the file that will launch when the shortcut is run
                    shortcut.Save();

                    MessageBox.Show("Successfully!\nDon't forget to uncheck this box, before uninstalling the program!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (line.Equals("true") && !firstStart)
                {
                    System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\ClickCounterRun.lnk");
                    StreamWriter sw = new StreamWriter(path + "\\settings.txt");
                    sw.WriteLine("false");
                    sw.Close();
                    MessageBox.Show("Successfully!\nThe Program won't start with windows", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went totally wrong", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnResetClicks_Click(object sender, EventArgs e)
        {
            //First, stop the logger
            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = "cmd.exe";
            p.WindowStyle = ProcessWindowStyle.Hidden;
            p.Arguments = @"/c taskkill /F /T /IM ClickCounter_Log.exe";
            Process.Start(p);
            Thread.Sleep(1000);
            lblStatus.Text = "Current status: not running...";

            //Reset the clicks
            StreamWriter sw = new StreamWriter(path_doc + "\\ClickCounter\\click_stats.txt");
            sw.WriteLine("0");
            sw.WriteLine("0");
            sw.Close();

            //Restart the logger
            ProcessStartInfo ps = new ProcessStartInfo();
            ps.FileName = "cmd.exe";
            ps.WindowStyle = ProcessWindowStyle.Hidden;
            ps.Arguments = @"/c ClickCounter_Log.exe";
            Process.Start(ps);
            lblStatus.Text = "Current status: running...";
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblClose_DragOver(object sender, DragEventArgs e)
        {
            
        }

        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.ForeColor = Color.FromArgb(255, 0, 0);
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.ForeColor = Color.FromArgb(204, 0, 0);
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblMinimize_MouseEnter(object sender, EventArgs e)
        {
            lblMinimize.ForeColor = Color.FromArgb(255, 0, 0);
        }

        private void lblMinimize_MouseLeave(object sender, EventArgs e)
        {
            lblMinimize.ForeColor = Color.FromArgb(204, 0, 0);
        }
    }
}
