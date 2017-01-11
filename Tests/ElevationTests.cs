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
        [TestMethod()]
        public void AverageElevationTest()
        {
            Paramethers _param = new Paramethers();
            Assert.IsNotNull(_param);
        }

        [TestMethod()]
        public void TotalClimbingTest()
        {
            double totalclimbing = 81.5D;

            Paramethers _param = new Paramethers();
            double test = Elevation.TotalClimbing(_param);
           
            Assert.AreEqual(test, totalclimbing);
        }

        [TestMethod()]
        public void TotalDescentTest()
        {
            double totalclimbing = 327.9D;

            Paramethers _param = new Paramethers();
            double test = Elevation.TotalDescent(_param);

            Assert.AreEqual(test, totalclimbing);
        }
    }
}