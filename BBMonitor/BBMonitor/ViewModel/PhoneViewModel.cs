using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace BBMonitor.ViewModel
{
    public class PhoneViewModel
    {
        private ScreenMetrics metrics;


     

        public PhoneViewModel()
        {
            metrics = DeviceDisplay.ScreenMetrics;
        }

        public double Width
        {
            get { return metrics.Width; }

        }

        public double Height
        {
            get { return metrics.Height; }
        }

        public string Rotation
        {
            get { return metrics.Rotation.ToString(); }
        }
    }

    
}
