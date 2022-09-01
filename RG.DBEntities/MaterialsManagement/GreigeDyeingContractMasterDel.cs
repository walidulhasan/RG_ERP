using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class GreigeDyeingContractMasterDel
    {
        public int Id { get; set; }
        public string DyeingContractNo { get; set; }
        public int? SigningAuthorityId { get; set; }
        public int? DyerId { get; set; }
        public string SpecialComments { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Status { get; set; }
        public int? UserId { get; set; }
        public int? DeliveryDateSelection { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentTerm { get; set; }
        public int? PaymentTermDays { get; set; }
        public string PaymentSubTerm { get; set; }
        public int? DyeingSourceId { get; set; }
        public DateTime? ActionDate { get; set; }
    }
}
