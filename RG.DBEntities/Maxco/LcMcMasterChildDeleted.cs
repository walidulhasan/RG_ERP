using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcMcMasterChildDeleted
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Actiondate { get; set; }
        public int LmcId { get; set; }
        public int LomId { get; set; }
        public string LmcCode { get; set; }
        public string LmcLcno { get; set; }
        public short? LmcModuserid { get; set; }
        public DateTime? LmcLastmoddate { get; set; }
        public int LmcVendorId { get; set; }
        public int LmcCompanybankId { get; set; }
        public int? LmcBankaccountid { get; set; }
        public int LmcIssuancecityid { get; set; }
        public DateTime LmcDateofissuance { get; set; }
        public int LmcExpirycityid { get; set; }
        public DateTime LmcDateofexpiry { get; set; }
        public int LmcLccondition { get; set; }
        public string LmcLcano { get; set; }
        public string LmcIrcno { get; set; }
        public string LmcInssurancecom { get; set; }
        public string LmcInssurancecomadd { get; set; }
        public string LmcInssurancecomnoteno { get; set; }
        public string LmcHscode { get; set; }
        public int? HscodeId { get; set; }
        public string LmcPortofdisscharge { get; set; }
        public DateTime? LmcCreationdate { get; set; }
        public int? LmcCreationuserid { get; set; }
        public string LmcSpecialcomments { get; set; }
        public int? LltId { get; set; }
        public int? LlsId { get; set; }
        public string LmcVendorpi { get; set; }
        public decimal? LmcVendorpivalue { get; set; }
        public DateTime? LmcVendorpidate { get; set; }
        public string LmcCntryOrigin { get; set; }
        public string LmcModeShipment { get; set; }
        public string LmcPortShipment { get; set; }
        public string LmcHeader { get; set; }
        public string LmcFooter { get; set; }
        public string LmcConditions { get; set; }
        public string LmcPaymentTerms { get; set; }
        public int? Currency { get; set; }
    }
}
