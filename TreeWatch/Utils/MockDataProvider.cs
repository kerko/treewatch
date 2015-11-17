﻿using System.Collections.Generic;
using Xamarin.Forms.Maps;
using SQLiteNetExtensions.Extensions;

namespace TreeWatch
{
	public static class MockDataProvider
	{

		public static void SetUpMockData ()
		{
			var connection = new TreeWatchDatabase ();
			connection.ClearDataBase ();

			var query = new DBQuery<Field> (connection);

			query.InsertWithChildren (new Field ("Ajax", new List<Position> {
				new Position (51.395390, 6.056181),
				new Position (51.392672, 6.056074),
				new Position (51.392766, 6.053628),
				new Position (51.395189, 6.054014)
			}, new List<Block> ()));

			query.InsertWithChildren (new Field ("PSV", new List<Position> {
				new Position (51.487109, 4.464810),
				new Position (51.486474, 4.466023),
				new Position (51.485038, 4.463276),
				new Position (51.486167, 4.461914),
				new Position (51.486454, 4.462643),
				new Position (51.486347, 4.462761)
			}, new List<Block> ()));

			query.InsertWithChildren (new Field ("Roda jc", new List<Position> {
				new Position (51.372129, 6.046075),
				new Position (51.369650, 6.047126),
				new Position (51.369476, 6.045667),
				new Position (51.369918, 6.045259),
				new Position (51.371131, 6.042325)
			}, new List<Block> ()));

			query.InsertWithChildren (new Field ("VVV", new List<Position> {
				new Position (51.387718, 6.040184),
				new Position (51.386620, 6.036065),
				new Position (51.389485, 6.038983)
			}, new List<Block> ()));

			var blocks = new List<Block> ();
			double startlatA = 51.390508; 
			double startlatB = 51.389674;
			double startlonA = 6.050828;
			double startlonB = 6.047850;
			for (int i = 0; i < 9; i++) {
				blocks.Add (new Block (new  List<Position> { 
					new Position (startlatA, startlonA),
					new Position (startlatB, startlonB),
					new Position (startlatB + 0.0001, startlonB), 
					new Position (startlatA + 0.0001, startlonA)
				}, 
					TreeType.APPLE));
				startlatA += 0.000103;
				startlatB += 0.000103;
			}
			startlatB = 51.391453;
			startlonB = 6.049844;
			for (int i = 0; i < 4; i++) {
				blocks.Add (new Block (new  List<Position> { 
					new Position (startlatA, startlonA),
					new Position (startlatB, startlonB),
					new Position (startlatB + 0.0001, startlonB), 
					new Position (startlatA + 0.0001, startlonA)
				}, 
					TreeType.APPLE));
				startlatA += 0.000106;
				startlatB += 0.000106;
			}  

			query.InsertWithChildren (new Field ("Hertog Jan", new List<Position> {
				new Position (51.389619, 6.047791),
				new Position (51.391065, 6.047748),
				new Position (51.391213, 6.049744),
				new Position (51.391936, 6.049722),
				new Position (51.391922, 6.050967),
				new Position (51.390450, 6.050924)
			}, blocks));


		}
	}
}

