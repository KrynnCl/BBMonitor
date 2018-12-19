using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BBMonitor.Model
{
    public class MenuModel
    {
        public string MenuTitle { get; set; }

        public string  MenuDetail { get; set; }

        public ImageSource   icon{ get; set; }

        public Page Pagina { get; set; }
    }
}
