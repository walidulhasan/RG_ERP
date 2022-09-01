using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcAldAcceptanceLiabilityMaster
    {
        public int Id { get; set; }
        public long LcinputId { get; set; }
        public string LcaldRefNo { get; set; }
        public long? LcaldCompanyId { get; set; }
        public long? LcaldVendorId { get; set; }
        public string LcaldDescription { get; set; }
        public string LcaldLctype { get; set; }
        public string LcaldBtblcno { get; set; }
        public DateTime? LcaldLcdate { get; set; }
        public int? LcaldBankId { get; set; }
        public int? LcaldCurrencyId { get; set; }
        public DateTime? LcaldOurAcceptanceDate { get; set; }
        public DateTime? LcaldBankRecvDate { get; set; }
        public decimal? LcaldAmount { get; set; }
        public decimal? LcaldCurrencyRate { get; set; }
        public DateTime? LcaldBankMaturityDate { get; set; }
        public string LcaldMasterLcSalesContract { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? PreparedBy { get; set; }
    }
}
