using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TempTable1
    {
        public int Id { get; set; }
        public short PlacementPointId { get; set; }
        public byte? GarmentTypeId { get; set; }
        public byte? GenderId { get; set; }
        public byte? BuyerId { get; set; }
    }
}
