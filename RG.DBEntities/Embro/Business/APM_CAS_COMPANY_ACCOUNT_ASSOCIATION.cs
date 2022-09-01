using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class APM_CAS_COMPANY_ACCOUNT_ASSOCIATION
    {
        public int CAS_ID { get; set; }
        public int? CAS_COMPANY_1_ID { get; set; }
        public int? CAS_COMPANY_1_ACCOUNTID { get; set; }
        public int? CAS_COMPANY_2_ID { get; set; }
        public int? CAS_COMPANY_2_ACCOUNTID { get; set; }
    }
}
