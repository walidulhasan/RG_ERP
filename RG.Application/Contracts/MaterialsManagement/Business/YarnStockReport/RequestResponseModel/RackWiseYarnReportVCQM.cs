using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.YarnStockReport.RequestResponseModel
{
    public class RackWiseYarnReportVCQM
    {
        [Display(Name = "Building")]
        public int Building { get; set; }
        [Display(Name = "Building Floor ")]
        public int BuildingFloorID { get; set; }
        [Display(Name = "Rack")]
        public int RackID { get; set; }
        [Display(Name ="Lot No")]
        public string LotNo { get; set; }
        [Display(Name = "Yarn Composition")]
        public int YarnComposition { get; set; }
        [Display(Name ="Yarn Count")]
        public int YarnCount { get; set; }
        public int OrderBy { get; set; }
        public List<SelectListItem> DDLOrderBy { get; set; }
        public List<SelectListItem> DDLBulding { get; set; }
        public List<SelectListItem> DDLBuildingFloor { get; set; }
        public List<SelectListItem> DDLRack { get; set; }
        public List<SelectListItem> DDLLotno { get; set; }
        public List<SelectListItem> DDLYarnComposition { get; set; }
        public List<SelectListItem> DDLYarnCount { get; set; }

    }
}
