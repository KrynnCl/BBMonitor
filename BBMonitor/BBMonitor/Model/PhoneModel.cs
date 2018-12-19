using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BBMonitor.Model
{
    public class PhoneModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        private int height;

        public int Height
        {
            get { return height; }
            set { height = value;
                OnPropertyChanged();
            }
            
        }

        private int width;

        public int Width
        {
            get { return width; }
            set {
                width = value;
                OnPropertyChanged();

            }
        }


    }
}
