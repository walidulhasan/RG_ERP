using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblCoaassociationTypeBkup
    {
        [Key]
        public long? Bg1id { get; set; }
        public long? Coaid { get; set; }
        public int? RelationId { get; set; }
    }
}
