using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
  public  class MM_ModelRequisitionMaster
    {
        public MM_ModelRequisitionMaster()
        {
            MM_ModelRequisitionRequirement = new HashSet<MM_ModelRequisitionRequirement>();
        }
        [Key]
        public int MRMID { get; set; }
        public string MRMNo { get; set; }
        public int? UserID { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Status { get; set; }
        public int? ModelID { get; set; }
        public int? IsPresumption { get; set; }
        public string IPAddress { get; set; }

        public virtual ICollection<MM_ModelRequisitionRequirement> MM_ModelRequisitionRequirement { get; set; }
    }
}
