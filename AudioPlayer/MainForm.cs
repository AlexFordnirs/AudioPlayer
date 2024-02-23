using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;

namespace AudioPlayer
{
    public partial class MainForm : Form
    {
        IWavePlayer Wave;
        AudioFileReader Reader;
        Dictionary<string, string> TrackDictionary;
        Timer t;
        bool OnTrackBar;
        public MainForm()
        {
            InitializeComponent();
            Wave = new WaveOut();
            TrackDictionary = new Dictionary<string, string>();
            t = new Timer();
            t.Tick += TimerTick;
            t.Interval = 100;
            

        }
        private void TimerTick(object sender, EventArgs e)
        {
            if (OnTrackBar == true)
            {
                Reader.CurrentTime = new TimeSpan(0, 0, SongDuration.Value);
            }
            else if(OnTrackBar == false)
            {
                SongDuration.Value = Convert.ToInt32(Reader.CurrentTime.Seconds);
            }
        }
        private void PlayClick(object sender, EventArgs e)
        {
            try
            {
                string s = TrackDictionary.Values.ElementAt(TrackList.SelectedIndex);
                Reader = new AudioFileReader(s);
                Wave.Init(Reader);
                PauseBtn.Enabled = true;
                StopBtn.Enabled = true;
                PlayBtn.Enabled = false;
                Wave.Play();
                t.Start();
                SongDuration.Maximum = Convert.ToInt32(Reader.TotalTime.TotalSeconds);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Трэк не выбран или не соответсвует формату(mp3 , wav)");
            }

        }
        private void PauseClick(object sender, EventArgs e)
        {
            Wave.Pause();
            PauseBtn.Enabled = false;
            StopBtn.Enabled = false;
            PlayBtn.Enabled = true;
        }
        private void StopClick(object sender, EventArgs e)
        {
            Wave.Stop();
            if (Wave != null) Wave.Dispose();
            PauseBtn.Enabled = false;
            StopBtn.Enabled = false;
            PlayBtn.Enabled = true;
        }
        private void PrevClick(object sender, EventArgs e)
        {
            try
            {
                if (TrackList.Items.Count == 0)
                {
                    throw new InvalidOperationException();
                }
                if (TrackList.SelectedIndex - 1 < 0)
                {
                    TrackList.SelectedIndex = TrackList.Items.Count - 1;
                }
                else
                {
                    TrackList.SelectedIndex = TrackList.SelectedIndex - 1;
                }
            }
            catch
            {
                MessageBox.Show("Трэк-Лист пуст");
            }
        }
        private void NextClick(object sender, EventArgs e)
        {
            try
            {
                if (TrackList.SelectedIndex + 1 > TrackList.Items.Count - 1)
                {
                    TrackList.SelectedIndex = 0;
                }
                else
                {
                    TrackList.SelectedIndex = TrackList.SelectedIndex + 1;
                }
            }
            catch
            {
                MessageBox.Show("Трэк-Лист пуст");
            }
        }
        private void AddClick(object sender, EventArgs e)
        {
            OpenFileDialog Open = new OpenFileDialog();

            Open.Filter = "WAV (*.wav)|*.wav|MP3 (*.mp3)|*.mp3|Flac (*.flac)|*.flac";
            Open.FilterIndex = 2;
            Open.RestoreDirectory = true;

            string FilePath;

            if (Open.ShowDialog() == DialogResult.OK)
            {
                FilePath = Open.FileName;
                DirectoryInfo info = new DirectoryInfo(FilePath);
                try
                {
                    TrackDictionary.Add(info.Name, FilePath);
                    TrackList.Items.Add(TrackDictionary.Keys.ElementAt(TrackDictionary.Count - 1));
                }
                catch
                {
                    MessageBox.Show($"Песня с названием {info.Name} уже была добавлена ранее");
                }

            }
            TrackList.SelectedIndex = 0;
        }
        private void RemoveClick(object sender, EventArgs e)
        {
            TrackList.Items.RemoveAt(TrackList.SelectedIndex);
        }
        private void RandomClick(object sender, EventArgs e)
        {
            Random rand = new Random();
            int Num = rand.Next(0, TrackList.Items.Count);
            if (Num == TrackList.SelectedIndex)
            {
                Num = rand.Next(0, TrackList.Items.Count);
            }
            if (TrackList.Items.Count != 0)
            {
                TrackList.SelectedIndex = Num;
            }
            else
            {
                MessageBox.Show("Трэк-лист пуст");
            }
        }
        private void MouseDownEvent(object sender, MouseEventArgs e)
        {
            OnTrackBar = true;
        }
        private void MouseUpEvent(object sender, MouseEventArgs e)
        {
            OnTrackBar = false;
        }
    }
}
