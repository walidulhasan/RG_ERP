using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TrimSpecification
    {
        public int Id { get; set; }
        public long SelectedTrimId { get; set; }
        public long TrimObjectId { get; set; }
        public int InsertionId { get; set; }
        public string Comments { get; set; }
    }
}
