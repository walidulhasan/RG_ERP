using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class AttachmentTypesSetup
    {
        public AttachmentTypesSetup()
        {
            Attachment = new HashSet<Attachment>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Attachment> Attachment { get; set; }
    }
}
