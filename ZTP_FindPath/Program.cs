using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZTP_FindPath
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadConfigXml();
        }
        static void ReadConfigXml()
        {
            XDocument xdoc;
            xdoc = XDocument.Load(Environment.CurrentDirectory + @"\path.gpx");
            XNamespace gpx = XNamespace.Get("http://www.topografix.com/GPX/1/1");
            List<double> _lon = xdoc.Descendants(gpx + "trkpt").Select(tt => (double)tt.Attribute("lon")).ToList();
            List<double> _lat = xdoc.Descendants(gpx + "trkpt").Select(tt => (double)tt.Attribute("lat")).ToList();
            List<double> _ele = xdoc.Descendants(gpx + "trkpt").Select(t => (double)t.Element(gpx + "ele")).ToList();
            List<DateTime> _time = xdoc.Descendants(gpx + "trkpt").Select(t => (DateTime)t.Element(gpx + "time")).ToList();
        }
    }
}