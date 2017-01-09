using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP_FindPath
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
        public static double TotalTime(List<DateTime> _listTimes)
        {
            double _totalTime = 0;
            for (int i = 0; i <= _listTimes.Count -2; i++)
            {
                int _dayOfYear = _listTimes[i].DayOfYear - _listTimes[i+1].DayOfYear;
                _totalTime += _listTimes[i].Hour * 3600 + _listTimes[i].Minute * 60 + _listTimes[i].Second + _dayOfYear * 86400 - _listTimes[i+1].Hour * 3600 + _listTimes[i + 1].Minute * 60 + _listTimes[i + 1].Second;
            }
            //przeliczenie na godziny
            _totalTime = Math.Round(_totalTime * 0.000277777777778,2);
            return _totalTime;
        }
        #endregion
        #region Przeliczanie całkowitego czasu trasy na dni, godziny, minuty, sekundy
        public static string TotalTrackTime()
        {
            Paramethers _param;
            _param = new Paramethers("path.gpx");
            TimeSpan _time;
            double _totalTime;
            _totalTime = TotalTime(_param.AllTimes);
            _time = TimeSpan.FromHours(_totalTime);
            return _time.ToString();
        }
        #endregion
        #region Przeliczenie całkowitego czasu pod górę
        public static string TotalClimbingTime()
        {
            Paramethers _param;
            _param = new Paramethers("path.gpx");
            double _TotalTime = 0;

            for (int i = 0; i <= _param.Height.Count - 2; i++)
            {
                if (_param.Height[i] < _param.Height[i + 1])
                    _TotalTime += TimeBeetwenTwoPath(_param.AllTimes[i], _param.AllTimes[i + 1]);
            }
            return TimeSpan.FromSeconds(_TotalTime).ToString();
        }
        #endregion
        #region Przeliczenie całkowitego czasu z górki
        public static string TotalDescentTime()
        {
            Paramethers _param;
            _param = new Paramethers("path.gpx");
            double _TotalTime = 0;

            for (int i = 0; i <= _param.Height.Count - 2; i++)
            {
                if (_param.Height[i] > _param.Height[i + 1])
                    _TotalTime += TimeBeetwenTwoPath(_param.AllTimes[i], _param.AllTimes[i + 1]);
            }
            return TimeSpan.FromSeconds(_TotalTime).ToString();
        }
        #endregion
        #region Przeliczenie całkowitego czasu po równum
        public static string TotalFlatTime()
        {
            Paramethers _param;
            _param = new Paramethers("path.gpx");
            double _TotalTime = 0;

            for (int i = 0; i <= _param.Height.Count - 2; i++)
            {
                if (_param.Height[i] == _param.Height[i + 1])
                    _TotalTime += TimeBeetwenTwoPath(_param.AllTimes[i], _param.AllTimes[i + 1]);
            }
            return TimeSpan.FromSeconds(_TotalTime).ToString();
        }
        #endregion
    }
}
