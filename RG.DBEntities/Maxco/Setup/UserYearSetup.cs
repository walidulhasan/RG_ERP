using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class UserYearSetup
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? Year { get; set; }
    }
}
