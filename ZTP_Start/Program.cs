using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_PathLibrary;
using ZTP_PathLibrary.Displayer;
using Autofac;
using Serilog;

namespace ZTP_Start
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Points> _points = Paramethers.GetPoints("path.gpx");

            var containerDispAll = DisplayConsoleAllConfig.Configure(_points);
            using (var scope = containerDispAll.BeginLifetimeScope())
            {
                var calculate = scope.Resolve<IDisplayer>();
                calculate.DisplayCalculations();
            }
            
            var containerTxtSpeed = DisplayTxtSpeedConfig.Configure(_points);
            using (var scope = containerTxtSpeed.BeginLifetimeScope())
            {
                var calculate = scope.Resolve<IDisplayer>();
                calculate.DisplayCalculations();
            }

            //Log.Logger = new LoggerConfiguration().WriteTo.File(Environment.CurrentDirectory + @"\log.txt").CreateLogger();
            //Log.Information("Run GPS");

            //ReadConfigXml();
            //Console.WriteLine("==============DISTANCE==============");
            //Console.WriteLine("Total     - " + Distance.TotalDistance(_points) + " km");
            //Console.WriteLine("Flat      - " + Distance.FlatDistance(_points) + " km");
            //Console.WriteLine("Climbing  - " + Distance.ClimbingDistance(_points) + " km");
            //Console.WriteLine("Descent   - " + Distance.DescentDistance(_points) + " km");
            //Console.WriteLine("================SPEED===============");
            //Console.WriteLine("Max speed              - " + Speed.MaximumSpeed(_points) + " km/h");
            //Console.WriteLine("Min speed              - " + Speed.MinimumSpeed(_points) + " km/h");
            //Console.WriteLine("Average speed          - " + Speed.AverageSpeed(_points) + " km/h");
            //Console.WriteLine("Average climbing speed - " + Speed.AverageClimbingSpeed(_points) + " km/h");
            //Console.WriteLine("Average descent speed  - " + Speed.AverageDescentSpeed(_points) + " km/h");
            //Console.WriteLine("Average flat speed     - " + Speed.AverageFlatSpeed(_points) + " km/h");
            //Console.WriteLine("==============ELEVATON==============");
            //Console.WriteLine("Minimum elevation - " + Elevation.MinimumElevation(_points) + " m");
            //Console.WriteLine("Average elevation - " + Elevation.AverageElevation(_points));
            //Console.WriteLine("Total climbing    - " + Elevation.TotalClimbing(_points) + " m");
            //Console.WriteLine("Total descent     - " + Elevation.TotalDescent(_points) + " m");
            //Console.WriteLine("================TIME================");
            //Console.WriteLine("Total track time     - " + Time.TotalTrackTime(_points));
            //Console.WriteLine("Total climbing time  - " + Time.TotalClimbingTime(_points));
            //Console.WriteLine("Total descent time   - " + Time.TotalDescentTime(_points));
            //Console.WriteLine("Total flat time      - " + Time.TotalFlatTime(_points));
            Console.ReadKey();


        }
    }
}
