using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel
{
    public class SubContractGatePassRM
    {
        public string Serial { get; set; }
        public string GPDate { get; set; }
        public string VehicleNo { get; set; }
        public long CompanyID { get; set; }
        public string IssuedTo { get; set; }
        public string Representative { get; set; }
        public string RepresentativeContact { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public int UnitID { get; set; }
        public decimal GrossWeight { get; set; }
        public string Unit { get; set; }
        public string Remarks { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public long Rowsr { get; set; }
        
    }
}
