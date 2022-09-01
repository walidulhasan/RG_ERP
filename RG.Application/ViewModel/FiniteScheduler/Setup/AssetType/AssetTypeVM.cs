using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.FiniteScheduler.Setup.AssetType
{
    public class AssetTypeVM
    {
        public int AssetTypeID { get; set; }
        [Display(Name ="Asset Type")]
        public string TypeName { get; set; }
        public string Code { get; set; }
        public int Serial { get; set; }
        public string Description { get; set; }
    }
}
