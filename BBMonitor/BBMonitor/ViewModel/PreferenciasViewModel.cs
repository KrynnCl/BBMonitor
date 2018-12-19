using BBMonitor.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BBMonitor.ViewModel
{
    class PreferenciasViewModel: PreferenciasModel
    {
       

        public PreferenciasViewModel()
        {
            //TipoModo = Preferences.Get("TipoModo", 4);
            ModoParentCommand = new Command(ModoParent);
            ModoBabyCommand = new Command(ModoBaby);
            BorrarSeleccionCommand = new Command(BorrarSeleccion);
        }

        public Command ModoParentCommand { get; set; }

        public Command ModoBabyCommand { get; set; }

        public Command BorrarSeleccionCommand { get; set; }

        private void ModoParent()
        {
            TipoModo = 2;
            Preferences.Set("TipoModo", 2);
        }

        private void ModoBaby()
        {
            TipoModo = 1;
            Preferences.Set("TipoModo", 1);
        }

        private void BorrarSeleccion()
        {
            Preferences.Clear();
            TipoModo = 3;
        }
    }
}
