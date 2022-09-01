using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ViwLcothers
    {
        public int Id { get; set; }
        public int Lctype { get; set; }
        public long LcmId { get; set; }
        public int? LcaldCurrencyId { get; set; }
        public int? LcmBankLcdate { get; set; }
        public int LcaldMasterLcSalesContract { get; set; }
        public string LomCode { get; set; }
        public string LcaldBtblcno { get; set; }
        public string LcmCode { get; set; }
        public long? LcaldCompanyId { get; set; }
        public string Companyname { get; set; }
        public int? LcaldBankId { get; set; }
        public string BankName { get; set; }
        public string Suppliername { get; set; }
        public decimal? LcmPivalue { get; set; }
        public DateTime? LcaldLcdate { get; set; }
        public int? LcmDateofexpiry { get; set; }
        public string LcaldDescription { get; set; }
        public long? LcaldVendorId { get; set; }
        public decimal? LcaldAmount { get; set; }
        public decimal? LcaldCurrencyRate { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? PreparedBy { get; set; }
        public string LcaldLctype { get; set; }
        public string Currencysymbol { get; set; }
        public decimal? Ratioamt { get; set; }
    }
}
