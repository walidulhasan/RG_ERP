using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmStoreCategorySetup
    {
        public MmStoreCategorySetup()
        {
            MmStoreCategoryRelation = new HashSet<MM_StoreCategoryRelation>();
        }
        [Key]
        public int StoreCategoryId { get; set; }
        public string Scname { get; set; }
        public string Scdescription { get; set; }
        public string Sccode { get; set; }

        public virtual ICollection<MM_StoreCategoryRelation> MmStoreCategoryRelation { get; set; }
    }
}
