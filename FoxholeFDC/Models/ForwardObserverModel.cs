namespace FoxholeFDC.Models
{
    public class ForwardObserverModel
    {
        #region " Constructor "

        /// <summary>
        /// Forward Observer
        /// </summary>
        /// <param name="_name">Name of Forward Observer</param>
        public ForwardObserverModel(string _name)
        {
            Name = _name;
            UnitType = WhoAreYou.ForwardObserver;
        }

        #endregion 

        #region " Properties "

        public string Name { get; set; }
        public WhoAreYou UnitType { get; set; }
        public decimal DistanceToFixedPoint { get; set; }
        public decimal DirectionToFixedPoint { get; set; }
        public TargetInformation FOTargetInformation { get; set; }

        #endregion

        #region " Methods "

        /// <summary>
        /// Input for target information from Forward Observer
        /// </summary>
        /// <param name="_name">Target Name</param>
        /// <param name="_distanceToTarget">Distance from FO to Target</param>
        /// <param name="_directionToTarget">Direction from FO to Target</param>
        public void SetTargetInfo(string _name, decimal _distanceToTarget, decimal _directionToTarget)
        {
            FOTargetInformation.Name = _name;
            FOTargetInformation.Distance = _distanceToTarget;
            FOTargetInformation.Direction = _directionToTarget;
        }

        /// <summary>
        /// Input for setting fixed point information from Forward Observer
        /// </summary>
        /// <param name="_distanceToFP">Distance from FO to FP</param>
        /// <param name="_directionToFP">Direction from FO to FP</param>
        public void SetFixedPointInfo(decimal _distanceToFP, decimal _directionToFP)
        {
            DistanceToFixedPoint = _distanceToFP;
            DirectionToFixedPoint = _directionToFP;
        }

        #endregion
    }
}
