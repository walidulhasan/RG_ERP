using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.Maxco.Business.OrderPlanReports
{
    public class OrderStatusVM
    {
        public OrderStatusVM()
        {
            //OrderPlan = new List<OrderPlan>();
            //OrderWastage = new List<OrderWastage>();            
            // OrderFinishFabric = new List<OrderFinishFabric>();
            //OrderGreigeFabric = new List<OrderGreigeFabric>();
            AssortmentAndFabrics = new List<Plan_GarmentAssortmentAndFabricsReport>();
            BatchAndFinishQuantity = new List<Plan_OrderBatchAndFinishQuantityReport>();
            GreigeQuantity = new List<Plan_OrderGreigeQuantityReport>();

            OrderCommitment = new List<OrderCommitment>();
            OrderArtWork = new List<OrderArtWork>();
        }
        //public List<OrderPlan> OrderPlan { get; set; }
        //public List<OrderWastage> OrderWastage { get; set; }
        //public List<OrderFinishFabric> OrderFinishFabric { get; set; }
        //public List<OrderGreigeFabric> OrderGreigeFabric { get; set; }
        public List<Plan_GarmentAssortmentAndFabricsReport> AssortmentAndFabrics { get; set; }
        public List<Plan_OrderBatchAndFinishQuantityReport> BatchAndFinishQuantity { get; set; }
        public List<Plan_OrderGreigeQuantityReport> GreigeQuantity { get; set; }
        public List<OrderCommitment> OrderCommitment { get; set; }   
        public List<OrderArtWork> OrderArtWork { get; set; }
    }
    //public class OrderPlan
    //{
    //    public DateTime OrderReceiveDate { get; set; }
    //    public string OrderReceiveDateMsg { get => OrderReceiveDate.ToString("dd-MMM-yyyy"); }
    //    public int PlanStyleFabricsID { get; set; }
    //    public int BuyerID { get; set; }
    //    public string BuyerName { get; set; }
    //    public long OrderID { get; set; }
    //    public string OrderNo { get; set; }
    //    public string Style { get; set; }
    //    public DateTime ShipmentDate { get; set; }
    //    public string ShipmentDateMsg { get => ShipmentDate.ToString("dd-MMM-yyyy"); }
    //    public int FabricWeek { get; set; }
    //    public string PantoneNo { get; set; }
    //    public string ColorName { get; set; }
    //    public string FabricType { get; set; }
    //    public string Quality { get; set; }
    //    public string FabricComposition { get; set; }
    //    public int GSM { get; set; }
    //    public int FabricTypeID { get; set; }
    //    public int FabricQualityID { get; set; }
    //    public decimal FinishedWidth { get; set; }
    //    public int MachineTypeID { get; set; }
    //    public int DyeingID { get; set; }
    //    public int GaugeID { get; set; }
    //    public string GsFtFwFcFqMtDlGu { get; set; }
    //    public long NumberofGarments { get; set; }
    //    public decimal MainFabricUseConsumption { get; set; }
    //    public decimal RibUseConsumption { get; set; }
    //    public decimal TotalFabricQty { get; set; }

    //}
    //public class OrderWastage
    //{
    //    public int OrderID { get; set; }
    //    public string FabricComposition { get; set; }
    //    public string GsFtFwFcFqMtDlGu { get; set; }
    //    public decimal RequiredQuantity { get; set; }
    //    public decimal WastagePercent { get; set; }
    //    public decimal RequiredQuantityWithWastage { get; set; }
    //}

    //public class OrderFinishFabric
    //{
    //    public int OrderID { get; set; }
    //    public string FabricQuality { get; set; }
    //    public string PantoneNo { get; set; }
    //    public decimal BatchQty { get; set; }
    //    public decimal FinishQty { get; set; }
    //    public decimal RibQty { get; set; }

    //}
    //public class OrderGreigeFabric
    //{
    //    public int OrderID { get; set; }
    //    public string FabricComposition { get; set; }
    //    public string FabricQuality { get; set; }
    //    public decimal GreigeQty { get; set; }

    //}
    public class OrderCommitment
    {
        public int OrderID { get; set; }
        public DateTime CommitmentDate { get; set; }
        public string CommitmentDateMsg { get; set; }
        public decimal CommitmentQuantity { get; set; }

    }
    public class OrderArtWork
    {
        public int OrderID { get; set; }
        public string PantoneNo { get; set; }
        public string ArtWorkName { get; set; }

    }
}
