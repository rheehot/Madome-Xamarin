﻿using System;
using System.Collections.Generic;
using Madome.ViewModels.Prepare;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Madome.Views.Prepare {

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SetHostPage : ContentPage {
		private SetHostViewModel viewModel;
		public SetHostPage() {
			InitializeComponent();
			viewModel = new SetHostViewModel();
			BindingContext = viewModel;
		}

		private void button_click(object sender, EventArgs args) {
			Navigation.PushAsync(new InputEmailPage(viewModel.Url));
		}
	}
}
