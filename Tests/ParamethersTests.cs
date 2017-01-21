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
    public class ParamethersTests
    {
        [TestMethod()]
        public void GetPointsTest()
        {
            List<Points> _points = Paramethers.GetPoints(@"\..\..\..\..\Path.gpx");

            Assert.IsNotNull(_points);

            for (int i = 0; i < _points.Count - 1; i++)
            {
                Assert.AreNotEqual(_points[i], _points[i + 1]);
            }
        }
    }
}