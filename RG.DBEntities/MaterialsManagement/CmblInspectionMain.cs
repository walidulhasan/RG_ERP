using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblInspectionMain
    {
        public CmblInspectionMain()
        {
            CmblInspectionDetail = new HashSet<CmblInspectionDetail>();
            CmblOutGatePass = new HashSet<CmblOutGatePass>();
            CmblRecievingwithPo = new HashSet<CmblRecievingwithPo>();
        }
        [Key]
        public long Minid { get; set; }
        public string Minno { get; set; }
        public DateTime? Mindate { get; set; }
        public long? Poid { get; set; }
        public long? Docid { get; set; }
        public int? DoctypeId { get; set; }
        public long? CompanyId { get; set; }
        public int? Trid { get; set; }
        public int PrecStatus { get; set; }
        public int? UserId { get; set; }
        public int Deleted { get; set; }
        public int? Ogpstatus { get; set; }

        public virtual ICollection<CmblInspectionDetail> CmblInspectionDetail { get; set; }
        public virtual ICollection<CmblOutGatePass> CmblOutGatePass { get; set; }
        public virtual ICollection<CmblRecievingwithPo> CmblRecievingwithPo { get; set; }
    }
}
