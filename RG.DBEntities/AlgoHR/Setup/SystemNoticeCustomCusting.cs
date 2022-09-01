using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.AlgoHR.Setup
{
    public class SystemNoticeCustomCusting : DefaultTableProperties
    {
        [Key]
        public int CustingID { get; set; }
        [ForeignKey("SystemNotice")]
        public int NoticeID { get; set; }
        public int CompanyID { get; set; }
        public int? DivisionID { get; set; }
        public int? DepartmentID { get; set; }
        public int? SectionID { get; set; }
        public virtual SystemNotice SystemNotice { get; set; }
    }
}
