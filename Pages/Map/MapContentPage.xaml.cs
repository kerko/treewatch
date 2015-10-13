﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

#if __ANDROID__
using Xamarin.Forms.Maps;
#endif
namespace TreeWatch
{
	public partial class MapContentPage : ContentPage
	{
		public MapContentPage ()
		{
			InitializeComponent ();

			Title = "Map";
			if (Device.OS == TargetPlatform.iOS) {
				Icon = "MapTabBarIcon.png";
			}

			//configurations for navigation bar
			NavigationPage.SetBackButtonTitle (this, Title);

			#if __ANDROID__
			this.Content = new ExtendedMap ();
			#endif

			//action after a field is clicked
//			siteButton.Clicked += async (object sender, EventArgs e) => 
//			{
//				await this.Navigation.PushAsync(new OverlayContentPage());
//			};
		}
	}

	#if __ANDROID__
	public class ExtendedMap : Map
	{
		public ExtendedMap ()
		{

		}

		public ExtendedMap (MapSpan region) : base (region)
		{

		}
	}
	#endif
}

