using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class IC_ReturnableGatePassMaster : DefaultTableProperties
    {
       
        public long GatePassID { get; set; }
        public long IssuedBy { get; set; }
        public string IssuedTo { get; set; }
        public int VendorID { get; set; }
        public bool? isSelfVehicle { get; set; }
        public string Representative { get; set; }
        public int? NarrowGroupId { get; set; }
        public int? IdentificationId { get; set; }
        public string RepresentativeContact { get; set; }
        public string HRMSID { get; set; }
        public string JobDesc { get; set; }
        public long? DepartmentID { get; set; }
        public virtual IC_GatepassMaster IC_GatepassMaster { get; set; }
        public virtual List<IC_ReturnableGatePassDetail> IC_ReturnableGatePassDetail { get; set; }
    }
}
