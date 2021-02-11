using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using NAudio.Wave;
using Null.MciPlayer;

namespace AudioTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        enum PlayType
        { 
            SoundPlayer,
            MciCommand,
            NAudio,
        }
        readonly Dictionary<string, object> musics = new Dictionary<string, object>();
        void SyncListItems()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(musics.Keys.ToArray());
        }
        void PlayNewMusic(string path)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    SoundPlayer player = new SoundPlayer();
                    player.SoundLocation = path;

                    musics[path] = player;
                }
                else if (radioButton2.Checked)
                {
                    MciPlayer player = new MciPlayer(path);
                    player.Open();

                    musics[path] = player;
                }
                else if (radioButton3.Checked)
                {
                    WaveOut player = new WaveOut();
                    AudioFileReader fileReader = new AudioFileReader(path);
                    player.Init(fileReader);

                    musics[path] = player;
                }
                else
                {
                    MessageBox.Show("No play type checked.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SyncListItems();
            System.Media.SystemSounds.Beep.Play();
        }
        void PauseMusic(string path)
        {
            if (musics.TryGetValue(path, out object playerObj))
            {
                Type playerType = playerObj.GetType();
                
                if (playerType == typeof(SoundPlayer))
                {
                    SoundPlayer player = (SoundPlayer)playerObj;
                    player.Stop();
                }
                else if (playerType == typeof(MciPlayer))
                {
                    MciPlayer player = (MciPlayer)playerObj;
                    player.Pause();
                }
                else if (playerType == typeof(WaveOut))
                {
                    WaveOut player = (WaveOut)playerObj;
                    player.Pause();
                }
            }
        }
        void PlayMusic(string path)
        {
            if (musics.TryGetValue(path, out object playerObj))
            {
                Type playerType = playerObj.GetType();

                if (playerType == typeof(SoundPlayer))
                {
                    SoundPlayer player = (SoundPlayer)playerObj;
                    player.Play();
                }
                else if (playerType == typeof(MciPlayer))
                {
                    MciPlayer player = (MciPlayer)playerObj;
                    player.Play();
                }
                else if (playerType == typeof(WaveOut))
                {
                    WaveOut player = (WaveOut)playerObj;
                    player.Play();
                }
            }
        }
        void StopMusic(string path)
        {
            if (musics.TryGetValue(path, out object playerObj))
            {
                Type playerType = playerObj.GetType();

                if (playerType == typeof(SoundPlayer))
                {
                    SoundPlayer player = (SoundPlayer)playerObj;
                    player.Stop();
                }
                else if (playerType == typeof(MciPlayer))
                {
                    MciPlayer player = (MciPlayer)playerObj;
                    player.Stop();
                }
                else if (playerType == typeof(WaveOut))
                {
                    WaveOut player = (WaveOut)playerObj;
                    player.Stop();
                }
            }
        }
        void RemoveMusic(string path)
        {
            if (musics.TryGetValue(path, out object playerObj))
            {
                Type playerType = playerObj.GetType();

                if (playerType == typeof(SoundPlayer))
                {
                    SoundPlayer player = (SoundPlayer)playerObj;
                    player.Stop();
                    player.Dispose();
                }
                else if (playerType == typeof(MciPlayer))
                {
                    MciPlayer player = (MciPlayer)playerObj;
                    player.Pause();
                    player.Dispose();
                }
                else if (playerType == typeof(WaveOut))
                {
                    WaveOut player = (WaveOut)playerObj;
                    player.Pause();
                    player.Dispose();
                }

                musics.Remove(path);
                SyncListItems();
            }
        }
        void GetMusicLength(string path)
        {
            if (musics.TryGetValue(path, out object playerObj))
            {
                Type playerType = playerObj.GetType();

                if (playerType == typeof(SoundPlayer))
                {
                    SoundPlayer player = (SoundPlayer)playerObj;
                }
                else if (playerType == typeof(MciPlayer))
                {
                    MciPlayer player = (MciPlayer)playerObj;
                    MessageBox.Show(player.GetLength().ToString());
                }
                else if (playerType == typeof(WaveOut))
                {
                    WaveOut player = (WaveOut)playerObj;
                    //MessageBox.Show(player.Length);
                }
            }
        }
        void PlayMusicWait(string path)
        {
            if (musics.TryGetValue(path, out object playerObj))
            {
                Type playerType = playerObj.GetType();

                if (playerType == typeof(SoundPlayer))
                {
                    SoundPlayer player = (SoundPlayer)playerObj;
                    player.PlaySync();
                }
                else if (playerType == typeof(MciPlayer))
                {
                    MciPlayer player = (MciPlayer)playerObj;
                    player.PlayWait();
                }
                else if (playerType == typeof(WaveOut))
                {
                    //WaveOut player = (WaveOut)playerObj;
                    
                }
            }
        }
        void PlayMusicRepeat(string path)
        {
            if (musics.TryGetValue(path, out object playerObj))
            {
                Type playerType = playerObj.GetType();

                if (playerType == typeof(SoundPlayer))
                {
                    SoundPlayer player = (SoundPlayer)playerObj;
                    player.PlayLooping();
                }
                else if (playerType == typeof(MciPlayer))
                {
                    MciPlayer player = (MciPlayer)playerObj;
                    player.PlayRepeat();
                }
                else if (playerType == typeof(WaveOut))
                {
                    //WaveOut player = (WaveOut)playerObj;
                    //player.Play();
                }
            }
        }
        void SeekMusic(string path, int position)
        {
            if (musics.TryGetValue(path, out object playerObj))
            {
                Type playerType = playerObj.GetType();

                if (playerType == typeof(SoundPlayer))
                {
                    //SoundPlayer player = (SoundPlayer)playerObj;
                    //player.Stop();
                }
                else if (playerType == typeof(MciPlayer))
                {
                    MciPlayer player = (MciPlayer)playerObj;
                    player.Seek(position);
                }
                else if (playerType == typeof(WaveOut))
                {
                    //WaveOut player = (WaveOut)playerObj;
                    //player.Stop();
                }
            }
        }
        void SeekMusicToStart(string path)
        {
            if (musics.TryGetValue(path, out object playerObj))
            {
                Type playerType = playerObj.GetType();

                if (playerType == typeof(SoundPlayer))
                {
                    SoundPlayer player = (SoundPlayer)playerObj;
                    player.Stop();
                    player.Play();
                }
                else if (playerType == typeof(MciPlayer))
                {
                    MciPlayer player = (MciPlayer)playerObj;
                    player.SeekToStart();
                }
                else if (playerType == typeof(WaveOut))
                {
                    //WaveOut player = (WaveOut)playerObj;
                    //player.Stop();
                }
            }
        }
        void GetMusicPosition(string path)
        {
            if (musics.TryGetValue(path, out object playerObj))
            {
                Type playerType = playerObj.GetType();

                if (playerType == typeof(SoundPlayer))
                {
                    //SoundPlayer player = (SoundPlayer)playerObj;
                    //player.Stop();
                }
                else if (playerType == typeof(MciPlayer))
                {
                    MciPlayer player = (MciPlayer)playerObj;
                    MessageBox.Show(player.GetPosition().ToString());
                }
                else if (playerType == typeof(WaveOut))
                {
                    //WaveOut player = (WaveOut)playerObj;
                    //player.Stop();
                }
            }
        }
        void GetMusicMode(string path)
        {
            if (musics.TryGetValue(path, out object playerObj))
            {
                Type playerType = playerObj.GetType();

                if (playerType == typeof(MciPlayer))
                {
                    MciPlayer player = (MciPlayer)playerObj;
                    MessageBox.Show(player.GetState().ToString());
                }
                else if (playerType == typeof(WaveOut))
                {
                    WaveOut player = (WaveOut)playerObj;
                    MessageBox.Show(player.PlaybackState.ToString());
                }
            }
        }
        OpenFileDialog ofd = new OpenFileDialog();
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd == null) ofd = new OpenFileDialog();
            ofd.Filter = "Audio file|*.wav;*.mp3;|All file|*.*;";

            if (ofd.ShowDialog() != DialogResult.OK) return;

            if (musics.ContainsKey(ofd.FileName))
            {
                MessageBox.Show("Music already exists.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PlayNewMusic(ofd.FileName);
        }

        bool CheckStringItem(object obj, out string result)
        {
            result = null;
            if (obj == null || obj.GetType() != typeof(string))
                return false;

            result = (string)obj;
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckStringItem(listBox1.SelectedItem, out string path))
                RemoveMusic(path);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckStringItem(listBox1.SelectedItem, out string path))
                PlayMusic(path);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CheckStringItem(listBox1.SelectedItem, out string path))
                PauseMusic(path);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CheckStringItem(listBox1.SelectedItem, out string path))
                StopMusic(path);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (CheckStringItem(listBox1.SelectedItem, out string path))
                SeekMusicToStart(path);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (CheckStringItem(listBox1.SelectedItem, out string path))
                SeekMusic(path, trackBar1.Value);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (CheckStringItem(listBox1.SelectedItem, out string path))
                PlayMusicWait(path);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (CheckStringItem(listBox1.SelectedItem, out string path))
                GetMusicLength(path);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (CheckStringItem(listBox1.SelectedItem, out string path))
                GetMusicMode(path);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (CheckStringItem(listBox1.SelectedItem, out string path))
                GetMusicPosition(path);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (CheckStringItem(listBox1.SelectedItem, out string path))
                PlayMusicRepeat(path);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckStringItem(listBox1.SelectedItem, out string path))
            {
                if (musics.TryGetValue(path, out object playerObj))
                {
                    Type playerType = playerObj.GetType();

                    if (playerType == typeof(SoundPlayer))
                    {
                        SoundPlayer player = (SoundPlayer)playerObj;
                        
                        //player.Stop();
                    }
                    else if (playerType == typeof(MciPlayer))
                    {
                        MciPlayer player = (MciPlayer)playerObj;
                        int position = player.GetPosition(), length = player.GetLength();
                        positionLabel.Text = $"{player.GetPosition()} / {player.GetLength()}";
                        trackBar2.Maximum = length;
                        trackBar2.Value = position;
                    }
                    else if (playerType == typeof(WaveOut))
                    {
                        //WaveOut player = (WaveOut)playerObj;
                        //player.Stop();
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void trackBar2_MouseUp(object sender, MouseEventArgs e)
        {
            if (CheckStringItem(listBox1.SelectedItem, out string path))
            {
                if (musics.TryGetValue(path, out object playerObj))
                {
                    Type playerType = playerObj.GetType();

                    if (playerType == typeof(SoundPlayer))
                    {
                        //SoundPlayer player = (SoundPlayer)playerObj;

                        //player.Stop();
                    }
                    else if (playerType == typeof(MciPlayer))
                    {
                        MciPlayer player = (MciPlayer)playerObj;
                        player.Seek(trackBar2.Value);
                        player.Play();
                    }
                    else if (playerType == typeof(WaveOut))
                    {
                        //WaveOut player = (WaveOut)playerObj;
                        //player.Stop();
                    }
                }
            }
        }
    }
}
