using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZTP_PathLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Tests
{
    [TestClass()]
    public class DistanceTests
    {
        List<Points> _points = Paramethers.GetPoints(@"\..\..\..\..\Path.gpx");
        [TestMethod()]
        public void TotalDistanceTest()
        {
            double test = 4.033;
            double value = Distance.TotalDistance(_points);

            Assert.AreEqual(test, value);
        }

        [TestMethod()]
        public void ClimbingDistanceTest()
        {
            double test = 0.979;
            double value = Distance.ClimbingDistance(_points);

            Assert.AreEqual(test, value);
        }

        [TestMethod()]
        public void DescentDistanceTest()
        {
            double test = 2.671;
            double value = Distance.DescentDistance(_points);

            Assert.AreEqual(test, value);
        }

        [TestMethod()]
        public void FlatDistanceTest()
        {
            double test = 0.354;
            double value = Distance.FlatDistance(_points);

            Assert.AreEqual(test, value);

        }
    }
}