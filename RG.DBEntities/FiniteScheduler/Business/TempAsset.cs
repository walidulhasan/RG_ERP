using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public class TempAsset
    {
        public int ID { get; set; }
        public string Company { get; set; }
        public int CompanyID { get; set; }
        public string AssetType { get; set; }
        public int AssetTypeID { get; set; }
        public string SubType { get; set; }
        public int SubTypeID { get; set; }
        public string AssetName { get; set; }
        public string Description { get; set; }
        public string Division { get; set; }
        public int DivisionID { get; set; }
        public string Department { get; set; }
        public int DepartmentID { get; set; }
        public string Building { get; set; }
        public int BuildingID { get; set; }
        public string Floor { get; set; }
        public int FloorID { get; set; }
        public bool IsUploaded { get; set; }
    }
}
