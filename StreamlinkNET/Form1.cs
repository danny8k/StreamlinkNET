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

namespace StreamlinkNET
{
    public partial class Form1 : Form
    {
        public string VideoFiles = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\")) + "VideoFiles\\";
        public string StreamLinkLocation = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\")) + "StreamlinkPortable\\Streamlink.exe";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string streamLinkArguments = "twitch.tv/avoidingthepuddle";


            //System.Diagnostics.Process.Start("C:\\Users\\daniel.pastor\\Documents\\Streamlink_NET\\portable\\Streamlink.exe", streamLinkCmd);

            Process cmd = new Process();
            cmd.StartInfo.FileName = StreamLinkLocation;
            cmd.StartInfo.Arguments = streamLinkArguments;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("echo Oscar");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            string results = cmd.StandardOutput.ReadToEnd();

            DebugListView.View = View.Details;
            DebugListView.Items.Add(new ListViewItem(results));
            DebugListView.Refresh();


            //test video player
            string filePath = VideoFiles + "AP.mp4";
            MediaPlayer.URL = filePath;
            MediaPlayer.Ctlcontrols.play();
        }
    }
}
