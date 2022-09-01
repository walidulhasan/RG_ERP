using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblCategory
    {
        public CmblCategory()
        {
            CmblLog = new HashSet<CmblLog>();
        }
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<CmblLog> CmblLog { get; set; }
    }
}
