using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public class AssetLocation:DefaultTableProperties
    {
        public int ID { get; set; }
        [ForeignKey("AssetInfo")]
        public int AssetID { get; set; }
        public int BuildingID { get; set; }
        public int FloorID { get; set; }
        public int DepartmentID { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool IsReturned { get; set; }
        public virtual AssetInfo AssetInfo { get; set; }
    }
}
