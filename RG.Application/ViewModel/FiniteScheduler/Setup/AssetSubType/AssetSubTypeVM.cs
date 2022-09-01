using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.FiniteScheduler.Setup.AssetSubType
{
    public class AssetSubTypeVM
    {
        public int AssetSubTypeID { get; set; }
        [Display(Name = "Asset Type")]
        public int AssetTypeID { get; set; }
        [Display(Name = "Sub Type Name")]
        public string SubTypeName { get; set; }
        public string Code { get; set; }
        public int Serial { get; set; }
        public string Description { get; set; }
        public List<SelectListItem> DDLBuilding { get; set; }
        public List<SelectListItem> DDLAssetTypeName { get; set; }
    }
}
