using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public class tbl_KnittingPickListMaster//
    {
        public tbl_KnittingPickListMaster()
        {
            tbl_KnittingPickListDetail = new HashSet<tbl_KnittingPickListDetail>();
            tbl_KnittingSubPickListMaster = new tbl_KnittingSubPickListMaster();
        }
        [Key]
        public long PickListID { get; set; }
        public long YarnKnittingContractID { get; set; }
        public long JobID { get; set; }
        public string ReceivingPersonName { get; set; }
        public string PickListNo { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Acknowledge { get; set; }
        public int? YarnIssuanceStatus { get; set; }
        public DateTime? YarnReceivingDate { get; set; }
        public virtual ICollection<tbl_KnittingPickListDetail> tbl_KnittingPickListDetail { get; set; }
        public tbl_KnittingSubPickListMaster tbl_KnittingSubPickListMaster { get; set; }
    }
}
