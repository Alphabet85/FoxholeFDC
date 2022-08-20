namespace FoxholeFDC.Models
{
    public class TargetInformationModel

    {
        public ArtilleryModel Artillery { get; set; }
        public TargetInformationModel TargetInformation { get; set; }
        public int Direction { get; set; }
        public int Distance { get; set; }
    }
}
