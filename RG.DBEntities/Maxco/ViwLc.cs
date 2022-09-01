using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ViwLc
    {
        public int Id { get; set; }
        public long Lcmainid { get; set; }
        public int Lctype { get; set; }
        public long LmcId { get; set; }
        public int? LcaldCurrencyId { get; set; }
        public DateTime? LmcBankLcdate { get; set; }
        public long LcaldMasterLcSalesContract { get; set; }
        public string LomCode { get; set; }
        public string LcaldBtblcno { get; set; }
        public string LmcCode { get; set; }
        public long? LcaldCompanyId { get; set; }
        public string Companyname { get; set; }
        public long LcaldBankId { get; set; }
        public string BankName { get; set; }
        public string Suppliername { get; set; }
        public decimal? LmcVendorpivalue { get; set; }
        public DateTime LcaldLcdate { get; set; }
        public DateTime LmcDateofexpiry { get; set; }
        public string LcaldDescription { get; set; }
        public long LcaldVendorId { get; set; }
        public double LcaldAmount { get; set; }
        public double? LcaldCurrencyRate { get; set; }
        public DateTime? CreationDate { get; set; }
        public long? PreparedBy { get; set; }
        public string LcaldLctype { get; set; }
        public string Currencysymbol { get; set; }
        public decimal? Pivalue { get; set; }
    }
}
