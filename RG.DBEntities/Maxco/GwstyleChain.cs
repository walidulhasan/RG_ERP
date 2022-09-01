using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class GwstyleChain
    {
     
        [Key]
        public long GwstyleChain1 { get; set; }
        public long Gwchain { get; set; }
        public long StyleId { get; set; }
        public int VersionNo { get; set; }
    }
}
