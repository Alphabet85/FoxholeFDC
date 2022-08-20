namespace FoxholeFDC.Models
{
    public class TargetInformationModel
    {
        public TargetInformationModel()
        {
            Artillery = new ArtilleryModel();
        }

        #region " Properties "

        public ArtilleryModel Artillery { get; set; }
        public string Name{ get; set; }
        public int Direction { get; set; }
        public int Distance { get; set; }

        #endregion
    }
}
