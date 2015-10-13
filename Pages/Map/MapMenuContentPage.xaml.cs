using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TreeWatch
{
	public partial class MapMenuContentPage : ContentPage
	{
		public MapMenuContentPage ()
		{
			InitializeComponent ();

			Title = "Settings";

			int rowCount = 5;
			RowDefinitionCollection rows = new RowDefinitionCollection();
			for (int i = 0; i < rowCount; i++) 
			{
				rows.Add(new RowDefinition { Height = GridLength.Auto });
			}


			Grid grid = new Grid
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions = rows,
				ColumnDefinitions = 
				{
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star)},
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star)}}
				};
			for(int i = 0; i < rowCount; i++)
			{
				grid.Children.Add(new Label
					{
						Text = "Layout " + i,
						FontSize = 25,
						HorizontalOptions = LayoutOptions.StartAndExpand
					}, 0, i);

				Switch switcher = new Switch
				{
					HorizontalOptions = LayoutOptions.End,
					VerticalOptions = LayoutOptions.CenterAndExpand
				};
				switcher.Toggled += switcher_Toggled;
				grid.Children.Add (switcher, 1, i);
			}
			Content = grid;
		}

		void switcher_Toggled(object sender, ToggledEventArgs e)
		{
			//TODO
		}
	}
}

