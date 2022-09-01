using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonDocumentTypeSetup
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public int? IsSearchCriteria { get; set; }
    }
}
