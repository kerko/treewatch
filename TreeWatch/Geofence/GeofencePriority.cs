﻿// <copyright file="GeofencePriority.cs" company="TreeWatch">
// Copyright © 2015 TreeWatch
// </copyright>
#region Copyright
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
#endregion
namespace TreeWatch
{
    /// <summary>
    /// Geofence Accuracy Precision Priority enum
    /// </summary>
    public enum GeofencePriority
    {
        /// <summary>
        /// Sets the location updates for balanced power accurancy basing location on Cells and WiFi spots.
        /// </summary>
        BalancedPower,

        /// <summary>
        /// Highest accuracy uses GPS and other sources to determine best location precision
        /// </summary>
        HighAccuracy,

        /// <summary>
        /// Acceptable accuracy 
        /// </summary>
        AcceptableAccuracy,

        /// <summary>
        /// Medium accuracy
        /// </summary>
        MediumAccuracy,

        /// <summary>
        /// Low accuracy
        /// </summary>
        LowAccuracy,

        /// <summary>
        /// Lowest Acurracy
        /// </summary>
        LowestAccuracy
    }
}