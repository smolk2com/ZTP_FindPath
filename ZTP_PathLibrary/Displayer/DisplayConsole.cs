using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_PathLibrary.Calculate;

namespace ZTP_PathLibrary.Displayer
{
    public class DisplayConsole : IDisplayer
    {
        private readonly ICalculate _service;
        List<Points> _points;
        public DisplayConsole(ICalculate service, List<Points> points)
        {
            _service = service;
            _points = points;
        }

        public void DisplayCalculations()
        {
            Console.WriteLine(_service.Calculate(_points));
        }
    }
}
