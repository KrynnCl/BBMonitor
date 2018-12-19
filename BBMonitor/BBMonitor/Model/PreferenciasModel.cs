using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;

namespace BBMonitor.Model
{
    /// <summary>
    /// Clases donde se almacenan las preferencias o configuraciones de la aplicacion de manera persistente.
    /// </summary>
    public class PreferenciasModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }


        private int tipoModo;
        /// <summary>
        /// Tipo Modo es el modo de uso de la aplicacion, 3= Nada, 1 = Baby, 2= Parent,
        /// con esta variable podras saber cual fue la ultima configuracion seleccionada.
        /// </summary>
        public int TipoModo
        {
            get { return Preferences.Get("TipoModo", 3); }

            set { tipoModo = value;                
                Preferences.Set("TipoModo", tipoModo);
                OnPropertyChanged();
            }
        }

  
    }
}