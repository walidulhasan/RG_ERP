using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblMarkerInfo
    {
        public int MarkerId { get; set; }
        public string MarkerName { get; set; }
        public decimal? MarkerConsumption { get; set; }
        public decimal? MLength { get; set; }
        public string MLengthType { get; set; }
        public decimal? MWidth { get; set; }
        public string MWidthType { get; set; }
        public decimal? DeltaHor { get; set; }
        public decimal? DeltaVer { get; set; }
        public decimal? MGsm { get; set; }
        public DateTime? PlanDate { get; set; }
        public decimal? MLayerWeight { get; set; }
        public string MSizeRatio { get; set; }
        public int? PatternPiece { get; set; }
        public decimal? Efficiency { get; set; }
        public int? UserId { get; set; }
        public DateTime? HDate { get; set; }
        public int? Companyid { get; set; }
        public int? Buyerid { get; set; }
        public string SpreadingTable { get; set; }
        public DateTime? SpreadingDate { get; set; }
        public decimal? CutMLength { get; set; }
        public DateTime? SpEndDateTime { get; set; }
        public DateTime? CreationDate { get; set; }
        public long? RequisitionId { get; set; }
    }
}
