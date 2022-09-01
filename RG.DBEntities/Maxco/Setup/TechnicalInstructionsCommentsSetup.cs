using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class TechnicalInstructionsCommentsSetup
    {
        public int Id { get; set; }
        public int TechCommentId { get; set; }
        public string TechComments { get; set; }
        public int? TechInstructionId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
