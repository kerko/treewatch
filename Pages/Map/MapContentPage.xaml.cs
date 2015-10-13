using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using ExtendedMap.Forms.Plugin.Abstractions;


namespace TreeWatch
{
	public partial class MapContentPage : ContentPage
	{
		public MapContentPage ()
		{
			InitializeComponent ();

			NavigationPage.SetBackButtonTitle (this, "Back");

			BindingContext = new MapViewModel ();

			//configurations for navigation bar
			NavigationPage.SetBackButtonTitle (this, Title);
			Title = "Map";
//			ToolbarItems.Add(new ToolbarItem {
//				Text = "Launch",
////				Icon = "Launch.png",
//				Order = ToolbarItemOrder.Primary,
//				Command = new Command(() => Navigation.PushAsync(new MapMasterDetailPage()))
//			});

			this.Content = CreateMapContentView ();
		}

		View CreateMapContentView ()
		{
			//Coordinates for the starting point of the map

			MapViewModel model = (MapViewModel)BindingContext;
			Position location = model.getCurrentDevicePosition ();

			var _map = new ExtendedMap.Forms.Plugin.Abstractions.ExtendedMap (MapSpan.FromCenterAndRadius (location, Distance.FromKilometers (1))) { IsShowingUser = true };

			_map.MapType = MapType.Hybrid;

			_map.BindingContext = BindingContext;

			var createMapContentView = new CustomMapContentView (_map);

			return createMapContentView;
		}
	}
}

