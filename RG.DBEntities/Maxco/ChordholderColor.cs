using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;


namespace RG.DBEntities.Maxco
{
    public partial class ChordholderColor
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public string TrimColor { get; set; }
        public int ColorSetId { get; set; }
        public int? MatchId { get; set; }

        public virtual ColorMatching_Setup Match { get; set; }
        public virtual ChordHolderSpecification Object { get; set; }
    }
}
