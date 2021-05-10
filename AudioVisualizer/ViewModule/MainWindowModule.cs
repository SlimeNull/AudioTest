using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AudioVisualizer.ViewModule
{
    class MainWindowModule : INotifyPropertyChanged
    {
        public bool IsSaveFile { get; set; }
        public string Filename { get; set; }

        public bool IsRecording { get; set; }
        public bool IsPlaying { get; set; }

        public void OnPropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
