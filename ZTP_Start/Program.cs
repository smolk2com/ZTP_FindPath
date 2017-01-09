using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_PathLibrary;
using Serilog;

namespace ZTP_Start
{
    class Program
    {
        static void Main(string[] args)
        {
            Paramethers _param = new Paramethers("path.gpx");

            //Log.Logger = new LoggerConfiguration().WriteTo.File(Environment.CurrentDirectory + @"\log.txt").CreateLogger();
            //Log.Information("Run GPS");
            
            //ReadConfigXml();
            Console.WriteLine("Total - " + Distance.TotalDistance(_param) + " km");
            Console.WriteLine("Flat - " + Distance.FlatDistance(_param) + " km");
            Console.WriteLine("Climbing - " + Distance.ClimbingDistance(_param) + " km");
            Console.WriteLine("Descent - " + Distance.DescentDistance(_param) + " km");
            Console.WriteLine("Max speed - " + Speed.MaximumSpeed(_param) + " km/h");
            Console.WriteLine("Min speed - " + Speed.MinimumSpeed(_param) + " km/h");
            Console.WriteLine("Average speed - " + Speed.AverageSpeed(_param) + " km/h");
            Console.WriteLine("Average climbing speed - " + Speed.AverageClimbingSpeed(_param) + " km/h");
            Console.WriteLine("Average descent speed - " + Speed.AverageDescentSpeed(_param) + " km/h");
            Console.WriteLine("Average flat speed - " + Speed.AverageFlatSpeed(_param) + " km/h");
            Console.WriteLine("Average elevation - " + Elevation.AverageElevation(_param));
            Console.WriteLine("Total climbing - " + Elevation.TotalClimbing(_param) + " m");
            Console.WriteLine("Total descent - " + Elevation.TotalDescent(_param) + " m");
            Console.WriteLine("Total track time - " + Time.TotalTrackTime(_param));
            Console.WriteLine("Total climbing time - " + Time.TotalClimbingTime(_param));
            Console.WriteLine("Total descent time - " + Time.TotalDescentTime(_param));
            Console.WriteLine("Total flat time - " + Time.TotalFlatTime(_param));
            Console.ReadKey();


        }
    }
}
