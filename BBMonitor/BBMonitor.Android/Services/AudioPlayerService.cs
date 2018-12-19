﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BBMonitor.Droid.Services;
using BBMonitor.Model;
using Xamarin.Forms;

[assembly: Dependency (typeof(AudioPlayerService))]

namespace BBMonitor.Droid.Services
{
    class AudioPlayerService : IAudioPlayerService
    {
        private MediaPlayer _mediaPlayer;
        public Action OnFinishedPlaying { get; set; }

        public AudioPlayerService()
        {
        }

        void MediaPlayer_Completion(object sender, EventArgs e)
        {
            OnFinishedPlaying?.Invoke();
        }

        public void Pause()
        {
            _mediaPlayer?.Pause();
        }

        public void Play(string pathToAudioFile)
        {
            if (_mediaPlayer != null)
            {
                _mediaPlayer.Completion -= MediaPlayer_Completion;
                _mediaPlayer.Stop();
            }

            var fullPath = pathToAudioFile;

            Android.Content.Res.AssetFileDescriptor afd = null;

            try
            {
                string[] assesss = Android.App.Application.Context.Assets.List(fullPath);
                afd = global::Android.App.Application.Context.Assets.OpenFd(fullPath);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error openfd: " + ex);
            }
            if (afd != null)
            {
                System.Diagnostics.Debug.WriteLine("Length " + afd.Length);
                if (_mediaPlayer == null)
                {
                    _mediaPlayer = new MediaPlayer();
                    _mediaPlayer.Prepared += (sender, args) =>
                    {
                        _mediaPlayer.Start();
                        _mediaPlayer.Completion += MediaPlayer_Completion;
                    };
                }

                _mediaPlayer.Reset();
                _mediaPlayer.SetVolume(1.0f, 1.0f);

                _mediaPlayer.SetDataSource(afd.FileDescriptor, afd.StartOffset, afd.Length);
                _mediaPlayer.PrepareAsync();
            }
        }

        public void Play()
        {
            _mediaPlayer?.Start();
        }
    }
}