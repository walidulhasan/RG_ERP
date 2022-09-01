using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DduserProfiles
    {
        public int Id { get; set; }
        public short UserId { get; set; }
        public int ProfileId { get; set; }
    }
}
