using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP_PathLibrary.Calculate
{
    public class CalculateDistance : ICalculate
    {
        public string Calculate(List<Points> points)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("==============DISTANCE==============");
            builder.AppendLine("Total     - " + Distance.TotalDistance(points) + " km");
            builder.AppendLine("Flat      - " + Distance.FlatDistance(points) + " km");
            builder.AppendLine("Climbing  - " + Distance.ClimbingDistance(points) + " km");
            builder.AppendLine("Descent   - " + Distance.DescentDistance(points) + " km");
            
            return builder.ToString();
        }
    }
}
