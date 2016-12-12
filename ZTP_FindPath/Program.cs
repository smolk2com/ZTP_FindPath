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
            xdoc = XDocument.Load(Environment.CurrentDirectory + @"\path.xml");

            List<double> IDsInDistantXML = xdoc.Root.Element("trkseg")
                                     .Elements("trkpt")
                                     .Select(pr => (double)pr.Attribute("lon"))
                                     .ToList();

        }
    }
}
