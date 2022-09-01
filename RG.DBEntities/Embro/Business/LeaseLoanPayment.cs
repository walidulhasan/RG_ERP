using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Embro.Business
{
    public partial class LeaseLoanPayment
    {
        public LeaseLoanPayment()
        {
            LeaseAssetsContractWise = new HashSet<LeaseAssetsContractWise>();
            Rentals = new HashSet<Rentals>();
        }
        [Key]
        public int LeaseLoanID { get; set; }
        [Key, Column(Order = 0)]
        public string LeaseLoanCode { get; set; }
        public string InstallmentPeriodType { get; set; }
        public int? NoOfinstallments { get; set; }
        public DateTime?firstInstallmentDate { get; set; }
        public float? TotalLiability { get; set; }
        public float? LeaseRental { get; set; }
        public float? InterestRatepa { get; set; }
        public float? DepositAmnt { get; set; }
        public float? BargainPurchaseValue { get; set; }
        public string IsLeaseOwnershipTransferable { get; set; }
        public string Ltype { get; set; }
        public int? GracePeriod { get; set; }
        public int? LeasorLenderID { get; set; }
        public int? AssetID { get; set; }
        public int? AssetCOAID { get; set; }
        public bool? ISINSURANCE { get; set; }
        public int? VERSIONNO { get; set; }
        [Key, Column(Order = 1)]
        public int? COMPANYID { get; set; }
        public bool? ContractType { get; set; }
        public string PaymentMode { get; set; }
        public int Status { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string Description { get; set; }
        public DateTime? RevisionDate { get; set; }

        public virtual ICollection<LeaseAssetsContractWise> LeaseAssetsContractWise { get; set; }
        public virtual ICollection<Rentals> Rentals { get; set; }
    }
}
