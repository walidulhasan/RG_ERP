using RG.DBEntities.Embro.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Embro.Setup
{
    public class ChequeSignatoryMaster
    {
        public ChequeSignatoryMaster()
        {
            ChequeSignatoryDetail = new HashSet<ChequeSignatoryDetail>();
        }

        public int ID { get; set; }
        public decimal ApprovalLimit { get; set; }
        public int CompanyID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ChequeSignatoryDetail> ChequeSignatoryDetail { get; set; }
    }
}

