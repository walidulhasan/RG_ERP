using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmLcsMaster
    {
        [Key]
        public int LcsmasterId { get; set; }
        public string Lcsnumber { get; set; }
        public string Mplnumber { get; set; }
        public long? SupplierId { get; set; }
        public long? GdmasterId { get; set; }
        public string ProformaInvoiceNo { get; set; }
        public string ClearingAgentBillNo { get; set; }
        public DateTime? ReceivingDate { get; set; }
        public double? NetWeight { get; set; }
        public string PackageDetail { get; set; }
        public double? ProvisionalAmount { get; set; }
        public double? Lcsversion { get; set; }
        public bool? Finalized { get; set; }
        public int CurrencyId { get; set; }
        public double ExchangeRate { get; set; }
        public double CalculatedLcsrate { get; set; }
        public double EnteredCommInvValue { get; set; }
    }
}
