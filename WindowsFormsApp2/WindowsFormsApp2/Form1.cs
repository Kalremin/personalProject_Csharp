using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.IO;

using VideoLibrary;
using NReco.VideoConverter;
using System.Net;
using System.ComponentModel;
using ProgressBar;

namespace YouMuEx_convert
{
    public partial class Form1 : Form
    {
        //bool errerCheck;
        //string url;
        string path;
        YouTube youTube = YouTube.Default;
        YouTubeVideo video;
        FFMpegConverter fFMpegConverter = new FFMpegConverter();
        Thread thread,thread2;
        //BackgroundWorker worker = new BackgroundWorker();
        //bool threadcheck=false;
        
  
        public Form1()
        {
            InitializeComponent();
            //if (Program.IsAdministrator() == true) this.Text += " (Administrator)";

            btn_confirm.Click += BtnConfirm_Click;
            btn_insertPath.Click += BtnInsert_Click;
            btn_confirmMp3.Click += BtnSound_download;

            //worker.WorkerSupportsCancellation = true;
            //worker.WorkerReportsProgress = true;
            //worker.ProgressChanged+=
            
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "None")
            { }
            else
            {
                progressBar1.Value = 0;
                progressBar1.Maximum = 1000;
                progressBar1.Minimum = 0;
                //thread.Start();
                //Down_percent();
                //thread.Abort();
                //progressBar1.Value = 100;
                //ProgressBar.UI.Start(this);
                //VideoDownFunc();
                //ProgressBar.UI.Stop();
                thread = new Thread(new ThreadStart(Down_percent));

                thread.Start();
                VideoDownFunc();
            }  
        }

        private void threadinvoke()
        {
            progressBar1.Invoke(new MethodInvoker(Down_percent));
        }

        delegate void ProgvarCall(int var);

        

        private void ProgValueSetting(int var)
        {
            if (File.Exists(comboBox1.Text + @"\" + video.FullName))
                progressBar1.Value = 1000;
            else
                progressBar1.Value = var;
        }

        private void BtnSound_download(object sender, EventArgs e)
        {
            if (comboBox1.Text == "None")
            { }
            else
            {
                progressBar1.Value = 0;
                progressBar1.Maximum = 1000;
                progressBar1.Minimum = 0;

                thread = new Thread(new ThreadStart(Down_percent));
                
                thread.Start();
                VideoDownFunc();

                fFMpegConverter.ConvertMedia(path,
                    path + ".mp3", "Mp3");
                File.Delete(path);
            }
        }


        private void BtnInsert_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            comboBox1.Items.Add(folderBrowserDialog1.SelectedPath);
            comboBox1.SelectedIndex += 1;
            
        }

        private void VideoDownFunc()
        {
            video = youTube.GetVideo(textBox1.Text);
            path = comboBox1.Text + @"\" + video.FullName;
            File.WriteAllBytes(path, video.GetBytes());
        }

        /*
        delegate void ShowDelegate(int percent);

        private void ShowProgress(int pct)
        {
            if (InvokeRequired)
            {
                ShowDelegate del = new ShowDelegate(ShowProgress);
                //또는 ShowDelegate del = p=> ShowProgress(p);
                Invoke(del, pct);
            }
            else
            {
                progressBar1.Value = pct;
            }
        }
        */

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        /*
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        */
        private void Down_percent()
        {
            //VideoDownFunc();
            for (int i = 0; i < 1000; i++)
            {
                progressBar1.Invoke(new ProgvarCall(ProgValueSetting), new object[] { i });
                //progressBar1.Value += 1;
            }

        }
    }
}
