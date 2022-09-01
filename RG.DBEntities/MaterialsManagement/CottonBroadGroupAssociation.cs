using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonBroadGroupAssociation
    {
        public int Id { get; set; }
        public int BroadGroupId { get; set; }
        public int DocumentTypeId { get; set; }
        public DateTime? Date { get; set; }
    }
}
