using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class FsDocumentTypeSetup
    {
        public int Id { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public string Initials { get; set; }
    }
}
