using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class TechnicalCommentsImagesSetup
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public int TechCommentId { get; set; }
        public string ImagePath { get; set; }
    }
}
