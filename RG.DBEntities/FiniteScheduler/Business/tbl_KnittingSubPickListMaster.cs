using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public class tbl_KnittingSubPickListMaster//
    {
        public tbl_KnittingSubPickListMaster()
        {
            tbl_KnittingSubPickListDetail = new HashSet<tbl_KnittingSubPickListDetail>();
        }
        [Key]
        public long SubPickListID { get; set; }
        [ForeignKey("tbl_KnittingPickListMaster")]
        public long MasterPickListID { get; set; }
        public string ReceivingPersonName { get; set; }
        public string SubPickListNo { get; set; }
        public DateTime CreationDate { get; set; }
        public int? Acknowledge { get; set; }
        public int? YarnIssuanceStatus { get; set; }
        public DateTime? YarnReceivingDate { get; set; }
        public virtual ICollection<tbl_KnittingSubPickListDetail> tbl_KnittingSubPickListDetail { get; set; }
        public virtual tbl_KnittingPickListMaster tbl_KnittingPickListMaster { get; set; }
    }
}
