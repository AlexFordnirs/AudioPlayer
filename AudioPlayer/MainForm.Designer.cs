using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace AudioPlayer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Text = "Form1";
            //
            // TrackList
            //
            this.TrackList = new ListBox();
            this.TrackList.Location = new Point(300, 0);
            this.TrackList.Size = new Size(200, 400);
            this.TrackList.ScrollAlwaysVisible = true;
            //
            // AddBtn
            //
            this.AddBtn = new Button();
            this.AddBtn.Location = new Point(300, 400);
            this.AddBtn.Size = new Size(100, 50);
            this.AddBtn.Text = "ADD";
            this.AddBtn.Click += AddClick;
            //
            // RemoveBtn
            //
            this.RemoveBtn = new Button();
            this.RemoveBtn.Location = new Point(400, 400);
            this.RemoveBtn.Size = new Size(100, 50);
            this.RemoveBtn.Text = "Remove";
            this.RemoveBtn.Click += RemoveClick;
            //
            // PrevBtn
            //
            this.PrevBtn = new Button();
            this.PrevBtn.Location = new Point(0 , 400);
            this.PrevBtn.Text = "<";
            this.PrevBtn.Size = new Size(60, 50);
            this.PrevBtn.Click += PrevClick;
            //
            // PlayBtn
            //
            this.PlayBtn = new Button();
            this.PlayBtn.Location = new Point(60 , 400);
            this.PlayBtn.Text = "Play";
            this.PlayBtn.Size = new Size(60, 50);
            this.PlayBtn.Click += PlayClick;           
            //
            // PauseBtn
            //
            this.PauseBtn = new Button();
            this.PauseBtn.Location = new Point(120 , 400);
            this.PauseBtn.Text = "Pause";
            this.PauseBtn.Size = new Size(60, 50);
            this.PauseBtn.Enabled = false;
            this.PauseBtn.Click += PauseClick;
            //
            // StopBtn
            //
            this.StopBtn = new Button();
            this.StopBtn.Location = new Point(180 , 400);
            this.StopBtn.Text = "Stop";
            this.StopBtn.Size = new Size(60, 50);
            this.StopBtn.Enabled = false;
            this.StopBtn.Click += StopClick;
            //
            // NextBtn
            //
            this.NextBtn = new Button();
            this.NextBtn.Location = new Point(240 , 400);
            this.NextBtn.Text = ">";
            this.NextBtn.Size = new Size(60, 50);
            this.NextBtn.Click += NextClick;
            //
            // RandomBtn
            //
            this.RandomBtn = new Button();
            this.RandomBtn.Location = new Point(0 , 0);
            this.RandomBtn.Text = "Random Song";
            this.RandomBtn.Size = new Size(150, 50);
            this.RandomBtn.Click += RandomClick;
            //
            // ProgressBar
            //
            this.SongDuration = new TrackBar();
            this.SongDuration.Location = new Point(0, 350);
            this.SongDuration.Size = new Size(300, 10);
            this.SongDuration.MouseDown += MouseDownEvent;
            this.SongDuration.MouseUp += MouseUpEvent;
            
            //
            // SoundPlayer
            //
            this.Sound = new SoundPlayer();

            //
            // Controls
            //
            this.Controls.Add(SongDuration);
            this.Controls.Add(TrackList);
            this.Controls.Add(AddBtn);
            this.Controls.Add(RemoveBtn);
            this.Controls.Add(PrevBtn);
            this.Controls.Add(PlayBtn);
            this.Controls.Add(PauseBtn);
            this.Controls.Add(StopBtn);
            this.Controls.Add(NextBtn);
            this.Controls.Add(RandomBtn);
        }

      

        SoundPlayer Sound;
        ListBox TrackList;
        Button AddBtn, RemoveBtn , PrevBtn , PlayBtn , PauseBtn, StopBtn , NextBtn , RandomBtn;
        TrackBar SongDuration;
         

        #endregion
    }
}

