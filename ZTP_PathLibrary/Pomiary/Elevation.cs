using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZTP_PathLibrary
{
    public static class Elevation
    {
        #region Obliczanie minimalnej wysokości wzniesienia
        public static double MinimumElevation(List<Points> _points)
        {
            List<double> _Height = new List<double>();
            foreach (var _onePoint in _points)
            {
                _Height.Add(_onePoint.ele);
            }
            return Math.Round(_Height.Min(), 2);
        }
        #endregion
        #region Obliczanie średniej wspinania
        public static double AverageElevation(List<Points> _points)
        {
            List<double> _Height = new List<double>();
            foreach(var _onePoint in _points)
            {
                _Height.Add(_onePoint.ele);
            }
            return Math.Round(_Height.Average(), 2);
        }
        #endregion
        #region Obliczanie całkowitego wspinania
        public static double TotalClimbing(List<Points> _points)
        {
           
            double _height = 0;

            for (int i = 0; i <= _points.Count -2; i++)
            {
                if (_points[i].ele < _points[i + 1].ele)
                    _height += _points[i + 1].ele - _points[i].ele;
            }
            return Math.Round(_height,3);    
        }
        #endregion
        #region Obliczanie całkowitego schodzenia
        public static double TotalDescent(List<Points> _points)
        {
            
            double _height = 0;

           

            for (int i = 0; i <= _points.Count - 2; i++)
            {
                if (_points[i].ele > _points[i + 1].ele)
                    _height += _points[i].ele - _points[i + 1].ele;
            }
            return Math.Round(_height, 3);
        }
        #endregion
    }
}