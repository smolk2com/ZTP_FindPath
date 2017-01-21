using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZTP_PathLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP_PathLibrary.Tests
{
    [TestClass()]
    public class ElevationTests
    {
        List<Points> _points = Paramethers.GetPoints(@"\..\..\..\..\Path.gpx");
        [TestMethod()]
        public void AverageElevationTest()
        {
            double test = Elevation.AverageElevation(_points);
            Assert.AreEqual(548.78, test);
        }

        [TestMethod()]
        public void TotalClimbingTest()
        {
            double test = Elevation.TotalClimbing(_points);
            Assert.AreEqual(81.5, test);
            
        }

        [TestMethod()]
        public void TotalDescentTest()
        {
            double test = Elevation.TotalDescent(_points);
            Assert.AreEqual(327.9, test);
        }
    }
}