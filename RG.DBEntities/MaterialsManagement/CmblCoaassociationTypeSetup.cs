using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblCoaassociationTypeSetup
    {
        [Key]
        public int RelationId { get; set; }
        public string Description { get; set; }
    }
}
