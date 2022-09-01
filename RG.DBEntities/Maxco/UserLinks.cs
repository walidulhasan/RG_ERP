using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class UserLinks
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public short UserId { get; set; }
    }
}
