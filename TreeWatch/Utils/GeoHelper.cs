﻿using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace TreeWatch
{
	public static class GeoHelper
	{
		public static Boolean isInsideCoords(List<Position> coords, Position position){
			Position p1, p2;
			int i, j;
			int nvert = coords.Count;

			bool inside = false;

			if (coords.Count < 3)
			{
				return inside;
			}

			for (i = 0, j = nvert - 1; i < nvert; j = i++)
			{
				if (((coords[i].Latitude > position.Latitude) != (coords[j].Latitude > position.Latitude)) &&
					(position.Longitude < (coords[j].Longitude - coords[i].Longitude) * (position.Latitude - coords[i].Latitude) / (coords[j].Latitude - coords[i].Latitude) + coords[i].Longitude))
					inside = !inside; 
			}
			return inside;

				/*
				if (pos.Longitude > oldPos.Longitude) {
					p1 = oldPos;
					p2 = pos;

				} else {
					p1 = pos;
					p2 = oldPos;
				}

				if ((pos.Longitude < position.Longitude) == (position.Longitude <= oldPos.Longitude)
				    && (pos.Latitude - (long)p1.Latitude) * (p2.Longitude - p1.Longitude)
				    < (p2.Latitude - (long)p1.Latitude) * (pos.Longitude - p1.Longitude))
				{
					inside = !inside;
				}

				oldPos = pos;
				*/
		}
	}
}

