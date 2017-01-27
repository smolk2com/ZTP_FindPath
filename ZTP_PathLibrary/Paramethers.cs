using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZTP_PathLibrary
{
    public class Points
    {
        private double _lon;
        private double _lat;
        private double _ele;
        private DateTime _time;

        public double lon { get { return _lon; } set { _lon = value; } }
        public double lat { get { return _lat; } set { _lat = value; } }
        public double ele { get { return _ele; } set { _ele = value; } }
        public DateTime time { get { return _time; } set { _time = value; } }
    }
    public class Paramethers
    {
        //private List<double> _Longitude;
        //private List<double> _Latitude;
        //private List<DateTime> _AllTimes;
        //private List<double> _Height;

        public static List<Points> GetPoints(string pNameDocument)
        {
            XDocument xdoc;
            xdoc = XDocument.Load(Environment.CurrentDirectory + @"\" + pNameDocument);
            XNamespace gpx = XNamespace.Get("http://www.topografix.com/GPX/1/1");
            //this._Longitude = xdoc.Descendants(gpx + "trkpt").Select(lon => (double)lon.Attribute("lon")).ToList();
            //this._Latitude = xdoc.Descendants(gpx + "trkpt").Select(lat => (double)lat.Attribute("lat")).ToList();
            //this._Height = xdoc.Descendants(gpx + "trkpt").Select(ele => (double)ele.Element(gpx + "ele")).ToList();
            //this._AllTimes = xdoc.Descendants(gpx + "trkpt").Select(t => (DateTime)t.Element(gpx + "time")).ToList();
            List<Points> _allPoints = new List<Points>();
            foreach (var part in xdoc.Descendants(gpx + "trkpt"))
            {
                Points _points = new Points();
                _points.lon = (double)part.Attribute("lon");
                _points.lat = (double)part.Attribute("lat");
                _points.ele = (double)part.Element(gpx + "ele");
                _points.time = (DateTime)part.Element(gpx + "time");
                _allPoints.Add(_points);
            }
            return _allPoints;
        }
    }
}
