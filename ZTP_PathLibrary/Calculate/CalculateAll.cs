using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP_PathLibrary.Calculate
{
    public class CalculateAll : ICalculate
    {
        public string Calculate(List<Points> points)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("==============DISTANCE==============");
            builder.AppendLine("Total     - " + Distance.TotalDistance(points) + " km");
            builder.AppendLine("Flat      - " + Distance.FlatDistance(points) + " km");
            builder.AppendLine("Climbing  - " + Distance.ClimbingDistance(points) + " km");
            builder.AppendLine("Descent   - " + Distance.DescentDistance(points) + " km");
            builder.AppendLine("================SPEED===============");
            builder.AppendLine("Max speed              - " + Speed.MaximumSpeed(points) + " km/h");
            builder.AppendLine("Min speed              - " + Speed.MinimumSpeed(points) + " km/h");
            builder.AppendLine("Average speed          - " + Speed.AverageSpeed(points) + " km/h");
            builder.AppendLine("Average climbing speed - " + Speed.AverageClimbingSpeed(points) + " km/h");
            builder.AppendLine("Average descent speed  - " + Speed.AverageDescentSpeed(points) + " km/h");
            builder.AppendLine("Average flat speed     - " + Speed.AverageFlatSpeed(points) + " km/h");
            builder.AppendLine("==============ELEVATON==============");
            builder.AppendLine("Minimum elevation - " + Elevation.MinimumElevation(points) + " m");
            builder.AppendLine("Average elevation - " + Elevation.AverageElevation(points));
            builder.AppendLine("Total climbing    - " + Elevation.TotalClimbing(points) + " m");
            builder.AppendLine("Total descent     - " + Elevation.TotalDescent(points) + " m");
            builder.AppendLine("================TIME================");
            builder.AppendLine("Total track time     - " + Time.TotalTrackTime(points));
            builder.AppendLine("Total climbing time  - " + Time.TotalClimbingTime(points));
            builder.AppendLine("Total descent time   - " + Time.TotalDescentTime(points));
            builder.AppendLine("Total flat time      - " + Time.TotalFlatTime(points));
            return builder.ToString();
        }
    }
}
