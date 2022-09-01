using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsLotVariationFabrics
    {
        public int Id { get; set; }
        public int Fid { get; set; }
        public double ReceivedQuantityKgs { get; set; }
        public int NoOfRolls { get; set; }
        public double ReceivedWidth { get; set; }
        public double ReceivedGsm { get; set; }
        public long? NoOfPieces { get; set; }
        public int TypeId { get; set; }
        public int LotVariationId { get; set; }
    }
}
