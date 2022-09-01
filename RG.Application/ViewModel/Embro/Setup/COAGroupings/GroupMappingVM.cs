using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.Embro.Setup.COAGroupings
{
    public class GroupMappingVM
    {
        public int GroupCategoryID { get; set; }
        public List<SelectListItem> DDLGroupCategory { get; set; }
    }
}
