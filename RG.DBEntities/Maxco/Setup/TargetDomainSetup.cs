using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class TargetDomainSetup
    {
        public TargetDomainSetup()
        {
            TargetDomainMessage = new HashSet<TargetDomainMessage>();
        }

        public int MessageId { get; set; }
        public int? TargetDomainId { get; set; }
        public int? TargetUserId { get; set; }
        public int Id { get; set; }

        public virtual ExceptionMessagesSetup Message { get; set; }
        public virtual ICollection<TargetDomainMessage> TargetDomainMessage { get; set; }
    }
}
