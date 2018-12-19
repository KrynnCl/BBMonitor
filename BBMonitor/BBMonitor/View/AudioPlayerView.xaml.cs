using BBMonitor.Model;
using BBMonitor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BBMonitor.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AudioPlayerView : ContentPage
	{
		public AudioPlayerView ()
		{
            InitializeComponent();
            BindingContext = new AudioPlayerViewModel(DependencyService.Get<IAudioPlayerService>());
        }
	}
}