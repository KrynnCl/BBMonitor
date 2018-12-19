using System;
using System.Collections.Generic;
using System.Text;

namespace BBMonitor.Model
{
   public interface IAudioPlayerService
    {
        void Play(string pathToAudioFile);
        void Play();
        void Pause();
        Action OnFinishedPlaying { get; set; }
    }
}
