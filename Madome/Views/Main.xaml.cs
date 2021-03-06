﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading;
using FFImageLoading.Config;
using Madome.Custom.Auth;
using Madome.Helpers;
using Madome.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Madome.Views {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Main : MasterDetailPage {

		public Main() {
			InitializeComponent();
			MasterPage.ListView.ItemSelected += ListView_ItemSelected;
		}

		private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
			var item = e.SelectedItem as MenuModel;
			if (item == null)
				return;

			var page = (Page)Activator.CreateInstance(item.TargetType);
			page.Title = item.Title;

			Detail = new NavigationPage(page);
			IsPresented = false;

			MasterPage.ListView.SelectedItem = null;
		}
	}
}
