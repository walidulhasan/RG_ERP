using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonIssuanceRequisitionDetail
    {
        public int Id { get; set; }
        public int Irid { get; set; }
        public double LotNo { get; set; }
        public double Sl { get; set; }
        public double Ur { get; set; }
        public double Sfi { get; set; }
        public double Str { get; set; }
        public double Mic { get; set; }
        public double Rd { get; set; }
        public double Plusb { get; set; }
        public double ColorGrade { get; set; }
        public double Moisture { get; set; }
        public double Trash { get; set; }
        public int RequiredBales { get; set; }
        public long? AttributeInstanceId { get; set; }
        public int? Balance { get; set; }

        public virtual CottonIssuanceRequisitionMaster Ir { get; set; }
    }
}
