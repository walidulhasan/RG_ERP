using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.Maxco.Business.OrderScheduling
{
    public class CuttingSchedulingVM
    {
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public string FabricType { get; set; }
        public string FabricQuality { get; set; }
        public int FabricQualityID { get; set; }
        public string ColorName { get; set; }
        public int NumberOfGarments { get; set; }
        public string FabricComposition { get; set; }
        public int GSM { get; set; }
        public decimal FinishedWidth { get; set; }
        public string PantoneNo { get; set; }
        public decimal Quantity { get; set; }
    }
}
