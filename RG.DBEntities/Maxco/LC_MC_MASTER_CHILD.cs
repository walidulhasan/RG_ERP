using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class LC_MC_MASTER_CHILD
    {
        public LC_MC_MASTER_CHILD()
        {
           // LcCdChildDetail = new HashSet<LcCdChildDetail>();
        }
       // public int Id { get; set; }
        [Key]
        public int LMC_ID { get; set; }
        public int LOM_ID { get; set; }
        public string LMC_CODE { get; set; }
        public string LMC_LCNO { get; set; }
        public short? LMC_MODUSERID { get; set; }
        public DateTime? LMC_LASTMODDATE { get; set; }
        public int LMC_VENDOR_ID { get; set; }
        public int LMC_COMPANYBANK_ID { get; set; }
        public int? LMC_BANKACCOUNTID { get; set; }
        public int LMC_ISSUANCECITYID { get; set; }
        public DateTime LMC_DATEOFISSUANCE { get; set; }
        public int LMC_EXPIRYCITYID { get; set; }
        public DateTime LMC_DATEOFEXPIRY { get; set; }
        public int LMC_LCCONDITION { get; set; }
        public string LMC_LCANO { get; set; }
        public string LMC_IRCNO { get; set; }
        public string LMC_INSSURANCECOM { get; set; }
        public string LMC_INSSURANCECOMADD { get; set; }
        public string LMC_INSSURANCECOMNOTENO { get; set; }
        public string LMC_HSCODE { get; set; }
        public int? HSCODE_ID { get; set; }
        public string LMC_PORTOFDISSCHARGE { get; set; }
        public DateTime? LMC_CREATIONDATE { get; set; }
        public int? LMC_CREATIONUSERID { get; set; }
        public string LMC_SPECIALCOMMENTS { get; set; }
        public int? LLT_ID { get; set; }
        public int? LLS_ID { get; set; }
        public string LMC_VENDORPI { get; set; }
        public decimal? LMC_VENDORPIVALUE { get; set; }
        public DateTime? LMC_VENDORPIDATE { get; set; }
        public string LMC_CNTRY_ORIGIN { get; set; }
        public string LMC_MODE_SHIPMENT { get; set; }
        public string LMC_PORT_SHIPMENT { get; set; }
        public string LMC_HEADER { get; set; }
        public string LMC_FOOTER { get; set; }
        public string LMC_CONDITIONS { get; set; }
        public string LMC_PAYMENT_TERMS { get; set; }
        public int? Currency { get; set; }
        public string LMC_INTEREST { get; set; }
        public DateTime? LMC_BankLCDate { get; set; }
        public DateTime? LMC_SHIPDATE { get; set; }

        //public virtual City_Setup LmcExpirycity { get; set; }
        //public virtual City_Setup LmcIssuancecity { get; set; }
        //public virtual UserSetup LmcModuser { get; set; }
        //public virtual LcOmOrderMaster Lom { get; set; }
        //public virtual ICollection<LcCdChildDetail> LcCdChildDetail { get; set; }
    }
}
