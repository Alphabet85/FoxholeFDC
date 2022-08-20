using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeFDC.Models
{
    public class TargetSolutionModel
    {
        #region " Constructor "

        public TargetSolutionModel(ArtilleryModel _artilleryModel, TargetInformationModel _selectedTarget, double _fOFPDirection, double _fOFPDistance)
        {
            ArtillerySolutionToTarget = new TargetInformationModel
            {
                Artillery = _artilleryModel,
                Name = _selectedTarget.Name
            };

            UpdateTargetSolutions(_fOFPDirection, _fOFPDistance);
        }

        #endregion

        #region " Properties "

        public TargetInformationModel ArtillerySolutionToTarget { get; set; }

        #endregion

        #region " Methods "

        public void UpdateTargetSolutions(double _fOFPDirection, double _fOFPDistance)
        {
            ArtillerySolutionToTarget.Direction = GetRoundedDirectionToTarget(ArtillerySolutionToTarget, _fOFPDirection, _fOFPDistance);
            ArtillerySolutionToTarget.Distance = GetRoundedDistanceToTarget(ArtillerySolutionToTarget, _fOFPDirection, _fOFPDistance);
        }

        private int GetRoundedDirectionToTarget(TargetInformationModel _selectedTarget, double _fOFPDirection, double _fOFPDistance)
        {
            double _radsResult = 0;

            // Arty FP to Gun distance multiplied by cos
            double _xForGun = ArtillerySolutionToTarget.Artillery.FixedPointDistance * Math.Cos(ConvertDegreesToRadians(ArtillerySolutionToTarget.Artillery.FixedPointDirection + 180));
            double _yForGun = ArtillerySolutionToTarget.Artillery.FixedPointDistance * Math.Sin(ConvertDegreesToRadians(ArtillerySolutionToTarget.Artillery.FixedPointDirection + 180));

            // xyFOtoFP + xyFOtoTarget + xyWind
            double _xSum = (_fOFPDistance * Math.Cos(ConvertDegreesToRadians(_fOFPDirection + 180))) + (_selectedTarget.Distance * Math.Cos(ConvertDegreesToRadians(_selectedTarget.Direction))) + 0;
            double _ySum = (_fOFPDistance * Math.Sin(ConvertDegreesToRadians(_fOFPDirection + 180))) + (_selectedTarget.Distance * Math.Sin(ConvertDegreesToRadians(_selectedTarget.Direction))) + 0;

            double _gunToTargetX = _xForGun + _xSum;
            double _gunToTargetY = _yForGun + _ySum;

            double _rads = Math.Atan2(_gunToTargetY, _gunToTargetX);

            if (Math.Atan2(_gunToTargetY, _gunToTargetX) < 0)
            {
                _radsResult = 360;
            }

            return (int)Math.Round(ConvertRadiansToDegrees(_rads) + _radsResult);
        }

        private int GetRoundedDistanceToTarget(TargetInformationModel _selectedTarget, double _fOFPDirection, double _fOFPDistance)
        {
            // Arty FP to Gun distance multiplied by cos
            double _xForGun = ArtillerySolutionToTarget.Artillery.FixedPointDistance * Math.Cos(ConvertDegreesToRadians(ArtillerySolutionToTarget.Artillery.FixedPointDirection + 180));
            double _yForGun = ArtillerySolutionToTarget.Artillery.FixedPointDistance * Math.Sin(ConvertDegreesToRadians(ArtillerySolutionToTarget.Artillery.FixedPointDirection + 180));

            // xyFOtoFP + xyFOtoTarget + xyWind
            double _xSum = (_fOFPDistance * Math.Cos(ConvertDegreesToRadians(_fOFPDirection + 180))) + (_selectedTarget.Distance * Math.Cos(ConvertDegreesToRadians(_selectedTarget.Direction))) + 0;
            double _ySum = (_fOFPDistance * Math.Sin(ConvertDegreesToRadians(_fOFPDirection + 180))) + (_selectedTarget.Distance * Math.Sin(ConvertDegreesToRadians(_selectedTarget.Direction))) + 0;

            double _gunToTargetX = _xForGun + _xSum;
            double _gunToTargetY = _yForGun + _ySum;

            return (int)Math.Round(Math.Sqrt(Math.Pow((double)_gunToTargetX, 2) + Math.Pow((double)_gunToTargetY, 2)));
        }

        private double ConvertRadiansToDegrees(double _radians)
        {
            return 180 / Math.PI * _radians;
        }

        private double ConvertDegreesToRadians(double _degrees)
        {
            return Math.PI / 180 * _degrees;
        }

        #endregion
    }
}
