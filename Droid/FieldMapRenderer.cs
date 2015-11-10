﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Maps.Android;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using TreeWatch.Droid;
using TreeWatch;

[assembly: ExportRenderer (typeof(FieldMap), typeof(FieldMapRenderer))]
namespace TreeWatch.Droid
{
	public class FieldMapRenderer : MapRenderer, IOnMapReadyCallback
	{
		MapView mapView;
		FieldMap myMap;

		new public GoogleMap Map { get; private set; }

		public event EventHandler MapReady;

		public FieldMapRenderer ()
		{
		}

		protected override void OnElementChanged (Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.View> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement == null) {

				mapView = Control as MapView;

				mapView.GetMapAsync (this);

				myMap = e.NewElement as FieldMap;

			}
		}

		public void addFields ()
		{
			PolygonOptions polygon = new PolygonOptions ();
			polygon.InvokeFillColor (myMap.OverLayColor.ToAndroid ());
			polygon.InvokeStrokeWidth (0);

			foreach (var Field in myMap.Fields) {

				foreach (var pos in Field.BoundingCordinates) {
					polygon.Add (new LatLng (pos.Latitude, pos.Longitude));
				}
				polygon.Add (new LatLng (Field.BoundingCordinates [0].Latitude, Field.BoundingCordinates [0].Longitude));

				Map.AddPolygon (polygon);
			}

		}
			
		public void OnMapReady(GoogleMap googleMap)
		{
			Map = googleMap;
			addFields ();
			Map.MapClick += MapClicked;
			var handler = MapReady;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		private void MapClicked(Object sender, GoogleMap.MapClickEventArgs e)
		{
			Console.WriteLine("Clicked map on Lat: {0} Lon: {1}", e.Point.Latitude, e.Point.Longitude);
		}
	}
		
}





