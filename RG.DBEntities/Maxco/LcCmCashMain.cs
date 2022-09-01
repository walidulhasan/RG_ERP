using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcCmCashMain
    {
        public int Id { get; set; }
        public int LcmId { get; set; }
        public string LcmCode { get; set; }
        public DateTime LcmLastmoddate { get; set; }
        public short LcmModuserid { get; set; }
        public int LcmCompanybankId { get; set; }
        public int LcmItemId { get; set; }
        public byte LcmBuyerid { get; set; }
        public int LcmIssuancecityid { get; set; }
        public DateTime LcmDateofissuance { get; set; }
        public int LcmExpirycityid { get; set; }
        public DateTime LcmDateofexpiry { get; set; }
        public int LcmLccondition { get; set; }
        public int LcmVendorId { get; set; }
    }
}
