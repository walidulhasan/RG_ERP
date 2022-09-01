using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblItemImportDutyLog
    {
        [Key]
        public long CmblLogId { get; set; }
        public DateTime? CreatDate { get; set; }
        public long CmblId { get; set; }
        public int? CmblFiscal { get; set; }
        public long? CmblItemId { get; set; }
        public string CmblHscode { get; set; }
        public double? CmblCustomDuty { get; set; }
        public double? CmblSupplementaryDuty { get; set; }
        public double? CmblVat { get; set; }
        public double? CmblAit { get; set; }
        public double? CmblAtv { get; set; }
        public double? CmblRd { get; set; }
        public double? CmblOther { get; set; }
        public double? CmblTtl { get; set; }
        public long? ModifyUser { get; set; }
    }
}
