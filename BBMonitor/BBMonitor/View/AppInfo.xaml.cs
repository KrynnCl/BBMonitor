using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using BBMonitor.ViewModel;

namespace BBMonitor.View
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppInfo : ContentPage
	{
       
        private string problema;

        PhoneViewModel contexto = new PhoneViewModel();

        public string Problema
        {
            get { return problema; }
            set { problema = value;
            }
        }

        public AppInfo ()
		{
            Problema = "Tiki Taka";
            InitializeComponent ();
            BindingContext = contexto;            
		}

        private void Button_Pressed(object sender, EventArgs e)
        {
            Xamarin.Essentials.AppInfo.OpenSettings();
        }



        private async void Button_Pressed_1Async(object sender, EventArgs e)
        {
            try
            {
                // Turn On
                Problema = "Anted de apretar el boton";
                await Flashlight.TurnOnAsync();

                // Turn Off
                //await Flashlight.TurnOffAsync();
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Problema = fnsEx.ToString();// Handle not supported on device exception
            }
            catch (PermissionException pEx)
            {
                Problema = pEx.ToString();// Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to turn on/off flashlight
                Problema = ex.ToString();
                
            }
        }
    }
}