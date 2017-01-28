using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace ZTP_PathLibrary
{
    public static class Distance
    {
        #region Przeliczanie całkowitego dystansu ścieżki w km
        public static double TotalDistance(List<Points> _points)
        {


            //double dlon = _lon[1] - _lon[0];
            //double dlat = _lat[1] - _lat[0];
            //double a = Math.Sqrt(Math.Abs(Math.Sin(dlat / 2))) + Math.Cos(_lat[0]) * Math.Cos(_lat[1]) * Math.Sqrt(Math.Abs(Math.Sin(dlon / 2)));
            //double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            //double d = 1.609344 * c;
            //double total2 = 0;
           
            //double _lat1 = 38.898556D;
            //double _lon1 = -77.037852D;

            //double _lat2 = 38.897147D;
            //double _lon2 = -77.043934D;

            //double dlon = _lon2 - _lon1;

            //double dlat = _lat2 - _lat1;

            //double a = Math.Pow(Math.Sin(dlat / 2),2) + Math.Cos(_lat1) * Math.Cos(_lat2) * Math.Pow(Math.Sin(dlon / 2),2);
            
            //double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1-a));
            
            //double d = 6373 * c;
          
            //return d;

            double total = 0;
            for (int i = 0; i <= _points.Count - 2; i++)
            {
                double run = GetDistanceKM(_points[i].lat, _points[i].lon, _points[i + 1].lat, _points[i + 1].lon);
                total += run;
        }
            //Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.LiterateConsole()
            return  Math.Round(total,3);
        }
        #endregion
        #region Przeliczanie dystansu względem 2 współrzędnych w km OLD
        //public static double DistanceBeetwenTwoPath(double lat1, double lon1, double lat2, double lon2)
        //{
        //    double theta = lon1 - lon2;
        //    double dist = Math.Sin(Math.PI * lat1 / 180) * Math.Sin(Math.PI * lat2 / 180) + Math.Cos(Math.PI * lat1 / 180)
        //        * Math.Cos(Math.PI * lat2 / 180) * Math.Cos(Math.PI * theta / 180);
        //    dist = Math.Acos(dist);
        //    dist = dist * 180 / Math.PI;
        //    dist = dist * 60 * 1.1515;

        //    return dist * 1.609344;

        //}
        #endregion
        #region Przeliczanie całkowitego dystansu pod górkę w km
        public static double ClimbingDistance(List<Points> _points)
        {
            
            double total = 0;
            for (int i = 0; i <= _points.Count - 2; i++)
            {
                if (_points[i].ele < _points[i+ 1].ele)
                {
                    double run = GetDistanceKM(_points[i].lat, _points[i].lon, _points[i + 1].lat, _points[i + 1].lon);
                    total = Math.Round(total + run, 3);
                }
            }
            return total;
        }
        #endregion
        #region Przeliczanie całkowitego  dystansu z górki w km
        public static double DescentDistance(List<Points> _points)
        {
            
            double total = 0;
            for (int i = 0; i <= _points.Count - 2; i++)
            {
                if (_points[i].ele > _points[i + 1].ele)
                {
                    double run = GetDistanceKM(_points[i].lat, _points[i].lon, _points[i + 1].lat, _points[i + 1].lon);
                    total = Math.Round(total + run, 3);
                }
            }
            return total;
        }
        #endregion
        #region Przeliczanie całkowitego  dystansu po płaskim w km
        public static double FlatDistance(List<Points> _point)
        {
           
            double total = 0;
            for (int i = 0; i <= _point.Count - 2; i++)
            {
                if (_point[i].ele == _point[i + 1].ele)
                {
                    double run = GetDistanceKM(_point[i].lat, _point[i].lon, _point[i + 1].lat, _point[i + 1].lon);
                    total = Math.Round(total + run, 3);
                }
            }
            return total;
        }
        #endregion
        #region Przeliczanie dystansu pomiędzy 2 współrzędnymi
        private const double EARTH_RADIUS_KM = 6371;

        private static double ToRad(double input)
        {
            return input * (Math.PI / 180);
        }

    
        public static double GetDistanceKM(double lat1, double lon1, double lat2, double lon2)
        {
            double dLat = ToRad(lat2 - lat1);
            double dLon = ToRad(lon2 - lon1);

            double a = Math.Pow(Math.Sin(dLat / 2), 2) +
                       Math.Cos(ToRad(lat1)) * Math.Cos(ToRad(lat2)) *
                       Math.Pow(Math.Sin(dLon / 2), 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = EARTH_RADIUS_KM * c;
            return distance;
        }
        #endregion
    }
}
