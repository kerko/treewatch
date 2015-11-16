﻿using NUnit.Framework;
using Xamarin.Forms;


namespace TreeWatch.Tests
{
	[TestFixture ()]
	public class ColorHelperTest
	{
		[Test ()]
		public void TestGetTreeTypColor ()
		{
			Assert.AreEqual (ColorHelper.GetTreeTypeColor (TreeType.APPLE), Color.Lime);
			Assert.AreEqual (ColorHelper.GetTreeTypeColor (TreeType.PEAR), Color.Maroon);
			Assert.AreEqual (ColorHelper.GetTreeTypeColor (TreeType.CHERRY), Color.Red);
			Assert.AreEqual (ColorHelper.GetTreeTypeColor (TreeType.PLUM), Color.Purple);
			Assert.AreEqual (ColorHelper.GetTreeTypeColor (TreeType.NOTDEFINED), Color.Black);
		}

		[Test ()]
		public void TestGetTreeTypColorWithString()
		{
			Assert.AreEqual (ColorHelper.GetTreeTypeColor ("0"), Color.Lime);
			Assert.AreEqual (ColorHelper.GetTreeTypeColor ("1"), Color.Maroon);
			Assert.AreEqual (ColorHelper.GetTreeTypeColor ("2"), Color.Red);
			Assert.AreEqual (ColorHelper.GetTreeTypeColor ("3"), Color.Purple);
			Assert.AreEqual (ColorHelper.GetTreeTypeColor ("4"), Color.Black);
			Assert.AreEqual (ColorHelper.GetTreeTypeColor ("5"), Color.Blue);
		}
	}
}

