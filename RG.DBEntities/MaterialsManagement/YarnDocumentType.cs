using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnDocumentType
    {
        public int? DocumentTypeId { get; set; }
        public string Description { get; set; }
        public int? StatusOfStockTransaction { get; set; }
    }
}
