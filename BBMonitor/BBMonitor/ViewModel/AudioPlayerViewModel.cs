using BBMonitor.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BBMonitor.ViewModel
{
    class AudioPlayerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _commandText;
        public string CommandText
        {
            get { return _commandText; }
            set
            {
                _commandText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CommandText"));
            }
        }

        private IAudioPlayerService _audioPlayer;
        private bool _isStopped;
       

        public AudioPlayerViewModel(IAudioPlayerService audioPlayer)
        {
            _audioPlayer = audioPlayer;
            _audioPlayer.OnFinishedPlaying = () => {
                _isStopped = true;
                CommandText = "Play";
            };
            CommandText = "Play";
            _isStopped = true;
        }

        private ICommand _playPauseCommand;
        public ICommand PlayPauseCommand
        {
            get
            {
                return _playPauseCommand ?? (_playPauseCommand = new Command(
                  (obj) =>
                  {
                      if (CommandText == "Play")
                      {
                          if (_isStopped)
                          {
                              _isStopped = false;
                              _audioPlayer.Play("DooblyDoo.mp3");
                          }
                          else
                          {
                              _audioPlayer.Play();
                          }
                          CommandText = "Pause";
                      }
                      else
                      {
                          _audioPlayer.Pause();
                          CommandText = "Play";
                      }
                  }));
            }
        }
    }
}
