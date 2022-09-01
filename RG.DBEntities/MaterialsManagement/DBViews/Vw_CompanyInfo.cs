using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.DBViews
{
    public class Vw_CompanyInfo
    {
        public decimal CompanyID { get; set; }
        public string Companyname { get; set; }
        public string NTN { get; set; }
        public string STN { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string CompanyShortName { get; set; }
        public string MainFactoryAddress { get; set; }
        public string Code { get; set; }
    }
}
