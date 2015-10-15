﻿using ExtendedMap.Forms.Plugin.Abstractions;

using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TreeWatch
{
	public partial class MapContentPage : ContentPage
	{
		public MapContentPage ()
		{
			InitializeComponent ();

			BindingContext = new MapViewModel ();

			Title = "Map";
			if (Device.OS == TargetPlatform.iOS) {
				Icon = "MapTabBarIcon.png";
			}

			//configurations for navigation bar
			NavigationPage.SetBackButtonTitle (this, Title);

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

