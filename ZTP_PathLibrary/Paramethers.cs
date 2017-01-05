using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZTP_PathLibrary
{
    public struct Paramethers
    {
        private List<double> _Longitude;
        private List<double> _Latitude;
        private List<DateTime> _AllTimes;
        private List<double> _Height;

        public Paramethers(string pNameDocument)
        {
            XDocument xdoc;
            xdoc = XDocument.Load(Environment.CurrentDirectory + @"\" + pNameDocument);
            XNamespace gpx = XNamespace.Get("http://www.topografix.com/GPX/1/1");
            this._Longitude = xdoc.Descendants(gpx + "trkpt").Select(lon => (double)lon.Attribute("lon")).ToList();
            this._Latitude = xdoc.Descendants(gpx + "trkpt").Select(lat => (double)lat.Attribute("lat")).ToList();
            this._Height = xdoc.Descendants(gpx + "trkpt").Select(ele => (double)ele.Element(gpx + "ele")).ToList();
            this._AllTimes = xdoc.Descendants(gpx + "trkpt").Select(t => (DateTime)t.Element(gpx + "time")).ToList();
        }

        public List<double> Longitude { get { return _Longitude; } }
        public List<double> Latitude { get { return _Latitude; } }
        public List<DateTime> AllTimes { get { return _AllTimes; } }
        public List<double> Height { get { return _Height; } }
    }
}
