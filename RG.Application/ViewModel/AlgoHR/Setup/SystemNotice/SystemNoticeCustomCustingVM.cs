using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.AlgoHR.Setup.SystemNotice
{
    public class SystemNoticeCustomCustingVM
    {
        public int CustingID { get; set; }       
        public int NoticeID { get; set; }
        public int CompanyID { get; set; }
        public int? DivisionID { get; set; }
        public int? DepartmentID { get; set; }
        public int? SectionID { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLDivision { get; set; }
        public List<SelectListItem> DDLDepartment{ get; set; }
        public List<SelectListItem> DDLSection{ get; set; }
    }
}
