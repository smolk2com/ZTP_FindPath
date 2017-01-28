using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP_PathLibrary
{
    public static class Time
    {
        #region Przeliczanie czasu między 2 współrzędnymi w s
        public static int TimeBeetwenTwoPath(DateTime _firstDate, DateTime _secondDate)
        {
            int Time1, Time2;
            int _dayOfYear = _secondDate.DayOfYear - _firstDate.DayOfYear;
            Time1 = _firstDate.Hour * 3600 + _firstDate.Minute * 60 + _firstDate.Second;
            Time2 = _dayOfYear * 86400 + _secondDate.Hour * 3600 + _secondDate.Minute * 60 + _secondDate.Second;       
            return Time2- Time1;
        }

        #endregion
        #region Przeliczanie całkowitego czasu trasy w godzinach
        public static double TotalTime(List<Points> _points)
        {
            //double _totalTime = 0;
            //for (int i = 0; i <= _points.Count -2; i++)
            //{
            //    int _dayOfYear = _points[i].time.DayOfYear - _points[i+1].time.DayOfYear;
            //    _totalTime += _points[i].time.Hour * 3600 + _points[i].time.Minute * 60 + _points[i].time.Second + _dayOfYear * 86400 - _points[i+1].time.Hour * 3600 + _points[i + 1].time.Minute * 60 + _points[i + 1].time.Second;
            //}
            ////przeliczenie na godziny
            //_totalTime = Math.Round(_totalTime * 0.000277777777778,2);

            DateTime firstPoint = _points[0].time;
            DateTime lastPoint = _points[_points.Count - 1].time;

            double value1 = Time.TimeBeetwenTwoPath(firstPoint, lastPoint);

            return value1;
        }
        #endregion
        #region Przeliczanie całkowitego czasu trasy na dni, godziny, minuty, sekundy
        public static string TotalTrackTime(List<Points> _points)
        {
            
            TimeSpan _time;
            double _totalTime;
            _totalTime = TotalTime(_points);
            _time = TimeSpan.FromHours(_totalTime);
            return _time.ToString();
        }
        #endregion
        #region Przeliczenie całkowitego czasu pod górę
        public static string TotalClimbingTime(List<Points> _points)
        {
         
            double _TotalTime = 0;

            for (int i = 0; i <= _points.Count - 2; i++)
            {
                if (_points[i].ele < _points[i + 1].ele)
                    _TotalTime += TimeBeetwenTwoPath(_points[i].time, _points[i + 1].time);
            }
            return TimeSpan.FromSeconds(_TotalTime).ToString();
        }
        #endregion
        #region Przeliczenie całkowitego czasu z górki
        public static string TotalDescentTime(List<Points> _points)
        {
            
            double _TotalTime = 0;

            for (int i = 0; i <= _points.Count - 2; i++)
            {
                if (_points[i].ele > _points[i + 1].ele)
                    _TotalTime += TimeBeetwenTwoPath(_points[i].time, _points[i + 1].time);
            }
            return TimeSpan.FromSeconds(_TotalTime).ToString();
        }
        #endregion
        #region Przeliczenie całkowitego czasu po równum
        public static string TotalFlatTime(List<Points> _points)
        {
           
            double _TotalTime = 0;

            for (int i = 0; i <= _points.Count - 2; i++)
            {
                if (_points[i].ele == _points[i + 1].ele)
                    _TotalTime += TimeBeetwenTwoPath(_points[i].time, _points[i + 1].time);
            }
            return TimeSpan.FromSeconds(_TotalTime).ToString();
        }
        #endregion
    }
}
