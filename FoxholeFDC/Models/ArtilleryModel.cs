using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeFDC.Models
{
    public class ArtilleryModel
    {
        #region " Constructor "

        /// <summary>
        /// Constructor for Artillery
        /// </summary>
        /// <param name="_name">Name of Artillery unit</param>
        public ArtilleryModel(string _name)
        {
            Name = _name;
        }

        #endregion

        #region " Properties "

        public string Name { get; set; }
        public decimal FixedPointDirection { get; set; }
        public decimal FixedPointDistance { get; set; }
        public decimal CalculatedTargetDistance { get; set; }
        public decimal CalculatedTargetDirection { get; set; }
        public TargetInformation CalculatedTarget { get; set; }

        #endregion

        #region " Methods "

        /// <summary>
        /// Set fixed point location from artillery unit
        /// </summary>
        /// <param name="_fPDirection">Fixed point direction</param>
        /// <param name="_fPDistance">Fixed point distrance</param>
        public void SetFixedPointLocation(decimal _fPDirection, decimal _fPDistance)
        {
            FixedPointDirection = _fPDirection;
            FixedPointDistance = _fPDistance;
        }

        #endregion
    }
}
