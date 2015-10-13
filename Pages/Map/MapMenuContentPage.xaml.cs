using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TreeWatch
{
	public partial class MapMenuContentPage : ContentPage
	{
		private FieldListView list;
		private SearchBar searchbar;

		public MapMenuContentPage ()
		{
			InitializeComponent ();

			Title = "Menu";
			Icon = "HamburgerMenuIcon.png";

			list = new FieldListView ();
			list.ItemSelected += FieldSelected;

			searchbar = new SearchBar () {
				Placeholder = "Search",
			};

			searchbar.TextChanged += (sender, e) => list.FilterLocations (searchbar.Text);
			searchbar.SearchButtonPressed += (sender, e) => {
				list.FilterLocations (searchbar.Text);
			};

			var stack = new StackLayout () {
				Children = {
					searchbar,
					list
				}
			};

			Content = stack;
		}

		private void FieldSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
				return;
			var selected = (Field)e.SelectedItem;
			Console.WriteLine("selected field: {0}", selected.Name);
		}
	}
}

