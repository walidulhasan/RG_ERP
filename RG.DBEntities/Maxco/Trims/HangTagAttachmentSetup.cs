using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class HangTagAttachmentSetup
    {
        public HangTagAttachmentSetup()
        {
           // HangTagSpecification = new HashSet<HangTagSpecification>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        //public virtual ICollection<HangTagSpecification> HangTagSpecification { get; set; }
    }
}
