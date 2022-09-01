using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel
{
    public class ManagementStatusRM
    {
        public DateTime StatusDate { get; set; }
        public string StatusDateMsg { get { return StatusDate.ToString("dd-MMM-yyyy"); } }
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public int OrderID { get; set; }
        public string OrderName { get; set; }
        public decimal KnittingInhouse { get; set; }
        public decimal KnittingOutSide { get; set; }
        public decimal KnittingTotal { get { return KnittingInhouse + KnittingOutSide; } }
        public decimal BatchCBL { get; set; }
        public decimal BatchCPB { get; set; }
        public decimal BatchAOP { get; set; }               
        public decimal BatchTotal { get { return BatchAOP + BatchCPB + BatchCBL; } }
        public decimal DyeingAOP { get; set; }
        public decimal DyeingCPB { get; set; }
        public decimal DyeingAOPCPBTotal { get { return DyeingAOP + DyeingCPB; } }
        public decimal DyeingCBL { get; set; }
        public decimal DyeingTotal { get { return DyeingCBL + DyeingAOPCPBTotal; } }
               
        public decimal AdditionalReq { get; set; }
        public decimal AdditionalIssue { get; set; }
        public decimal AdditionalUtilized { get; set; }
        public decimal FabricUtilized { get; set; }

        public decimal GarmentsCutting { get; set; }
        public decimal GarmentsSewing { get; set; }
        public decimal GarmentsEfficiency { get; set; }
        public decimal GarmentsShipment { get; set; }
    }
}
