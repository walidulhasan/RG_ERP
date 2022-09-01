using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class CMBL_SubProgramMaster
    {
        public CMBL_SubProgramMaster()
        {
            CMBL_SubProgramDetail = new HashSet<CMBL_SubProgramDetail>();
        }
        [Key]
        public int SB_ID { get; set; }
        public string SB_Name { get; set; }
        public string SB_Code { get; set; }
        public DateTime? SB_CreationDate { get; set; }
        public int? CompanyID { get; set; }

        public virtual ICollection<CMBL_SubProgramDetail> CMBL_SubProgramDetail { get; set; }
    }
}
