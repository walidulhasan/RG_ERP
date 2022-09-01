using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class Attachment
    {
        [Key]
        public long AttachmentId { get; set; }
        public int StyleId { get; set; }
        public string FileName { get; set; }
        public string BackFileName { get; set; }
        public int TypeId { get; set; }
        public int? FabricColorId { get; set; }

        public virtual AttachmentTypesSetup Type { get; set; }
    }
}
