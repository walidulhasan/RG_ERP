using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class CbmBankFacility
    {
        public int? BankId { get; set; }
        public decimal? FinFacilityId { get; set; }
        public int? Coaid { get; set; }
        public string ContractNo { get; set; }
        public decimal? Limit { get; set; }
        public decimal? Rate { get; set; }
        public string Collateral { get; set; }
        public string Remarks { get; set; }
        public DateTime? RepaymentDate { get; set; }
        public DateTime? RenewalDate { get; set; }

        public virtual CBM_Bank Bank { get; set; }
    }
}
