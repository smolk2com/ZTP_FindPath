using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Deployment;
using ZTP_PathLibrary.Calculate;

namespace ZTP_PathLibrary.Displayer
{
    public class DisplayTxt : IDisplayer
    {
        private readonly ICalculate _service;
        private readonly List<Points> _points;
        public DisplayTxt(ICalculate service, List<Points> points)
        {
            _service = service;
            _points = points;
        }

        public void DisplayCalculations()
        {
            File.WriteAllText(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location),"Wyniki.txt"),_service.Calculate(_points));
        }
    }
}
