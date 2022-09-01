using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnImportDutyLog
    {
        public long YarnImportIdLog { get; set; }
        public long YarnImportIdOld { get; set; }
        public int? YarnImportFiscalYear { get; set; }
        public string YarnImportFiber { get; set; }
        public string YarnHscode { get; set; }
        public double? YarnImportCd { get; set; }
        public double? YarnImportSd { get; set; }
        public double? YarnImportVat { get; set; }
        public double? YarnImportAit { get; set; }
        public double? YarnImportAtv { get; set; }
        public double? YarnImportRd { get; set; }
        public double? YarnImportOther { get; set; }
        public double? YarnImportTotal { get; set; }
        public long? ModifyUser { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
