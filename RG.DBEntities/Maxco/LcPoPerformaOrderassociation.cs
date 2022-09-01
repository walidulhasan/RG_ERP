using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcPoPerformaOrderassociation
    {
        public int Id { get; set; }
        public int LpoId { get; set; }
        public int LpiId { get; set; }
        public int LpoOrderid { get; set; }
    }
}
