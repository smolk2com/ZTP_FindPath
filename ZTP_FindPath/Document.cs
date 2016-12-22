using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZTP_FindPath
{
    public static class Document
    {
        #region Pobranie dokumentu gpx o nazwie 'path.gpx' z lokalizacji programu
        public static Paramethers GetDataFromDocument()
        {
            Paramethers _paramethers = new Paramethers();
            XDocument xdoc;
            xdoc = XDocument.Load(Environment.CurrentDirectory + @"\path.gpx");
            XNamespace gpx = XNamespace.Get("http://www.topografix.com/GPX/1/1");
            List<double> _lon = xdoc.Descendants(gpx + "trkpt").Select(lon => (double)lon.Attribute("lon")).ToList();
            _paramethers.Longitude = _lon;
            List<double> _lat = xdoc.Descendants(gpx + "trkpt").Select(lat => (double)lat.Attribute("lat")).ToList();
            _paramethers.Latitude = _lat;
            List<double> _ele = xdoc.Descendants(gpx + "trkpt").Select(ele => (double)ele.Element(gpx + "ele")).ToList();
            _paramethers.Height = _ele;
            List<DateTime> _time = xdoc.Descendants(gpx + "trkpt").Select(t => (DateTime)t.Element(gpx + "time")).ToList();
            _paramethers.AllTimes = _time;
            return _paramethers;
        }
        #endregion
    }
}
