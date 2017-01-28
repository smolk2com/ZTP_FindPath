using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP_PathLibrary.Calculate
{
    public class CalculateTime : ICalculate
    {
        public string Calculate(List<Points> points)
        {
            StringBuilder builder = new StringBuilder();
           
            builder.AppendLine("================TIME================");
            builder.AppendLine("Total track time     - " + Time.TotalTrackTime(points));
            builder.AppendLine("Total climbing time  - " + Time.TotalClimbingTime(points));
            builder.AppendLine("Total descent time   - " + Time.TotalDescentTime(points));
            builder.AppendLine("Total flat time      - " + Time.TotalFlatTime(points));
            return builder.ToString();
        }
    }
}
