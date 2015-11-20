﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System;

namespace TreeWatch
{
	public class InformationViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		Field field;

		public InformationViewModel (Field field)
		{
			this.field = field;
		}


		public string FieldName {
			get {
				return field.Name;
			}
		}

		public string FieldSize {
			get {
				return "0 qm";//GeoHelper.CalculateCenter(field.BoundingCoordinates)field.CalculateSize.ToString ();
			}
		}

		public string FieldBlockCount {
			get {
				return field.Blocks.Count.ToString ();
			}
		}

		protected void NavigateToBlocks (object sender, EventArgs e)
		{
			var customTabbedPage = (CustomTabbedPage)Application.Current.MainPage;
			var masterDetailPage = (MasterDetailPage)customTabbedPage.CurrentPage;
			var mapNavigationPage = (MapNavigationPage)masterDetailPage.Detail;

			mapNavigationPage.PushAsync (new BlockInformationContentPage (this));
		}

		protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler (this, new PropertyChangedEventArgs (propertyName));

		}
	}
}

