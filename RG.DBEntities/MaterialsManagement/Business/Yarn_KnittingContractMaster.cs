using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class Yarn_KnittingContractMaster
    {
        public Yarn_KnittingContractMaster()
        {
            Yarn_IssuanceToKnitterMaster = new HashSet<Yarn_IssuanceToKnitterMaster>();
            Yarn_KnittingContractDeliverySchedule = new HashSet<Yarn_KnittingContractDeliverySchedule>();
            Yarn_KnittingContractDetail = new HashSet<Yarn_KnittingContractDetail>();
            YarnKnittingContractFlatBed = new HashSet<Yarn_KnittingContractFlatBed>();
            YarnKnittingContractTippingSpecification = new HashSet<Yarn_KnittingContractTippingSpecification>();
            YarnKnittingContractYarnSpecification = new HashSet<YarnKnittingContractYarnSpecification>();
            YarnReturnfromKnittergriege = new HashSet<YarnReturnfromKnittergriege>();
            Yarn_KnittingContractColor = new HashSet<Yarn_KnittingContractColor>();
        }
        [Key]
        public long YarnKNContractID { get; set; }
        public int? GreigeMRP { get; set; }
        public long? GreigeAttributeInstanceID { get; set; }
        public int ContractStatus { get; set; }
        public long KnitterID { get; set; }
        //public int? KnitterCompanyId { get; set; }
        public string ContractName { get; set; }
        public int? ProgramTypeID { get; set; }
        public int? OrderID { get; set; }
        public string OrderNo { get; set; }
        public DateTime? ContractDate { get; set; }
        public string AverageDailyProduction { get; set; }
        public double? RatePerKG { get; set; }
        public int? DailyProduction { get; set; }
        public string ModeOfPayment { get; set; }
        public int? TermOfPayment { get; set; }
        public long? FabricCategoryID { get; set; }
        public long? QualityID { get; set; }
        public int? GSM { get; set; }
        public long? MachineTypeID { get; set; }
        public long? IsSpandex { get; set; }
        public long? GaugeID { get; set; }
        public long? DyeingID { get; set; }
        public long? ShrinkageWidth { get; set; }
        public long? ShrinkageLength { get; set; }
        public string Comments { get; set; }
        public long? FabricTrimSelectedID { get; set; }
        public long? FinishedWidth { get; set; }
        public long? FinishedLength { get; set; }
        public int? IsDivisor { get; set; }
        public int? NoofMachines { get; set; }
        public double? TotalQty { get; set; }
        public long? FabricTypeID { get; set; }
        public int? DesignType { get; set; }
        public int? KnittingContractTypeSetupID { get; set; }
        public string ModelName { get; set; }
        public int? IsClosed { get; set; }
        public int? DayOfPayment { get; set; }
        public double? BalanceQty { get; set; }
        public int? ModelID { get; set; }
        public long Status { get; set; }
        public int? KnittingWastageID { get; set; }
        public int? MaterialSourceID { get; set; }
        public int? FabricCodeID { get; set; }
        public long? CompanyID { get; set; }
        public int? BusinessID { get; set; }
        public int? KRS_ID { get; set; }
        public int? FID { get; set; }
        public string StichLength { get; set; }
        public int? ClosureStatus { get; set; }
        public double? ClosurePartialQuantity { get; set; }
        public double? YKNCClosureQuantity { get; set; }
        

        public virtual ICollection<Yarn_IssuanceToKnitterMaster> Yarn_IssuanceToKnitterMaster { get; set; }
        public virtual ICollection<Yarn_KnittingContractDeliverySchedule> Yarn_KnittingContractDeliverySchedule { get; set; }
        public virtual ICollection<Yarn_KnittingContractDetail> Yarn_KnittingContractDetail { get; set; }
        public virtual ICollection<Yarn_KnittingContractFlatBed> YarnKnittingContractFlatBed { get; set; }
        public virtual ICollection<Yarn_KnittingContractTippingSpecification> YarnKnittingContractTippingSpecification { get; set; }
        public virtual ICollection<YarnKnittingContractYarnSpecification> YarnKnittingContractYarnSpecification { get; set; }
        public virtual ICollection<YarnReturnfromKnittergriege> YarnReturnfromKnittergriege { get; set; }
        public virtual ICollection<Yarn_KnittingContractColor> Yarn_KnittingContractColor { get; set; }
       
    }
}
