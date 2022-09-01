using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
 
    public partial class Yarn_RequisitionMaster
    {
        public Yarn_RequisitionMaster()
        {
            Yarn_RequisitionDetail = new HashSet<Yarn_RequisitionDetail>();
        }
        [Key]
        public long YarnReqID { get; set; }
        public DateTime? YarnReqDate { get; set; }
        public int? YarnReqStatus { get; set; }
        public string UserName { get; set; }
        public bool? AutomatedRequisition { get; set; }
        public int? UserID { get; set; }
        public string YarnReqNo { get; set; }
        public bool? IsDependent { get; set; }
        public string Date { get; set; }
        public long? CompanyID { get; set; }
        public int? BusinessID { get; set; }

        public virtual ICollection<Yarn_RequisitionDetail> Yarn_RequisitionDetail { get; set; }
    }
}
