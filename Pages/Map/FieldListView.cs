using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace TreeWatch
{
	public class FieldListView : ListView
	{
		private List<Field> fields;

		public FieldListView ()
		{
			fields = new Fields ();

			var cell = new DataTemplate (typeof(TextCell));

			cell.SetBinding (TextCell.TextProperty, "Name");

			ItemTemplate = cell;

			ItemsSource = fields;
		}

		public void FilterLocations (string filter)
		{
			this.BeginRefresh ();

			if (string.IsNullOrWhiteSpace (filter)) {
				this.ItemsSource = fields;
			} else {
				this.ItemsSource = fields
					.Where (x => x.Name.ToLower ()
						.Contains (filter.ToLower ()));
			}

			this.EndRefresh ();
		}
	}
}

