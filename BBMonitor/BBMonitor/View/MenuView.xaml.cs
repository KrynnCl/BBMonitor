using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BBMonitor.Model;

namespace BBMonitor.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuView : MasterDetailPage
	{
		public MenuView ()
		{
			InitializeComponent ();
            Detail = new NavigationPage(new SelectorModo());
            MyMenu();
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Model.MenuModel;
            if (menu != null)
            {
                IsPresented = false;
                Detail = new NavigationPage(menu.Pagina);
                
            }
        }
        public void MyMenu()
        {
            

            List<Model.MenuModel> menu = new List<Model.MenuModel>
            {
                new Model.MenuModel{Pagina = new AudioPlayerView(),MenuTitle="Padres",MenuDetail="Modo Padres",icon="children.png"},
                new Model.MenuModel{Pagina = new BabyView(),MenuTitle="Baby",MenuDetail="Modo Baby",icon="baby.png"},
                new Model.MenuModel{Pagina = new Configuracion(),MenuTitle="Configuracion",MenuDetail="Configuracion",icon="crayons.png"},

            };
            ListMenu.ItemsSource = menu;
        }
	}
}