using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonContractMaster
    {
        [Key]
        public long ContractId { get; set; }
        public string ContractNo { get; set; }
        public int ContractStatus { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentTerm { get; set; }
        public int UserId { get; set; }
        public int ApprvAuthorityId { get; set; }
        public long SupplierId { get; set; }
        public int? LocationSelStatus { get; set; }
        public int? DateSelStatus { get; set; }
        public int? PriceSelStatus { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? NoOfDays { get; set; }
        public int? ApprovedBy { get; set; }
        public string MainComments { get; set; }
    }
}
