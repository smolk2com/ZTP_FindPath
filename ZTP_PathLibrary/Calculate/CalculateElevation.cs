using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP_PathLibrary.Calculate
{
    public class CalculateElevation : ICalculate
    {
        public string Calculate(List<Points> points)
        {
            StringBuilder builder = new StringBuilder();
            
            builder.AppendLine("==============ELEVATON==============");
            builder.AppendLine("Minimum elevation - " + Elevation.MinimumElevation(points) + " m");
            builder.AppendLine("Average elevation - " + Elevation.AverageElevation(points));
            builder.AppendLine("Total climbing    - " + Elevation.TotalClimbing(points) + " m");
            builder.AppendLine("Total descent     - " + Elevation.TotalDescent(points) + " m");
            
            return builder.ToString();
        }
    }
}
