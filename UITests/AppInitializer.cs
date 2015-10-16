﻿using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TreeWatch.UITests
{
	public class AppInitializer
	{
		public static IApp StartApp (Platform platform)
		{
			if (platform == Platform.Android) {
				return ConfigureApp.Android.ApiKey("YOUR_API_KEY_HERE").StartApp ();
			}

			return ConfigureApp.iOS.StartApp ();
		}
	}
}

