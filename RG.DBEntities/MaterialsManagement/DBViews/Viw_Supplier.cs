using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.DBViews
{
    public class Viw_Supplier
    {
        
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string SalesTaxRegNumber { get; set; }
        public string NTNNumber { get; set; }
        public string Comments { get; set; }
        public string SupplierType { get; set; }
        public int? Identification_ID { get; set; }
        public string ACC_Identification { get; set; }
        public int? NarrowGroup_ID { get; set; }
        public string Acc_NarrowGroup { get; set; }
        public int? BroadGroup_ID { get; set; }
        public string Acc_BroadGroup { get; set; }
        public int? SubCategory_ID { get; set; }
        public string Acc_SubCategory { get; set; }
        public int? Category_ID { get; set; }
        public string Acc_Category { get; set; }
        public int? CompanyId { get; set; }
        public string Acc_Company { get; set; }
        public string CompanyShort { get; set; }
    }
}
