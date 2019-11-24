﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madome.ViewModels.Library;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Madome.Views.Library {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookList : ContentPage {
		private readonly BookListViewModel viewModel;

		public BookList() {
			InitializeComponent();
			viewModel = new BookListViewModel();
			BindingContext = viewModel;

		}

		async void Handle_ItemTapped(object sender, ItemTappedEventArgs e) {
			if (e.Item == null)
				return;

			await DisplayAlert("Item Tapped", e.Item.ToString(), "OK");

			//Deselect Item
			((ListView)sender).SelectedItem = null;
		}

		async void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e) {
			var items = viewModel.Books;
			if (items != null && e.Item == items[items.Count - 1]){
				viewModel.RefreshCommand.Execute(null);
			}
		}
	}
}
