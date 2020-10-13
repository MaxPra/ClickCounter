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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickCounter
{
    public partial class ClickCounterView : Form
    {
        public bool firstStart = true;
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
            try
            {
                btnRefresh.Image = Image.FromFile("img/btnRefresh_icon.png");
                btnRefresh.ImageAlign = ContentAlignment.MiddleRight;
                btnRefresh.TextAlign = ContentAlignment.MiddleLeft;

                Icon = new System.Drawing.Icon(@"img\icon.ico");

                string doc_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string path = doc_path + "\\ClickCounter";

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
    }
}
