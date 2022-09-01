using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class Signatory
    {
        public Signatory()
        {
            ChequeSignatoryDetail = new HashSet<ChequeSignatoryDetail>();
        }

        public int Id { get; set; }
        public string SignatoryName { get; set; }

        public virtual ICollection<ChequeSignatoryDetail> ChequeSignatoryDetail { get; set; }
    }
}
