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
        public static double MinimumSpeed(Paramethers _param)
        {
            
            //_param = Document.GetDataFromDocument(new Paramethers());
            double speed1 = 0;
            double speed2 = 100;
            for (int i = 0; i <= _param.Longitude.Count - 2; i++)
            {
                double _distance = Math.Round(Distance.DistanceBeetwenTwoPath(_param.Latitude[i], _param.Longitude[i], _param.Latitude[i + 1], _param.Longitude[i + 1]), 3);
                //total = Math.Round(total + run, 3);
                int _time = Time.TimeBeetwenTwoPath(_param.AllTimes[i], _param.AllTimes[i + 1]);
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
        public static double MaximumSpeed(Paramethers _param)
        {
           
            // _param = Document.GetDataFromDocument(new Paramethers());
            double speed1 = 0;
            double speed2 = 0;
            for (int i = 0; i <= _param.Longitude.Count - 2; i++)
            {
                double _distance = Math.Round(Distance.DistanceBeetwenTwoPath(_param.Latitude[i], _param.Longitude[i], _param.Latitude[i + 1], _param.Longitude[i + 1]), 3);
                //total = Math.Round(total + run, 3);
                int _time = Time.TimeBeetwenTwoPath(_param.AllTimes[i], _param.AllTimes[i+1]);
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
        public static double AverageSpeed(Paramethers _param)
        {
            
            double _averageSpeed = 0;
            _averageSpeed = Math.Round(Distance.TotalDistance( _param) / Time.TotalTime(_param.AllTimes),3);
            return _averageSpeed;
        }
        #endregion
        #region Przeliczanie średniej prędkości pod górę w km/h
        public static double AverageClimbingSpeed(Paramethers _param)
        {
           
            double _averageSpeed = 0;
            double _distance = 0;
            double _time = 0;
           // _param = Document.GetDataFromDocument(new Paramethers());
            for (int i = 0; i <= _param.Longitude.Count -2; i++)
            {
                if (_param.Height[i] < _param.Height[i + 1])
                {
                    _distance += Math.Round(Distance.DistanceBeetwenTwoPath(_param.Latitude[i], _param.Longitude[i], _param.Latitude[i + 1], _param.Longitude[i + 1]), 3);
                    _time += Time.TimeBeetwenTwoPath(_param.AllTimes[i], _param.AllTimes[i + 1]);
                }
            }
            //przeliczenie na godziny
            _time = Math.Round(_time * 0.000277777778,2);
            _averageSpeed = Math.Round(_distance / _time, 3);
            return _averageSpeed;
        }
        #endregion
        #region Przeliczanie średniej prędkości z górki w km/h
        public static double AverageDescentSpeed(Paramethers _param)
        {

            double _averageSpeed = 0;
            double _distance = 0;
            double _time = 0;
           // _param = Document.GetDataFromDocument(new Paramethers());
            for (int i = 0; i <= _param.Longitude.Count - 2; i++)
            {
                if (_param.Height[i] > _param.Height[i + 1])
                {
                    _distance += Math.Round(Distance.DistanceBeetwenTwoPath(_param.Latitude[i], _param.Longitude[i], _param.Latitude[i + 1], _param.Longitude[i + 1]), 3);
                    _time += Time.TimeBeetwenTwoPath(_param.AllTimes[i], _param.AllTimes[i + 1]);
                }
            }
            //przeliczenie na godziny
            _time = Math.Round(_time * 0.000277777778, 2);
            _averageSpeed = Math.Round(_distance / _time, 3);
            return _averageSpeed;
        }
        #endregion
        #region Przeliczanie średniej prędkości na płaskim w km/h
        public static double AverageFlatSpeed(Paramethers _param)
        {
            double _averageSpeed = 0;
            double _distance = 0;
            double _time = 0;
            //_param = Document.GetDataFromDocument(new Paramethers());
            for (int i = 0; i <= _param.Longitude.Count - 2; i++)
            {
                if (_param.Height[i] == _param.Height[i + 1])
                {
                    _distance += Math.Round(Distance.DistanceBeetwenTwoPath(_param.Latitude[i], _param.Longitude[i], _param.Latitude[i + 1], _param.Longitude[i + 1]), 3);
                    _time += Time.TimeBeetwenTwoPath(_param.AllTimes[i], _param.AllTimes[i + 1]);
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
