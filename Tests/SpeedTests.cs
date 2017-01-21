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
    public class SpeedTests
    {
        List<Points> _points = Paramethers.GetPoints(@"\..\..\..\..\Path.gpx");
        [TestMethod()]
        public void MinimumSpeedTest()
        {
            double test = 0.0001;
            double value = Speed.MinimumSpeed(_points);
            Assert.AreEqual(test, value);
        }

        [TestMethod()]
        public void MaximumSpeedTest()
        {
            double test = 45;
            double value = Speed.MaximumSpeed(_points);
            Assert.AreEqual(test, value);
        }


        [TestMethod()]
        public void AverageClimbingSpeedTest()
        {
            double test = 4.257;
            double value = Speed.AverageClimbingSpeed(_points);
            Assert.AreEqual(test, value);
        }

        [TestMethod()]
        public void AverageDescentSpeedTest()
        {
            double test = 0.006;
            double value = Speed.AverageDescentSpeed(_points);
            Assert.AreEqual(test, value);
        }

        [TestMethod()]
        public void AverageFlatSpeedTest()
        {
            double test = 3.54;
            double value = Speed.AverageFlatSpeed(_points);
            Assert.AreEqual(test, value);
        }
    }
}