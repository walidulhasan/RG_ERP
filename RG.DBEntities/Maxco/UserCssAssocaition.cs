using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class UserCssAssocaition
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CssId { get; set; }
    }
}
