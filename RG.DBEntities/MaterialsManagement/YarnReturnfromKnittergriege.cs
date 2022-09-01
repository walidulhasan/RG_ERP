using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnReturnfromKnittergriege
    {
        [Key]
        public long RfkId { get; set; }
        public long KnittingContractId { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal ReturnedGreigeFabric { get; set; }

        public virtual Yarn_KnittingContractMaster Yarn_KnittingContractMaster { get; set; }
    }
}
