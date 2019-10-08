﻿using System;
using System.Collections.Generic;
using Madome.ViewModels.Prepare;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Madome.Views.Prepare {

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SetHostPage : ContentPage {
		public SetHostPage() {
			InitializeComponent();
			BindingContext = new SetHostViewModel();
		}
	}
}
