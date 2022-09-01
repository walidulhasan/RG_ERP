using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class CMBL_SubProgramDetail
    {
        [Key]
        public int SBD_ID { get; set; }
        [ForeignKey("CMBL_SubProgramMaster")]
        public int SB_ID { get; set; }
        public long? SBD_ItemID { get; set; }
        public double? SBD_ITemByWeight { get; set; }
        public double? SBD_ITemByWeightPercentage { get; set; }
        public double? SBD_ITemByGram { get; set; }
        public double? SBD_ITemByLitre { get; set; }
        public double? SBD_ItemByLiquorRatio { get; set; }
        public int? SBD_ITemUnit { get; set; }
        public string SBD_ItemWiseComment { get; set; }
        public int? SBD_ProcessSequence { get; set; }

        public virtual CMBL_SubProgramMaster CMBL_SubProgramMaster { get; set; }
    }
}
