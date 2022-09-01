namespace RG.DBEntities.FiniteScheduler.DBViews
{
    public class VW_BuildingInfo
    {
        public int BuildingID { get; set; }
        public int BuildingTypeID { get; set; }
        public string BuildingTypeName { get; set; }
        public string BuildingName { get; set; }
        public string BuildingShortName { get; set; }
        public int BuildingSerial { get; set; }
        public string BuildingDescription { get; set; }
        public int BuildingFloorID { get; set; }
        public string FloorName { get; set; }
        public string FloorShortName { get; set; }
        public int FloorSerial { get; set; }
        public string FloorDescription { get; set; }
        public int FloorTypeID { get; set; }
        public string FloorTypeName { get; set; }
    }
}
