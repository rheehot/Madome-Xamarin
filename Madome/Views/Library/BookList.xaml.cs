﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading;
using FFImageLoading.Config;
using Madome.Custom.Auth;
using Madome.Helpers;
using Madome.Struct;
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
			ImageService.Instance.Initialize(new Configuration {
				HttpClient = new HttpClient(
					new AuthHttpImageClientHandler(
						() => APIHelper.Instance.Token
					)
				)
			});
		}

		async void Handle_ItemTapped(object sender, ItemTappedEventArgs e) {
			if (e.Item == null)
				return;
			Book book = (Book)e.Item;
			await DisplayAlert("Item Tapped", book.Id.ToString(), "OK");

			//Deselect Item
			((ListView)sender).SelectedItem = null;
		}


		async void OnItemAppearing(object Sender, ItemVisibilityEventArgs e) {
			Book item = (Book)e.Item;
			if (!viewModel.IsRefreshing && item == viewModel.Books.Last())
				await viewModel.LoadingNext();
		}
	}
}
