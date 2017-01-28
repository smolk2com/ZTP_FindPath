using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP_PathLibrary.Calculate
{
    public class CalculateSpeed : ICalculate
    {
        public string Calculate(List<Points> points)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("================SPEED===============");
            builder.AppendLine("Max speed              - " + Speed.MaximumSpeed(points) + " km/h");
            builder.AppendLine("Min speed              - " + Speed.MinimumSpeed(points) + " km/h");
            builder.AppendLine("Average speed          - " + Speed.AverageSpeed(points) + " km/h");
            builder.AppendLine("Average climbing speed - " + Speed.AverageClimbingSpeed(points) + " km/h");
            builder.AppendLine("Average descent speed  - " + Speed.AverageDescentSpeed(points) + " km/h");
            builder.AppendLine("Average flat speed     - " + Speed.AverageFlatSpeed(points) + " km/h");

            return builder.ToString();
        }
    }
}

