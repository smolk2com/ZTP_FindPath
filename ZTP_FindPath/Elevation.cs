using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP_FindPath
{
    public static class Elevation
    {
        #region Obliczanie całkowitego wspinania
        public static double TotalClimbing()
        {
            Paramethers _param;
            _param = new Paramethers("path.gpx");
            double _height = 0;

            for (int i = 0; i <= _param.Height.Count -2; i++)
            {
                if (_param.Height[i] < _param.Height[i + 1])
                    _height += _param.Height[i + 1] - _param.Height[i];
            }
            return Math.Round(_height,3);    
        }
        #endregion
        #region Obliczanie całkowitego schodzenia
        public static double TotalDescent()
        {
            Paramethers _param;
            _param = new Paramethers("path.gpx");
            double _height = 0;

            for (int i = 0; i <= _param.Height.Count - 2; i++)
            {
                if (_param.Height[i] > _param.Height[i + 1])
                    _height += _param.Height[i] - _param.Height[i + 1];
            }
            return Math.Round(_height, 3);
        }
        #endregion
    }
}