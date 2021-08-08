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
        public ArtilleryModel()
        {
            CalculatedTargetList = new List<TargetInformationModel>();
        }

        #endregion

        #region " Properties "

        public string Name { get; set; }
        public decimal FixedPointDirection { get; set; }
        public decimal FixedPointDistance { get; set; }
        public List<TargetInformationModel> CalculatedTargetList { get; set; }

        #endregion

        #region " Methods "



        #endregion
    }
}
