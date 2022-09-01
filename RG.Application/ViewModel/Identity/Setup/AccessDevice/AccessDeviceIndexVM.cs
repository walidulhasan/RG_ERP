using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.Identity.Setup.AccessDevice
{
    public class AccessDeviceIndexVM
    {
       
        
        [Display(Name = "User")]
        public int UserID { get; set; }
        
        [Display(Name = "Device Dependency")]
        public int DeviceDependencyTypeID { get; set; }
        [Display(Name = "Device Identity")]
        public string DeviceIdenity { get; set; }

        public List<SelectListItem> DDLUsers { get; set; }
        
        public List<SelectListItem> DDLDeviceDependencyTypes { get; set; }      
    }
}
