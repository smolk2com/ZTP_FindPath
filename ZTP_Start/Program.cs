using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_PathLibrary;
using ZTP_PathLibrary.Displayer;
using Autofac;

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
            Console.ReadKey();


        }
    }
}
