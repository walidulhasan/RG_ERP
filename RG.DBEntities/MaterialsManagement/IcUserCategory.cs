using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class IcUserCategory
    {
        public int Id { get; set; }
        public int? Userid { get; set; }
        public int? CategoryId { get; set; }
    }
}
