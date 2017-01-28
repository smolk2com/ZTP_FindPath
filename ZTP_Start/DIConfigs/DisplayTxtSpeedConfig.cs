using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ZTP_PathLibrary.Calculate;
using ZTP_PathLibrary.Displayer;
using ZTP_PathLibrary;

namespace ZTP_Start
{
    public static class DisplayTxtSpeedConfig
    {
        public static IContainer Configure(List<Points> points)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CalculateSpeed>().As<ICalculate>();
            builder.RegisterType<DisplayTxt>().As<IDisplayer>().WithParameter("points", points); ;

            return builder.Build();
        }
    }
}
