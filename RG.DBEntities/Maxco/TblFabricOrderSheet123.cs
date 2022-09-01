using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TblFabricOrderSheet123
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string OrderNo { get; set; }
        public string PantoneNo { get; set; }
        public long ShellId { get; set; }
        public double FinishFabricConsumption { get; set; }
        public string FabricTrim { get; set; }
        public string Ftype { get; set; }
        public string Fquality { get; set; }
        public int? Gsm { get; set; }
        public int? FinishedWidth { get; set; }
        public long? OrderQty { get; set; }
        public double? FabricqtyKgs { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? FabricSet { get; set; }
        public int FabricSpecType { get; set; }
        public string FabricSpecTypeDesc { get; set; }
        public double? DyeingWastagePerFrac { get; set; }
        public long FabricId { get; set; }
        public string FabricComposition { get; set; }
        public string StyleDescription { get; set; }
        public long Krsid { get; set; }
        public DateTime? KnittingDate { get; set; }
        public DateTime? Aopdate { get; set; }
        public DateTime? FabricDate { get; set; }
        public bool? DeliveryClosed { get; set; }
    }
}
