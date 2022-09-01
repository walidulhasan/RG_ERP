using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MaterialsManagement.Business.UserWiseDepartmentAssaign
{
    public class UserWiseDepartmentAssaignVM
    {
        [Display(Name ="User")]
        public string UserID { get; set; }
        public List<SelectListItem> UserNameList { get; set; }
        public List<UserWiseDepartmentRM> UserWiseDepartment { get; set; }
    }
}
