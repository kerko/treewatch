﻿using System;
using System.Collections.Generic;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using TreeWatch;
using TreeWatch.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;
using Java.Security.Spec;
using Javax.Xml.Namespace;
using System.Security.Cryptography;
using Java.IO;
using System.IO;
using System.Xml;

[assembly: ExportRenderer (typeof(FieldMap), typeof(FieldMapRenderer))]
namespace TreeWatch.Droid
{
	public class FieldMapRenderer : MapRenderer, IOnMapReadyCallback
	{
		MapView mapView;
		FieldMap myMap;
		FieldHelper fieldHelper;

		public FieldMapRenderer ()
		{
			fieldHelper = FieldHelper.Instance;
			fieldHelper.FieldSelected += FieldSelected;
			XmlDocument coords = GetCoordsFromKml ();
		}

		new public GoogleMap Map { get; private set; }

		public event EventHandler MapReady;

		protected override void OnElementChanged (ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement == null)
			{

				mapView = Control as MapView;


				mapView.GetMapAsync (this);

				myMap = e.NewElement as FieldMap;
			}
		}

		public void AddFields ()
		{
			foreach (var Field in myMap.Fields)
			{
				if (Field.Blocks.Count != 0)
				{
					foreach (var block in Field.Blocks)
					{
						if (block.BoundingCoordinates.Count != 0 && block.BoundingCoordinates.Count >= 3)
						{
							Map.AddPolygon (GetPolygon (FieldMapRenderer.ConvertCoordinates (block.BoundingCoordinates), 
								(block.TreeType.ColorProp).ToAndroid ()));
						}
					}
				}

				if (Field.BoundingCoordinates.Count != 0 && Field.BoundingCoordinates.Count >= 3) {
					Map.AddPolygon (GetPolygon (FieldMapRenderer.ConvertCoordinates (Field.BoundingCoordinates),
						myMap.OverLayColor.ToAndroid (), myMap.BoundaryColor.ToAndroid()));
				}

				MarkerOptions marker = new MarkerOptions ();
				marker.SetTitle (Field.Name);
				marker.SetSnippet (string.Format ("Number of rows: {0}", Field.Blocks.Count));
				marker.SetPosition (new LatLng (GeoHelper.CalculateCenter (Field.BoundingCoordinates).Latitude, GeoHelper.CalculateCenter (Field.BoundingCoordinates).Longitude));
				marker.SetIcon (BitmapDescriptorFactory.FromResource (Resource.Drawable.location_marker));
				Map.AddMarker (marker);
			}
		}

		public PolygonOptions GetPolygon (Java.Util.ArrayList coordinates, Android.Graphics.Color color)
		{
			var polygonOptions = new PolygonOptions ();
			polygonOptions.InvokeFillColor (color);
			polygonOptions.InvokeStrokeWidth (0);
			polygonOptions.AddAll (coordinates);
			
			return polygonOptions;
		}

		public PolygonOptions GetPolygon(Java.Util.ArrayList cordinates, Android.Graphics.Color fillColor, Android.Graphics.Color boundaryColor)
		{
			var polygonOptions = new PolygonOptions ();
			polygonOptions.InvokeFillColor (fillColor);
			polygonOptions.InvokeStrokeWidth (4);
			polygonOptions.InvokeStrokeColor (boundaryColor);
			polygonOptions.AddAll (cordinates);

			return polygonOptions;
		}

		static Java.Util.ArrayList ConvertCoordinates (List<Position> coordinates)
		{
			var cords = new Java.Util.ArrayList ();
			foreach (var pos in coordinates)
			{
				cords.Add (new LatLng (pos.Latitude, pos.Longitude));
			}
			cords.Add (new LatLng (coordinates [0].Latitude, coordinates [0].Longitude));
			return cords;
		}

		public void OnMapReady (GoogleMap googleMap)
		{
			Map = googleMap;
			Map.SetInfoWindowAdapter (new FieldInfoWindow ());
			AddFields ();
			Map.MarkerClick += MarkerClicked;
			Map.MapClick += MapClicked;
			Map.InfoWindowClick += InfoWindowClicked;
			var handler = MapReady;
			if (handler != null)
				handler (this, EventArgs.Empty);
		}

		private void InfoWindowClicked (object sender, GoogleMap.InfoWindowClickEventArgs e)
		{
			Marker marker = e.Marker;
			Field field = null;
			foreach (Field f in myMap.Fields)
			{
				if (f.Name.Equals (e.Marker.Title))
				{
					field = f;
					break;
				}
			}
			if (field != null)
			{
				var navigationPage = (NavigationPage)Application.Current.MainPage;

				navigationPage.PushAsync (new FieldInformationContentPage (new InformationViewModel (field)));
			}
		}

		private void MapClicked (Object sender, GoogleMap.MapClickEventArgs e)
		{
			FieldHelper.Instance.FieldTappedEvent (new Position (e.Point.Latitude, e.Point.Longitude));
		}

		private void MarkerClicked (object sender, GoogleMap.MarkerClickEventArgs e)
		{
			e.Marker.ShowInfoWindow ();
		}

		private void FieldSelected (object sender, FieldSelectedEventArgs e)
		{
			if (Map != null)
			{
				LatLngBounds.Builder builder = new LatLngBounds.Builder ();
				GeoHelper.WidthHeight widthHeight = GeoHelper.CalculateWidthHeight (e.Field.BoundingCoordinates);
				Position middle = GeoHelper.CalculateCenter (e.Field.BoundingCoordinates);
				double w = widthHeight.Width / 1.9;//1.9 so 0.1 padding
				double h = widthHeight.Height / 1.9;
				builder.Include (new LatLng (middle.Latitude - w, middle.Longitude - h));
				builder.Include (new LatLng (middle.Latitude + w, middle.Longitude + h));
				LatLngBounds bounds = builder.Build ();
				Map.MoveCamera (CameraUpdateFactory.NewLatLngBounds (bounds, 0));
			}
		}

		private XmlDocument GetCoordsFromKml ()
		{
			XmlDocument doc = new XmlDocument ();
			try {

				string content;
				using(StreamReader sr = new StreamReader (Context.Assets.Open ("Karwei.kml")))
				{
					content = sr.ReadToEnd();
				}
				doc.LoadXml(content);

			} catch (Java.IO.IOException ex) {
				ex.PrintStackTrace();
				return null;
			}
			return doc;
		}
	}

}
