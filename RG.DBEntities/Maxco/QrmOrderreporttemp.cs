using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class QrmOrderreporttemp
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public long? StyleId { get; set; }
        public string StyleName { get; set; }
        public string CollectionName { get; set; }
        public string FabricCategory { get; set; }
        public DateTime? LabelTransactionDate { get; set; }
        public DateTime? HangtagTransactionDate { get; set; }
        public DateTime? ZipperTransactionDate { get; set; }
        public DateTime? ButtonTransactionDate { get; set; }
        public DateTime? StudsTransactionDate { get; set; }
        public DateTime? TwillTapeTransactionDate { get; set; }
        public DateTime? LaceTransactionDate { get; set; }
        public DateTime? BeadTransactionDate { get; set; }
        public DateTime? ElasticTransactionDate { get; set; }
        public DateTime? EyeletTransactionDate { get; set; }
        public DateTime? PullerTransactionDate { get; set; }
        public DateTime? SizeRangeTransactionDate { get; set; }
        public DateTime? EmbroTransactionDate { get; set; }
        public DateTime? PrintTransactionDate { get; set; }
        public DateTime? FabricTransactionDate { get; set; }
        public DateTime? GatransactionDate { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public DateTime? KnitsRequirementDate { get; set; }
        public DateTime? WovenRequirementDate { get; set; }
        public DateTime? DenimRequirementDate { get; set; }
    }
}
