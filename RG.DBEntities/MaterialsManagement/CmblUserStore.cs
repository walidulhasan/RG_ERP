using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblUserStore
    {
        [Key]
        public int StoreId { get; set; }
        public int UserId { get; set; }
    }
}
