using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public class AssetDivision
    {
        public int DivisionID { get; set; }
        public string DivisionName { get; set; }
        public string DivisionShortCode { get; set; }
        public int EmbroCompanyID { get; set; }
        public string HRDivisionID { get; set; }
    }
}
