﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BBMonitor.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ParentView : ContentPage
	{
		public ParentView ()
		{
			InitializeComponent ();
		}
	}
}