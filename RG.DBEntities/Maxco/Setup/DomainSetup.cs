using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class DomainSetup
    {
        public DomainSetup()
        {
            UserSetup = new HashSet<UserSetup>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }
        public string HomePage { get; set; }
        public int ServerId { get; set; }
        public int? WorkCenterId { get; set; }

        public virtual ICollection<UserSetup> UserSetup { get; set; }
    }
}
