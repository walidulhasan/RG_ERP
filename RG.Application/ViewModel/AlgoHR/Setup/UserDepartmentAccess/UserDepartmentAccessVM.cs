using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.AlgoHR.Setup.UserDepartmentAccess
{
    public class UserDepartmentAccessVM
    {
        public UserDepartmentAccessVM()
        {
            DDLUser = new List<SelectListItem>();
            DDLCompany = new List<SelectListItem>();
            DDLDivision = new List<SelectListItem>();
            DDLDepartment = new List<SelectListItem>();
            DDLSection = new List<SelectListItem>();
        }
        public int ID { get; set; }
        [Display(Name ="User Name")]
        public int CA_UserID { get; set; }
        public int Embro_CompanyID { get; set; }
        public int DivisionID { get; set; }
        public int DepartmentID { get; set; }
        public int SectionID { get; set; }

        public List<SelectListItem> DDLUser { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLDivision { get; set; }
        public List<SelectListItem> DDLDepartment { get; set; }
        public List<SelectListItem> DDLSection { get; set; }

    }
}
