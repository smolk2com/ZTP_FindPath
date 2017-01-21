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
    public class TimeTests
    {
        List<Points> _points = Paramethers.GetPoints(@"\..\..\..\..\Path.gpx");

        [TestMethod()]
        public void TimeBeetwenTwoPathTest()
        {
            Points firstPoint = _points[3];
            Points secondPoint = _points[742];

            int test = 1213522;
            int value = Time.TimeBeetwenTwoPath(firstPoint.time, secondPoint.time);

            Assert.AreEqual(test, value);
        }

        [TestMethod()]
        public void TotalTimeTest()
        {
            DateTime firstPoint = _points[0].time;
            DateTime lastPoint = _points[_points.Count - 1].time;

            double value1 = Time.TimeBeetwenTwoPath(firstPoint, lastPoint);
            double value2 = Time.TotalTime(_points);

            Assert.AreEqual(value1, value2);
        }
    }
}