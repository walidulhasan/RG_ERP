using RG.Application.Common.Mappings;
using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderSchedulingMasters.Commands.DataTransferModel
{
    public class OrderSchedulingMastersDTM : IMapFrom<OrderScheduling>
    {
        public int ScheduleID { get; set; }
        public string FlgForAction { get; set; }
        public int OrderID { get; set; }
        public OrderKnittingSchedulingDTM OrderKnittingScheduling { get; set; }
        public OrderDyeingSchedulingDTM OrderDyeingScheduling { get; set; }
        public OrderCuttingSchedulingDTM OrderCuttingScheduling { get; set; }
        public OrderSewingSchedulingDTM OrderSewingScheduling { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<OrderSchedulingMastersDTM, OrderScheduling>();
        }
        
    }

    public class OrderKnittingSchedulingDTM : IMapFrom<OrderKnittingScheduling>
    {

        public int KnittingScheduleID { get; set; }
        public int ScheduleID { get; set; }
        public int KRSID { get; set; }
        public int FabID { get; set; }
        public DateTime ScheduleDate { get; set; }
        public decimal Quantity { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<OrderKnittingSchedulingDTM, OrderKnittingScheduling>();
        }
    }
    public class OrderDyeingSchedulingDTM : IMapFrom<OrderDyeingScheduling>
    {

        public int DyeingScheduleID { get; set; }
        public int ScheduleID { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int FabricQualityID { get; set; }
        public string FabricComposition { get; set; }
        public int GSM { get; set; }
        public decimal FinishedWidth { get; set; }
        public string PantoneNo { get; set; }
        public decimal Quantity { get; set; }
        public decimal WastagePercent { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<OrderDyeingSchedulingDTM, OrderDyeingScheduling>();
        }
    }
    public class OrderCuttingSchedulingDTM : IMapFrom<OrderCuttingScheduling>
    {

        public int CuttingScheduleID { get; set; }
        public int ScheduleID { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int FabricQualityID { get; set; }
        public string FabricComposition { get; set; }
        public int GSM { get; set; }
        public decimal FinishedWidth { get; set; }
        public string PantoneNo { get; set; }
        public decimal Quantity { get; set; }
        public decimal WastagePercent { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<OrderCuttingSchedulingDTM, OrderCuttingScheduling>();
        }
    }
    public class OrderSewingSchedulingDTM : IMapFrom<OrderSewingScheduling>
    {

        public int SewingScheduleID { get; set; }

        public int ScheduleID { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int FabricQualityID { get; set; }
        public string FabricComposition { get; set; }
        public int GSM { get; set; }
        public decimal FinishedWidth { get; set; }
        public string PantoneNo { get; set; }
        public int Quantity { get; set; }
        public decimal WastagePercent { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<OrderSewingSchedulingDTM, OrderSewingScheduling>();
        }
    }
}
