using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DdPoLog
    {
        public long Id { get; set; }
        public long? Poid { get; set; }
        public string Pono { get; set; }
        public int? MrpitemCode { get; set; }
        public string Comments { get; set; }
        public DateTime? CommentDate { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
