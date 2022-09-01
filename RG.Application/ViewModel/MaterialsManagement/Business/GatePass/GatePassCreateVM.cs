using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MaterialsManagement.Business.GatePass
{
    public class GatePassCreateVM
    {
        public long GatePassID { get; set; }
        [Display(Name = "Category")]
        public byte CategoryID { get; set; }

        public List<SelectListItem> CategoryList { get; set; }

    }
}
