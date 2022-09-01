using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SelectedTechnicalInstructions
    {
        public int Id { get; set; }
        public string TechComments { get; set; }
        public int TechCommentId { get; set; }
        public DateTime InsertionDate { get; set; }
        public int UserId { get; set; }
        public long? SelectedElementId { get; set; }
    }
}
