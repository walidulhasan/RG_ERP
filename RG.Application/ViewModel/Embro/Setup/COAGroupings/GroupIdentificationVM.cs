using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.Embro.Setups.BasicCOAs.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.Embro.Setup.COAGroupings
{
    public class GroupIdentificationVM
    {
        public int GroupCategoryID { get; set; }        
        public int GroupID { get; set; }
        public List<SelectListItem> DDLCOAGroup { get; set; }
        public List<SelectListItem> DDLCOAGroupingCategory { get; set; }
        public List<BasicCOADetailRM> BasicCOADetail { get; set; }
    }    
}
