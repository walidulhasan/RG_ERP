using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnRequisitionMasterRegeneration
    {
        public int Id { get; set; }
        public long YarnReqId { get; set; }
        public DateTime? YarnReqDate { get; set; }
        public int? YarnReqStatus { get; set; }
        public string UserName { get; set; }
        public bool? AutomatedRequisition { get; set; }
        public int? UserId { get; set; }
        public string YarnReqNo { get; set; }
        public bool IsDependent { get; set; }
        public string Date { get; set; }
        public long? CompanyId { get; set; }
        public int? BusinessId { get; set; }
    }
}
