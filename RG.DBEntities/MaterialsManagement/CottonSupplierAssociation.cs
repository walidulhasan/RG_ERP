using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonSupplierAssociation
    {
        [Key]
        public long SupplierAssociationId { get; set; }
        public long IdentificationId { get; set; }
        public DateTime AssociationDate { get; set; }
    }
}
