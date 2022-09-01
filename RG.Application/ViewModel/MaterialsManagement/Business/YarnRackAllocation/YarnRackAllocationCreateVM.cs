using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MaterialsManagement.Business.YarnRackAllocation
{
    public class YarnRackAllocationCreateVM
    {
        [Display(Name ="Supplier")]
        public int SupplierID { get; set; }
        [Display(Name = "PO")]
        public long POID { get; set; }
        [Display(Name = "Lot No")]
        public string LotNo { get; set; }
        public List<SelectListItem> DDLSupplier { get; set; }
        public List<SelectListItem> DDLPO { get; set; }
        public List<SelectListItem> DDLLot { get; set; }
        [Display(Name = "GR Number")]
        public string PermanentReceivingNo { get; set; }
        public string ConditionPOData { get; set; }
    }
}
