using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class PatternPiece_Setup
    {
        public int ID { get; set; }
        public string BodyPart { get; set; }
        public int TrimID { get; set; }
        public string PatternPiece { get; set; }
    }
}
