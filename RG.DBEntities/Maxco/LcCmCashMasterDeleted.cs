using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcCmCashMasterDeleted
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ActionDate { get; set; }
        public int LcmId { get; set; }
        public string LcmCode { get; set; }
        public short? LcmModuserid { get; set; }
        public DateTime? LcmLastmoddate { get; set; }
        public int? LcmItemid { get; set; }
        public int LcmVendorId { get; set; }
        public int? LcmCompanyId { get; set; }
        public int? LcmCompanybankId { get; set; }
        public int? LcmBankaccountid { get; set; }
        public int LcmIssuancecityid { get; set; }
        public DateTime LcmDateofissuance { get; set; }
        public int LcmExpirycityid { get; set; }
        public DateTime LcmDateofexpiry { get; set; }
        public int LcmLccondition { get; set; }
        public string LcmLcano { get; set; }
        public string LcmIrcno { get; set; }
        public string LcmInssurancecom { get; set; }
        public string LcmInssurancecomadd { get; set; }
        public string LcmInssurancecomnoteno { get; set; }
        public string LcmHscode { get; set; }
        public int? HsodeId { get; set; }
        public string LcmPortofshipment { get; set; }
        public string LcmPortofdisscharge { get; set; }
        public string LcmModofshipment { get; set; }
        public DateTime LcmCreationdate { get; set; }
        public int LcmCreationuserid { get; set; }
        public string LcmSpecialcomments { get; set; }
        public string LcmBankno { get; set; }
        public int? LcmMapstatus { get; set; }
        public string LcmContryOrigin { get; set; }
        public int? LomId { get; set; }
        public int? Currency { get; set; }
    }
}
