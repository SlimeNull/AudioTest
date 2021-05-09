using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AudioVisualizer.ViewModule
{
    class MainWindowModule : INotifyPropertyChanged
    {
        public bool IsSaveFile { get; set; }

        public void OnPropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
