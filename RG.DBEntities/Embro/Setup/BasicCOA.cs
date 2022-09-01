using RG.DBEntities.Embro.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Embro.Setup
{
  public partial  class BasicCOA
    {
        public BasicCOA()
        {
            //ApmSupplierPaymentTerms = new HashSet<ApmSupplierPaymentTerms>();
            //ApmTaxationSetup = new HashSet<ApmTaxationSetup>();
            //BankRecGeneralInfo = new HashSet<BankRecGeneralInfo>();
            CBM_ACTYPE = new HashSet<CBM_ACTYPE>();
            //CbmBaccountFacility = new HashSet<CbmBaccountFacility>();
            CBM_Bank = new HashSet<CBM_Bank>();
            CBM_BankAccountSetup = new HashSet<CBM_BankAccountSetup>();
            CBM_BankAccountSetupType = new HashSet<CBM_BankAccountSetup>();
            //CbmFinFacility = new HashSet<CbmFinFacility>();
            CostCenterLocation = new HashSet<CostCenterLocation>();
            //InventoryInformation = new HashSet<InventoryInformation>();
            //StoresInformation = new HashSet<StoresInformation>();
            //ValuationClass = new HashSet<ValuationClass>();
        }

        public decimal ID { get; set; }
        public string DESCRIPTION { get; set; }
        public string AccountCode { get; set; }
        public int? ParentID { get; set; }
        public int LevelID { get; set; }
        public byte Status { get; set; }
        public DateTime RDATE { get; set; }
        public long? NaturalAccountID { get; set; }

        
        

        public virtual CompanyInfo CompanyInfo { get; set; }
        public virtual Location Location { get; set; }
        //public virtual ICollection<ApmSupplierPaymentTerms> ApmSupplierPaymentTerms { get; set; }
        //public virtual ICollection<ApmTaxationSetup> ApmTaxationSetup { get; set; }
        //public virtual ICollection<BankRecGeneralInfo> BankRecGeneralInfo { get; set; }
        public virtual ICollection<CBM_ACTYPE> CBM_ACTYPE { get; set; }
        //public virtual ICollection<CbmBaccountFacility> CbmBaccountFacility { get; set; }
        public virtual ICollection<CBM_Bank> CBM_Bank { get; set; }
        public virtual ICollection<CBM_BankAccountSetup> CBM_BankAccountSetup { get; set; }
        public virtual ICollection<CBM_BankAccountSetup> CBM_BankAccountSetupType { get; set; }
        //public virtual ICollection<CbmFinFacility> CbmFinFacility { get; set; }
        public virtual ICollection<CostCenterLocation> CostCenterLocation { get; set; }
        //public virtual ICollection<InventoryInformation> InventoryInformation { get; set; }
        //public virtual ICollection<StoresInformation> StoresInformation { get; set; }
        //public virtual ICollection<ValuationClass> ValuationClass { get; set; }
    }
}
