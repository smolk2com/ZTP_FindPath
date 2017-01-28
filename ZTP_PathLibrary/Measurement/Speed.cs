using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP_PathLibrary
{
    public static class Speed
    {
        #region Przeliczanie największej prędkości w km/h
        public static double MinimumSpeed(List<Points> _points)
        {
            
            //_param = Document.GetDataFromDocument(new Paramethers());
            double speed1 = 0;
            double speed2 = 100;
            for (int i = 0; i <= _points.Count - 2; i++)
            {
                double _distance = Math.Round(Distance.GetDistanceKM(_points[i].lat, _points[i].lon, _points[i + 1].lat, _points[i + 1].lon), 3);
                //total = Math.Round(total + run, 3);
                int _time = Time.TimeBeetwenTwoPath(_points[i].time, _points[i + 1].time);
                speed1 = Math.Round(_distance * 1000 / _time * 3.6, 4);
                if (speed2 > speed1)
                {
                    //Console.WriteLine(i);
                    speed2 = speed1;

                }

            }
            return speed2;
        }
        #endregion
        #region Przeliczanie minimalnej prędkości w km/h
        public static double MaximumSpeed(List<Points> _points)
        {
           
            // _param = Document.GetDataFromDocument(new Paramethers());
            double speed1 = 0;
            double speed2 = 0;
            for (int i = 0; i <= _points.Count - 2; i++)
            {
                double _distance = Math.Round(Distance.GetDistanceKM(_points[i].lat, _points[i].lon, _points[i + 1].lat, _points[i + 1].lon), 3);
                //total = Math.Round(total + run, 3);
                int _time = Time.TimeBeetwenTwoPath(_points[i].time, _points[i+1].time);
                speed1 = Math.Round(_distance * 1000 / _time * 3.6,4);
                if (speed2 < speed1)
                {
                    //Console.WriteLine(i);
                    speed2 = speed1;
                    
                }
                    
            }
            return speed2;
        }
        #endregion
        #region Przeliczanie średniej prędkości w km/h
        public static double AverageSpeed(List<Points> _points)
        {
            
            double _averageSpeed = 0;
            _averageSpeed = Math.Round(Distance.TotalDistance( _points) / Time.TotalTime(_points),3);
            return _averageSpeed;
        }
        #endregion
        #region Przeliczanie średniej prędkości pod górę w km/h
        public static double AverageClimbingSpeed(List<Points> _points)
        {
           
            double _averageSpeed = 0;
            double _distance = 0;
            double _time = 0;
           // _param = Document.GetDataFromDocument(new Paramethers());
            for (int i = 0; i <= _points.Count -2; i++)
            {
                if (_points[i].ele < _points[i + 1].ele)
                {
                    _distance += Math.Round(Distance.GetDistanceKM(_points[i].lat, _points[i].lon, _points[i + 1].lat, _points[i + 1].lon), 3);
                    _time += Time.TimeBeetwenTwoPath(_points[i].time, _points[i + 1].time);
                }
            }
            //przeliczenie na godziny
            _time = Math.Round(_time * 0.000277777778,2);
            _averageSpeed = Math.Round(_distance / _time, 3);
            return _averageSpeed;
        }
        #endregion
        #region Przeliczanie średniej prędkości z górki w km/h
        public static double AverageDescentSpeed(List<Points> _points)
        {

            double _averageSpeed = 0;
            double _distance = 0;
            double _time = 0;
           // _param = Document.GetDataFromDocument(new Paramethers());
            for (int i = 0; i <= _points.Count - 2; i++)
            {
                if (_points[i].ele > _points[i + 1].ele)
                {
                    _distance += Math.Round(Distance.GetDistanceKM(_points[i].lat, _points[i].lon, _points[i + 1].lat, _points[i + 1].lon), 3);
                    _time += Time.TimeBeetwenTwoPath(_points[i].time, _points[i + 1].time);
                }
            }
            //przeliczenie na godziny
            _time = Math.Round(_time * 0.000277777778, 2);
            _averageSpeed = Math.Round(_distance / _time, 3);
            return _averageSpeed;
        }
        #endregion
        #region Przeliczanie średniej prędkości na płaskim w km/h
        public static double AverageFlatSpeed(List<Points> _points)
        {
            double _averageSpeed = 0;
            double _distance = 0;
            double _time = 0;
            for (int i = 0; i <= _points.Count - 2; i++)
            {
                if (_points[i].ele == _points[i + 1].ele)
                {
                    _distance += Math.Round(Distance.GetDistanceKM(_points[i].lat, _points[i].lon, _points[i + 1].lat, _points[i + 1].lon), 3);
                    _time += Time.TimeBeetwenTwoPath(_points[i].time, _points[i + 1].time);
                }
            }
            //przeliczenie na godziny
            _time = Math.Round(_time * 0.000277777778, 2);
            _averageSpeed = Math.Round(_distance / _time, 3);
            return _averageSpeed;
        }
        #endregion
    }
}
