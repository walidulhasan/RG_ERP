using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel
{
    public class UnsatisfiedReturnableGoodsRM
    {
        public long GatePassID { get; set; }
        public string GatePassNo { get; set; }
        public string GatePassDate { get; set; }
        public string Supplier { get; set; }
        public int ExceedDays { get; set; }
        public string ItemName { get; set; }
        public string ExpectedReturnDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal GrossWeight { get; set; }
        public string Unit { get; set; }
        public decimal RecieveQuantity { get; set; }
        public decimal Balance { get; set; }
        public string Remarks { get; set; }


        public string CreatorEmployee { get; set; }
        public string CreatorDepartment { get; set; }
        public string CreatedDate { get; set; }

        public string MarkOutEmployee { get; set; }
        public string MarkedOutOn { get; set; }

    }
}
