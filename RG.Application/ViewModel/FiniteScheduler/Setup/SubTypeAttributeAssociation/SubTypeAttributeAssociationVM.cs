using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.FiniteScheduler.Setup.SubTypeAttributeAssociation
{
    public class SubTypeAttributeAssociationVM
    {
        [Display(Name ="Asset Type")]
        public int AssetType { get; set; }
        [Display(Name = "Asset Sub Type")]
        public int AssetSubType { get; set; }

        public List<SelectListItem> DDLAssetType { get; set; }
        public List<SelectListItem> DDLAssetSubType { get; set; }
    }
}
