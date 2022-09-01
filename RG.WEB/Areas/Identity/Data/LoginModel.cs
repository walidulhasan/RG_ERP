using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Identity.Data
{
    public class LoginVM
    {
        public string ReturnUrl { get; set; }

        [Required(ErrorMessage = "Enter Username")]
        [Display(Name = "User Name")]
        [MaxLength(50, ErrorMessage = "Maximam Lenght 50")]
        [MinLength(3, ErrorMessage = "Minimum 3.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public int IsNeedBusinessID { get; set; } = 0;

        [Display(Name = "Business")]
        public int BusinessID { get; set; }

        public List<SelectListItem> DDLUserBusiness { get; set; }
        [Display(Name = "Company")]
        public int CompanyID { get; set; }
        public List<SelectListItem> DDLUserCompany { get; set; }
        public string Message { get; set; }
        public string AppLink { get; set; }

        public int UserId { get; set; }
        public string DeviceIdentity { get; set; } 
        public string LoginDeviceType { get; set; }
        public string DevicePlatform { get; set; }

        public string AppVersion { get; set; } = null;
        public string RequestDeviceName { get; set; } = null;
        public string RequestDeviceModel { get; set; } = null;
        public string RequestSecretCode { get; set; } = null;


    }
}
