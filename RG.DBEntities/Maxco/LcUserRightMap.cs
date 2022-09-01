using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcUserRightMap
    {
        public int Id { get; set; }
        public short UserId { get; set; }
        public int RightsId { get; set; }

        public virtual LcUserRights Rights { get; set; }
    }
}
