using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TblTexting
    {
        public int Id { get; set; }
        public int Krsid { get; set; }
        public int Fabid { get; set; }
        public int Typeid { get; set; }
        public string FaricType { get; set; }
        public int Qualityid { get; set; }
        public string FabricQuality { get; set; }
        public string FabComposition { get; set; }
        public int Gsm { get; set; }
        public long OrderId { get; set; }
        public string OrderNo { get; set; }
        public long YarnKncontractId { get; set; }
        public string ContractName { get; set; }
        public double? RatePerKg { get; set; }
        public DateTime? ContractDate { get; set; }
    }
}
