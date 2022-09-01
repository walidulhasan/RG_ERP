using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class TrimInspectionDetail
    {
        [Key]
        public int TrimInspectionDid { get; set; }
        public int MinspectionMid { get; set; }
        public double InspectedQuantity { get; set; }
        public int StoreLocationId { get; set; }
        public int ReasonId { get; set; }
        public int TrimIqid { get; set; }
        public int TrimInspectionResultId { get; set; }
        public int? ShipmentId { get; set; }
        public int? Status { get; set; }

        public virtual ReasonSetup Reason { get; set; }
        public virtual StoreLocationSetup StoreLocation { get; set; }
        public virtual TrimInspectionResultSetup TrimInspectionResult { get; set; }
        public virtual TrimInventoryQuantity TrimIq { get; set; }
    }
}
