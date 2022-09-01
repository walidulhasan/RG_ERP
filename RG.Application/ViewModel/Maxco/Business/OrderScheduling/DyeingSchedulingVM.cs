using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.Maxco.Business.OrderScheduling
{
    public class DyeingSchedulingVM
    {
        public int OrderID { get; set; }
        public string FabricType { get; set; }
        public string FabricQuality { get; set; }
        public int FabricQualityID { get; set; }
        public string Quality { get; set; }
        public string FabricComposition { get; set; }
        public int GSM { get; set; }
        public decimal FinishedWidth { get; set; }
        public string PantoneNo { get; set; }
        public decimal FinishFabricQty { get; set; }
    }
}
