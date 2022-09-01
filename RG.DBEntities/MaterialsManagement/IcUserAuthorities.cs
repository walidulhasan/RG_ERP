using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class IcUserAuthorities
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public byte AuthorityLevelId { get; set; }
        public short DocumentId { get; set; }
        public long AuthorizedBy { get; set; }
        public DateTime? AuthorizedOn { get; set; }
    }
}
