using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AudioVisualizer.ViewModule
{
    public class MainWindowModule : INotifyPropertyChanged
    {
        public bool IsSaveFile;
        public string Filename;

        public bool IsRecording;
        public bool IsPlaying;
        public bool IsOffseting;

        public int RefreshInterval { get; set; }


        public void OnPropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
