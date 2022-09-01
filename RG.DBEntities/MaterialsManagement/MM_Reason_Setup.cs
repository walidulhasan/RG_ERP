using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MM_Reason_Setup
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int DocumentTypeID { get; set; }
    }
}
