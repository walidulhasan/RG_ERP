using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.DBViews
{
    public class View_AttributeInstanceYarnInfo
    {
        public long AttributeInstanceID { get; set; }
        public int MRPItemCode { get; set; }
        public int? YarnCompositionID { get; set; }
        public string YarnComposition { get; set; }
        public int? CountID { get; set; }
        public string YarnCount { get; set; }
        public int? YarnQualityID { get; set; }
        public string YarnQuality { get; set; }
        public string YarnDyeingMethodID { get; set; }
        public string YarnDyeingMethod { get; set; }
        public string YarnColorID { get; set; }
        public string YarnColor { get; set; }
        public int? ContaminationID { get; set; }
        public string Contamination { get; set; }
    }
}
