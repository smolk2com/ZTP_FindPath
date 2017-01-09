using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace ZTP_FindPath
{
    public static class Distance
    {
        #region Przeliczanie całkowitego dystansu ścieżki w km
        public static double TotalDistance(Paramethers _param)
        {
            //double dlon = _lon[1] - _lon[0];
            //double dlat = _lat[1] - _lat[0];
            //double a = Math.Sqrt(Math.Abs(Math.Sin(dlat / 2))) + Math.Cos(_lat[0]) * Math.Cos(_lat[1]) * Math.Sqrt(Math.Abs(Math.Sin(dlon / 2)));
            //double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            //double d = 1.609344 * c;
            //double total2 = 0;
            double total = 0;
            for (int i = 0; i <= _param.Longitude.Count - 2; i++)
            {
                double run = DistanceBeetwenTwoPath(_param.Latitude[i], _param.Longitude[i], _param.Latitude[i + 1], _param.Longitude[i + 1]);
                total += run;
            }
            Log.Information("calculate total Distance");
            return Math.Round(total,3);
        }
        #endregion
        #region Przeliczanie dystansu względem 2 współrzędnych w km
        public static double DistanceBeetwenTwoPath(double lat1, double lon1, double lat2, double lon2)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(Math.PI * lat1 / 180) * Math.Sin(Math.PI * lat2 / 180) + Math.Cos(Math.PI * lat1 / 180)
                * Math.Cos(Math.PI * lat2 / 180) * Math.Cos(Math.PI * theta / 180);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;
            return dist * 1.609344;

        }
        #endregion
        #region Przeliczanie całkowitego dystansu pod górkę w km
        public static double ClimbingDistance()
        {
            Paramethers _param;
            _param = new Paramethers("path.gpx");
            double total = 0;
            for (int i = 0; i <= _param.Longitude.Count - 2; i++)
            {
                if (_param.Height[i] < _param.Height[i + 1])
                {
                    double run = DistanceBeetwenTwoPath(_param.Latitude[i], _param.Longitude[i], _param.Latitude[i + 1], _param.Longitude[i + 1]);
                    total = Math.Round(total + run, 3);
                }
            }
            return total;
        }
        #endregion
        #region Przeliczanie całkowitego  dystansu z górki w km
        public static double DescentDistance()
        {
            Paramethers _param;
            _param = new Paramethers("path.gpx");
            double total = 0;
            for (int i = 0; i <= _param.Longitude.Count - 2; i++)
            {
                if (_param.Height[i] > _param.Height[i + 1])
                {
                    double run = DistanceBeetwenTwoPath(_param.Latitude[i], _param.Longitude[i], _param.Latitude[i + 1], _param.Longitude[i + 1]);
                    total = Math.Round(total + run, 3);
                }
            }
            return total;
        }
        #endregion
        #region Przeliczanie całkowitego  dystansu po płaskim w km
        public static double FlatDistance()
        {
            Paramethers _param;
            _param = new Paramethers("path.gpx");
            double total = 0;
            for (int i = 0; i <= _param.Longitude.Count - 2; i++)
            {
                if (_param.Height[i] == _param.Height[i + 1])
                {
                    double run = DistanceBeetwenTwoPath(_param.Latitude[i], _param.Longitude[i], _param.Latitude[i + 1], _param.Longitude[i + 1]);
                    total = Math.Round(total + run, 3);
                }
            }
            return total;
        }
        #endregion
    }
}
