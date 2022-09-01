using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.Maxco.Business.OrderScheduling
{
    public class KnittingSchedulingVM
    {

        public long OrderID { get; set; }
        public string FabricType { get; set; }
        public string FabricQuality { get; set; }
        public string Quality { get; set; }
        public string FabricComposition { get; set; }
        public int GSM { get; set; }
        public decimal FinishedWidth { get; set; }
        public decimal KnittingQuantity { get; set; }
        public decimal KnittingQuantityWithWastage { get; set; }

        public int KrsID { get; set; }
        public int FabID { get; set; }


    }
}
