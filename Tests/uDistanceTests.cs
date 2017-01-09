using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZTP_PathLibrary;

namespace TestsPathLibrary
{
    [TestClass]
    public class AllTests
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        [TestMethod]
        [TestCategory("Distance")]
        [DeploymentItem("data.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\data.csv",
            "data#csv",
            DataAccessMethod.Sequential)]
        public void DistancBetweenTwoParamethers()
        {
            //arrange
            double _lat1, _lon1, _lat2, _lon2;
            _lat1 = double.Parse(TestContext.DataRow["lat1"].ToString());
            _lon1 = double.Parse(TestContext.DataRow["lon1"].ToString());
            _lat2 = double.Parse(TestContext.DataRow["lat2"].ToString());
            _lon2 = double.Parse(TestContext.DataRow["lon2"].ToString());
            double expected = double.Parse(TestContext.DataRow["res"].ToString());
            double result;
            //act
            result = Math.Round(Distance.DistanceBeetwenTwoPath(_lat1, _lon1, _lat2, _lon2),3);
            //assert
            Assert.AreEqual(expected, result, "Nie działa wyznaczanie całkowitego dystansu");
        }
    }
}
