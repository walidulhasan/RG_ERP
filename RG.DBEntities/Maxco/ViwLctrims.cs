using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ViwLctrims
    {
        public int Id { get; set; }
        public int Lctype { get; set; }
        public int LmcId { get; set; }
        public int? LcaldCurrencyId { get; set; }
        public DateTime? LmcBankLcdate { get; set; }
        public int LcaldMasterLcSalesContract { get; set; }
        public string LomCode { get; set; }
        public string LcaldBtblcno { get; set; }
        public string LmcCode { get; set; }
        public int? LcaldCompanyId { get; set; }
        public string Companyname { get; set; }
        public int LcaldBankId { get; set; }
        public string BankName { get; set; }
        public string Suppliername { get; set; }
        public decimal? LmcVendorpivalue { get; set; }
        public DateTime LcaldLcdate { get; set; }
        public DateTime LmcDateofexpiry { get; set; }
        public string LcaldDescription { get; set; }
        public int LcaldVendorId { get; set; }
        public double LcaldAmount { get; set; }
        public double? LcaldCurrencyRate { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? PreparedBy { get; set; }
        public string LcaldLctype { get; set; }
        public string Currencysymbol { get; set; }
        public decimal? Pivalue { get; set; }
    }
}
