using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Embro.Setup
{
    public class CompanyInfo
    {
        [Key]
        [ForeignKey("BasicCOA")]
        public decimal CompanyID { get; set; }
        public string Companyname { get; set; }
        public string NTN { get; set; }
        public string STN { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public virtual BasicCOA BasicCOA { get; set; }
        public string CompanyShortName { get; set; }
        public string MainFactoryAddress { get; set; }
        public string Code { get; set; }
    }
}
