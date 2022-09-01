using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class ExceptionMessagesSetup
    {
        public ExceptionMessagesSetup()
        {
            TargetDomainSetup = new HashSet<TargetDomainSetup>();
        }
        public int Id { get; set; }
        public int MessageId { get; set; }
        public string Description { get; set; }
        public int DomainId { get; set; }
        public bool? IsJustificationRequired { get; set; }

        public virtual ICollection<TargetDomainSetup> TargetDomainSetup { get; set; }
    }
}
