using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


using MediaPlayer;

namespace PlayerMusic
{
    public partial class Form1 : Form
    {
        MediaPlayer.MediaPlayer MediaPlayer;
        int vol;
        int indexnum;
        int total;
        int temp;
        bool formclosed;



        Thread thread;

        delegate void deleUpdate();

        public void thread_update()
        {
            deleUpdate deleupdate = new deleUpdate(positionUpdate);
        }

        

        public Form1()
        {
            InitializeComponent();
            MediaPlayer = new MediaPlayer.MediaPlayer();

            MediaPlayer.Volume = -1000;
            vol = MediaPlayer.Volume;
            label2.Text = vol.ToString();
            indexnum = 0;
            total = 0;
            temp = 0;
            formclosed = true;
            thread = new Thread(new ThreadStart(positionUpdate));
            //MediaPlayer.FileName = @"C:\Users\ojb00\OneDrive\바탕 화면\음악,노래\The Baits   Sunshine Girl.mp3";


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            formclosed = false;
            thread.Abort();
            Dispose();
        }


        delegate void threadDele();

        public void positionUpdate()
        {
            while (formclosed)
            {

                trackBar1.Invoke(new threadDele(trackPos));////////////error

            }
            
        }

        public void trackPos()
        {
            trackBar1.Maximum = (int)MediaPlayer.Duration;
            //if (checkBox1.Checked)  MediaPlayer.CurrentPosition = 30;
            if (trackBar1.Maximum == trackBar1.Value)
                if (checkBox1.Checked)
                {
                    MediaPlayer.CurrentPosition = 0.1;
                }

            trackBar1.Value = (int)MediaPlayer.CurrentPosition;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (MediaPlayer.PlayState == MPPlayStateConstants.mpPlaying||MediaPlayer.PlayState==MPPlayStateConstants.mpPaused)
            {
                MediaPlayer.Stop();
            }
            //MediaPlayer.Previous();
            if (indexnum == 1)
            {
                MediaPlayer.FileName = listView1.Items[total-1].SubItems[2].Text;
                label1.Text = listView1.Items[total-1].SubItems[1].Text;

                

                indexnum = total;
            }
            else
            {
                indexnum -= 1;
                MediaPlayer.FileName = listView1.Items[indexnum-1].SubItems[2].Text;
                label1.Text = listView1.Items[indexnum-1].SubItems[1].Text;


            }
            //threaStart();
            button5.Text = indexnum.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MediaPlayer.PlayState==MPPlayStateConstants.mpStopped || MediaPlayer.PlayState==MPPlayStateConstants.mpPaused)
            {
                MediaPlayer.Play();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MediaPlayer.Pause();
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (MediaPlayer.PlayState == MPPlayStateConstants.mpPlaying || MediaPlayer.PlayState == MPPlayStateConstants.mpPaused)
            {
                MediaPlayer.Stop();
            }
            //MediaPlayer.Next();
            if (indexnum >= total)
            {
                MediaPlayer.FileName = listView1.Items[0].SubItems[2].Text;
                label1.Text = listView1.Items[0].SubItems[1].Text;


                indexnum = 1;
            }
            else
            {
                indexnum += 1;
                MediaPlayer.FileName = listView1.Items[indexnum-1].SubItems[2].Text;
                label1.Text = listView1.Items[indexnum-1].SubItems[1].Text;


            }
            //threaStart();
            button5.Text = indexnum.ToString();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                total++;
                listView1.Items.Add(total.ToString());

                //listView1.Items.Add(openFileDialog1.SafeFileName);
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(openFileDialog1.SafeFileName);
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(openFileDialog1.FileName);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0) { }
            else
            {
                total--;
                indexnum = Convert.ToInt32(listView1.FocusedItem.SubItems[0].Text);
                listView1.Items[indexnum - 1].Remove();

                for (temp = indexnum; temp <= total; temp++)
                    listView1.Items[temp - 1].SubItems[0].Text = temp.ToString();
            }
            
        }
        /*
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        */
        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
            MediaPlayer.FileName = listView1.FocusedItem.SubItems[2].Text;


            //button5.Text = Convert.ToInt32(MediaPlayer.Duration).ToString();
            //trackBar1.Maximum = Convert.ToInt32(button5.Text);


            label1.Text = listView1.FocusedItem.SubItems[1].Text;
            indexnum = Convert.ToInt32(listView1.FocusedItem.SubItems[0].Text);

            if(thread.IsAlive==false)
                thread.Start();


            //positionUpdate();
            //thread = new Thread();

            //thread.Start();

            //button5.Text=listView1.FocusedItem.Index.ToString();
            //MediaPlayer.FileName = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text;
            //MediaPlayer.FileName = listView1.Items[listView1.SelectedItems[0].Index].SubItems[1].Text;
            //MediaPlayer.Play();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                MediaPlayer.AutoRewind = checkBox1.Checked;
                button5.Text = "true";
            }
            else
            {
                MediaPlayer.AutoRewind = checkBox1.Checked;
                button5.Text = "false";
            }
            /*
            temp = (int)MediaPlayer.Duration;
            button5.Text = temp.ToString();
            */
            //button5.Text = Convert.ToDouble(MediaPlayer.Duration).ToString();
            //button5.Text = MediaPlayer.CurrentPosition.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            vol+=100;
            if (vol >= 0)
                vol = 0;
            MediaPlayer.Volume = vol;
            label2.Text = vol.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            vol-=100;
            if (vol <= -10000)
                vol = -10000;
            MediaPlayer.Volume = vol;
            label2.Text = vol.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer.CurrentPosition = MediaPlayer.Duration * trackBar1.Value / trackBar1.Maximum;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


            button5.Text = Convert.ToInt32(MediaPlayer.Duration).ToString();
            trackBar1.Maximum = Convert.ToInt32(button5.Text);
 
        }

        
    }
}
