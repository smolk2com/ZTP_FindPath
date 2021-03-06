﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Serilog;

namespace ZTP_FindPath
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File(Environment.CurrentDirectory + @"\log.txt").CreateLogger();
            Log.Information("Run GPS");
            Paramethers _param;
            _param = new Paramethers("path.gpx");
            //ReadConfigXml();
            Console.WriteLine("Total - " + Distance.TotalDistance(_param) + " km");
            Console.WriteLine("Flat - " + Distance.FlatDistance() + " km");
            Console.WriteLine("Climbing - " + Distance.ClimbingDistance() + " km");
            Console.WriteLine("Descent - " + Distance.DescentDistance() + " km");
            Console.WriteLine("Max speed - " + Speed.MaximumSpeed() + " km/h");
            Console.WriteLine("Min speed - " + Speed.MinimumSpeed() + " km/h");
            Console.WriteLine("Average speed - " + Speed.AverageSpeed() + " km/h");
            Console.WriteLine("Average climbing speed - " + Speed.AverageClimbingSpeed() + " km/h");
            Console.WriteLine("Average descent speed - " + Speed.AverageDescentSpeed() + " km/h");
            Console.WriteLine("Average flat speed - " + Speed.AverageFlatSpeed() + " km/h");
            Console.WriteLine("Average elevation - " + Elevation.AverageElevation());
            Console.WriteLine("Total climbing - " + Elevation.TotalClimbing() + " m");
            Console.WriteLine("Total descent - " + Elevation.TotalDescent() + " m");
            Console.WriteLine("Total track time - " + Time.TotalTrackTime());
            Console.WriteLine("Total climbing time - " + Time.TotalClimbingTime());
            Console.WriteLine("Total descent time - " + Time.TotalDescentTime());
            Console.WriteLine("Total flat time - " + Time.TotalFlatTime());
            Console.ReadKey();
        }
        //static void ReadConfigXml()
        //{
        //    XDocument xdoc;
        //    xdoc = XDocument.Load(Environment.CurrentDirectory + @"\path.gpx");
        //    XNamespace gpx = XNamespace.Get("http://www.topografix.com/GPX/1/1");
        //    List<double> _lon = xdoc.Descendants(gpx + "trkpt").Select(lon => (double)lon.Attribute("lon")).ToList();
        //    List<double> _lat = xdoc.Descendants(gpx + "trkpt").Select(lat => (double)lat.Attribute("lat")).ToList();
        //    List<double> _ele = xdoc.Descendants(gpx + "trkpt").Select(ele => (double)ele.Element(gpx + "ele")).ToList();
        //    List<DateTime> _time = xdoc.Descendants(gpx + "trkpt").Select(t => (DateTime)t.Element(gpx + "time")).ToList();
        //}
    }
}