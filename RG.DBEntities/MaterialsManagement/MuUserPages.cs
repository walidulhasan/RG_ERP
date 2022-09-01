using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MuUserPages
    {
        public int UserId { get; set; }
        public int PageId { get; set; }
        public int? MenuId { get; set; }
        public int Id { get; set; }
    }
}
