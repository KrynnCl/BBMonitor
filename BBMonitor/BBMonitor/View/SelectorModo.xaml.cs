using BBMonitor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BBMonitor.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectorModo : ContentPage
	{
        PreferenciasViewModel contexto = new PreferenciasViewModel();
        
		public SelectorModo ()
		{
			InitializeComponent ();
            BindingContext = contexto;
            if (contexto.TipoModo == 2)
            {
                this.Navigation.PushModalAsync( new ParentView());
            }
            else if (contexto.TipoModo == 1)
            {
                this.Navigation.PushModalAsync(new BabyView());
            }
           


        }

       

        private void Button_Baby_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new BabyView()) ;
        }

        private void Button_Parents_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new ParentView());
        }
    }
}